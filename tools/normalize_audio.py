"""Bring the 2006 dialogue recordings to one even loudness (EBU R128), in place under assets/.

The original recordings were made at very different levels (-27 to -15 LUFS); the dialogues
sounded much quieter than the letters. This evens them out to TARGET with a true-peak ceiling,
using ffmpeg's two-pass loudnorm. Re-running is harmless: files already within 0.5 LU are skipped.
The untouched 2006 originals stay in the LearningKhmer release.

Usage (needs ffmpeg on PATH):
    python tools/normalize_audio.py [folder ...]     default: assets/audio/conversation
"""
import json
import re
import subprocess
import sys
import tempfile
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
TARGET, PEAK, LRA = -16.0, -1.5, 11.0


def measure(f: Path) -> dict:
    out = subprocess.run(
        ["ffmpeg", "-hide_banner", "-nostats", "-i", str(f),
         "-af", f"loudnorm=I={TARGET}:TP={PEAK}:LRA={LRA}:print_format=json", "-f", "null", "-"],
        capture_output=True, text=True, check=True).stderr
    return json.loads(re.findall(r"\{[^{}]*\}", out)[-1])


def normalize(f: Path) -> tuple[float, float] | None:
    m = measure(f)
    before = float(m["input_i"])
    if abs(before - TARGET) < 0.5:
        return None
    af = (f"loudnorm=I={TARGET}:TP={PEAK}:LRA={LRA}:linear=true"
          f":measured_I={m['input_i']}:measured_TP={m['input_tp']}:measured_LRA={m['input_lra']}"
          f":measured_thresh={m['input_thresh']}:offset={m['target_offset']}")
    with tempfile.TemporaryDirectory(dir=f.parent) as tmp:  # same drive, so the replace is a rename
        out = Path(tmp) / f.name
        subprocess.run(["ffmpeg", "-hide_banner", "-loglevel", "error", "-i", str(f), "-af", af,
                        "-ar", "44100", "-c:a", "libmp3lame", "-b:a", "128k", "-map_metadata", "-1", str(out)],
                       check=True)
        out.replace(f)
    return before, float(measure(f)["input_i"])


def main():
    folders = [Path(a) for a in sys.argv[1:]] or [ROOT / "assets/audio/conversation"]
    for folder in folders:
        for f in sorted(folder.rglob("*.mp3")):
            r = normalize(f)
            print(f"{f.relative_to(ROOT)}: " + (f"{r[0]:.1f} -> {r[1]:.1f} LUFS" if r else "already even"))


if __name__ == "__main__":
    main()
