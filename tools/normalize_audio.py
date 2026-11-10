"""Repair and even out the 2006 dialogue and reading recordings, in place under assets/.

Two faults in the originals:
1. Phase: in 43 of 44 dialogue clips and all 3 reading texts the right channel is the left one
   upside down. Stereo speakers play them fine, but anything that mixes to mono (iPhone, many
   laptops, VLC on some setups) adds the two and the voice cancels out to near silence.
   Fix: when the difference L-R is clearly louder than the sum L+R, keep (L-R)/2 as mono.
2. Level: the clips were recorded from -27 to -15 LUFS. Fix: two-pass ffmpeg loudnorm to TARGET
   with a true-peak ceiling.

Run it on the untouched originals (the LearningKhmer release, as copied by migrate_legacy.py);
re-running on already repaired files is harmless (mono, already even -> skipped).

Usage (needs ffmpeg on PATH):
    python tools/normalize_audio.py [folder ...]   default: assets/audio/conversation, assets/audio/reading
"""
import json
import re
import subprocess
import sys
import tempfile
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
TARGET, PEAK, LRA = -16.0, -1.5, 11.0
DEFAULT = [ROOT / "assets/audio/conversation", ROOT / "assets/audio/reading"]


def ffmpeg_err(*args: str) -> str:
    return subprocess.run(["ffmpeg", "-hide_banner", "-nostats", *args], capture_output=True, text=True, check=True).stderr


def channels(f: Path) -> int:
    out = subprocess.run(["ffprobe", "-v", "error", "-select_streams", "a:0", "-show_entries", "stream=channels",
                          "-of", "csv=p=0", str(f)], capture_output=True, text=True, check=True).stdout
    return int(out.strip())


def mean_db(f: Path, mix: str) -> float:
    m = re.search(r"mean_volume: (-?[\d.]+|-inf) dB", ffmpeg_err("-i", str(f), "-af", f"pan=mono|c0={mix},volumedetect", "-f", "null", "-"))
    return -200.0 if m is None or m.group(1) == "-inf" else float(m.group(1))


def downmix(f: Path) -> tuple[str, str]:
    """The pan filter that gives a mono voice, and a label for the report."""
    if channels(f) == 1:
        return "", "mono"
    s, d = mean_db(f, "0.5*c0+0.5*c1"), mean_db(f, "0.5*c0-0.5*c1")
    return ("pan=mono|c0=0.5*c0-0.5*c1,", "phase fixed") if d - s > 6 else ("pan=mono|c0=0.5*c0+0.5*c1,", "stereo->mono")


def loudnorm(f: Path, pre: str) -> dict:
    out = ffmpeg_err("-i", str(f), "-af", f"{pre}loudnorm=I={TARGET}:TP={PEAK}:LRA={LRA}:print_format=json", "-f", "null", "-")
    return json.loads(re.findall(r"\{[^{}]*\}", out)[-1])


def repair(f: Path) -> str:
    pre, label = downmix(f)
    m = loudnorm(f, pre)
    before = float(m["input_i"])
    if not pre and abs(before - TARGET) < 0.5:
        return "already fine"
    af = (f"{pre}loudnorm=I={TARGET}:TP={PEAK}:LRA={LRA}:linear=true"
          f":measured_I={m['input_i']}:measured_TP={m['input_tp']}:measured_LRA={m['input_lra']}"
          f":measured_thresh={m['input_thresh']}:offset={m['target_offset']}")
    with tempfile.TemporaryDirectory(dir=f.parent) as tmp:  # same drive, so the replace is a rename
        out = Path(tmp) / f.name
        subprocess.run(["ffmpeg", "-hide_banner", "-loglevel", "error", "-i", str(f), "-af", af, "-ac", "1",
                        "-ar", "44100", "-c:a", "libmp3lame", "-b:a", "96k", "-map_metadata", "-1", str(out)], check=True)
        out.replace(f)
    after = float(loudnorm(f, "")["input_i"])
    return f"{label}, {before:.1f} -> {after:.1f} LUFS"


def main():
    for folder in [Path(a) for a in sys.argv[1:]] or DEFAULT:
        for f in sorted(folder.rglob("*.mp3")):
            print(f"{f.relative_to(ROOT)}: {repair(f)}", flush=True)


if __name__ == "__main__":
    main()
