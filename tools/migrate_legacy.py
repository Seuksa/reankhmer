"""Migrate the 2006 ReanKhmer (LearningKhmer) binary release into open content + assets.

Usage (needs `pip install access-parser`):
    python tools/migrate_legacy.py <path-to-LearningKhmer> [<path-to-decompiled-src>]

Outputs (relative to the repo root):
    content/*.json   curriculum data exported from reankhmer.mdb + hard-coded form texts
    assets/audio/**  MP3s with normalised names
    assets/images/** JPGs grouped by use
    legacy/**        original DB, help files, Flash animations (reference only)
"""
import json
import re
import shutil
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
SRC = Path(sys.argv[1]).resolve()
DECOMP = Path(sys.argv[2]).resolve() if len(sys.argv) > 2 else None
CONTENT = ROOT / "content"
ASSETS = ROOT / "assets"
LEGACY = ROOT / "legacy"


def slug(name: str) -> str:
    return re.sub(r"[^a-z0-9_.-]+", "-", name.strip().lower()).strip("-")


def copy(src: Path, dst: Path):
    dst.parent.mkdir(parents=True, exist_ok=True)
    shutil.copy2(src, dst)
    return dst.relative_to(ROOT).as_posix()


def write_json(name, data):
    CONTENT.mkdir(parents=True, exist_ok=True)
    (CONTENT / name).write_text(json.dumps(data, ensure_ascii=False, indent=2), encoding="utf-8")


# ---------------------------------------------------------------- database
def fix_jet_text(s):
    """access-parser mis-decodes Jet4 'compressed unicode' fields that mix ASCII
    and Khmer: Khmer code units come back as two latin-1 chars (lo, 0x17).
    Re-join them (Khmer block U+17xx, General Punctuation U+20xx)."""
    if s is None or "\x17" not in s:
        return s
    out, i = [], 0
    while i < len(s):
        c = ord(s[i])
        n = ord(s[i + 1]) if i + 1 < len(s) else None
        if n == 0x17 and c >= 0x80:
            out.append(chr(0x1700 + c)); i += 2; continue
        if n == 0x20 and c in (0x0B, 0x0C, 0x0D, 0x13, 0x14, 0x18, 0x19, 0x1C, 0x1D, 0x26):
            out.append(chr(0x2000 + c)); i += 2; continue
        out.append(s[i]); i += 1
    return "".join(out)


def load_db():
    from access_parser import AccessParser
    db = AccessParser(str(SRC / "reankhmer.mdb"))
    tables = {}
    for t in db.catalog:
        if t.startswith("MSys"):
            continue
        tb = db.parse_table(t)
        cols = list(tb.keys())
        n = len(tb[cols[0]]) if cols else 0
        tables[t] = [
            {c: fix_jet_text(str(tb[c][i]).replace("\r\n", "\n")) if tb[c][i] is not None else None for c in cols}
            for i in range(n)
        ]
    return tables


# ------------------------------------------------------------- alphabet
# Order = the 2006 Flash numbering (kor_1 ... or_33) = Unicode order minus obsolete U+179D/179E.
CONSONANTS = [
    # (romanised file stem, char, series 1=a-series/-or, 2=o-series/-ou)
    ("kor", "ក", 1), ("khor", "ខ", 1), ("kou", "គ", 2), ("khou", "ឃ", 2), ("ngou", "ង", 2),
    ("chor", "ច", 1), ("chhor", "ឆ", 1), ("chou", "ជ", 2), ("chhou", "ឈ", 2), ("nhou", "ញ", 2),
    ("dor", "ដ", 1), ("thor_siam", "ឋ", 1), ("dou_siem", "ឌ", 2), ("thou_siam", "ឍ", 2), ("nor", "ណ", 1),
    ("tor", "ត", 1), ("thor", "ថ", 1), ("tou", "ទ", 2), ("thou", "ធ", 2), ("nou", "ន", 2),
    ("bor", "ប", 1), ("phor", "ផ", 1), ("pou", "ព", 2), ("phou", "ភ", 2), ("mou", "ម", 2),
    ("you", "យ", 2), ("rou", "រ", 2), ("lou", "ល", 2), ("vou", "វ", 2), ("sor", "ស", 1),
    ("hor", "ហ", 1), ("lor", "ឡ", 1), ("or", "អ", 1),
]
# Dependent vowels in traditional teaching order; index = number in the 2006 file names.
# Verified against images/test/Vowels (a.jpg = ា, 2.jpg = ិ). Romanisation hints still need native review.
VOWELS = ["", "ា", "ិ", "ី", "ឹ", "ឺ", "ុ", "ូ", "ួ", "ើ", "ឿ", "ៀ", "េ", "ែ", "ៃ", "ោ", "ៅ",
          "ុំ", "ំ", "ាំ", "ះ", "ិះ", "ុះ", "េះ", "ោះ"]
AUDIO_SWAP = {1: 2, 2: 1, 10: 11, 11: 10}
# o-series (Vowels_Ou) only, confirmed by a native speaker: ះ = file 22, ិះ = file 20, ុះ = file 21.
AUDIO_SWAP_SERIES2 = {**AUDIO_SWAP, 20: 22, 21: 20, 22: 21}
NUMBERS = {"zero": 0, "one": 1, "two": 2, "three": 3, "four": 4, "five": 5, "six": 6, "seven": 7,
           "eight": 8, "nine": 9, "ten": 10, "twenty": 20, "thirty": 30, "forty": 40, "fifty": 50,
           "sixty": 60, "seventy": 70, "eighty": 80, "ninety": 90, "onehundred": 100, "hundred": 100,
           "thousand": 1000, "ten thousand": 10000, "hundred_thousand": 100000, "million": 1000000}
KHMER_DIGITS = "០១២៣៤៥៦៧៨៩"


def migrate_alphabet(tables):
    latin = {r["t_name"]: r["t_latin"] for r in tables["tblTestLevel"] if r["type"] == "1"}
    flash = SRC / "flash"
    out = []
    for i, (stem, ch, series) in enumerate(CONSONANTS, 1):
        img_name = {"dou_siem": "dou"}.get(stem, stem)
        test_name = {"dou_siem": "dou"}.get(stem, stem)
        item = {"id": i, "char": ch, "name": stem.split("_")[0], "series": series,
                "roman": latin.get(test_name, stem.capitalize())}
        a = flash / "Consonants" / f"{stem}.mp3"
        if a.exists():
            item["audio"] = copy(a, ASSETS / "audio/consonants" / f"{i:02d}-{slug(stem)}.mp3")
        alt = flash / "Consonants" / f"{stem} 1.mp3"
        if alt.exists():
            item["audio_alt"] = copy(alt, ASSETS / "audio/consonants" / f"{i:02d}-{slug(stem)}-alt.mp3")
        img = SRC / "images/test" / f"{img_name}.jpg"
        if img.exists():
            item["image"] = copy(img, ASSETS / "images/letters" / f"{i:02d}-{slug(stem)}.jpg")
        swf = next(iter(flash.glob(f"*_{i}.swf")), None)
        if swf:
            item["legacy_swf"] = f"legacy/flash/{swf.name}"
        out.append(item)
    write_json("consonants.json", out)

    vowels = []
    for n, v in enumerate(VOWELS):
        item = {"id": n, "sign": v, "with_series1": "អ" + v, "with_series2": "អូ" if n == 0 else None,
                "needs_review": True}
        for series, folder in ((1, "Vowels_Or"), (2, "Vowels_Ou")):
            # 2006 audio numbering swaps 1<->2 (ar_2 = ា, i_1 = ិ) and 10<->11 (eur_11 = ឿ, air_10 = ៀ,
            # confirmed by a native speaker); images follow teaching order.
            swap = AUDIO_SWAP_SERIES2 if series == 2 else AUDIO_SWAP
            f = next(iter((flash / "vowels" / folder).glob(f"*_{ swap.get(n, n) }.mp3")), None)
            if f:
                item[f"audio_series{series}"] = copy(f, ASSETS / f"audio/vowels/series{series}" / f"{n:02d}-{slug(f.stem.rsplit('_', 1)[0])}.mp3")
                item.setdefault("roman_hint", f.stem.rsplit("_", 1)[0])
        img = SRC / "images/test/Vowels" / ("a.jpg" if n == 1 else f"{n}.jpg")
        if n and img.exists():
            item["image"] = copy(img, ASSETS / "images/vowels" / f"{n:02d}.jpg")
        vowels.append(item)
    write_json("vowels.json", vowels)

    nums = []
    for f in sorted((flash / "Numbers").glob("*.mp3")):
        key = f.stem
        entry = {"key": slug(key), "audio": copy(f, ASSETS / "audio/numbers" / f"{slug(key)}.mp3")}
        if key in NUMBERS:
            entry["value"] = NUMBERS[key]
            if NUMBERS[key] < 10:
                entry["digit"] = KHMER_DIGITS[NUMBERS[key]]
        nums.append(entry)
    write_json("numbers.json", sorted(nums, key=lambda e: e.get("value", 10**9)))


# ------------------------------------------------------------ curriculum
def migrate_curriculum(tables):
    sp_root = SRC / "flash/spelling/Spelling"
    spelling_dirs = {}
    for d in sp_root.iterdir():
        m = re.search(r"(\d+)$", d.name)
        if d.is_dir() and m:
            spelling_dirs[int(m.group(1))] = d

    tests = {}
    for t in tables["tblTest"]:
        tests.setdefault(t["les_id"], []).append({"id": int(t["test_id"]), "order": int(t["rang"]),
                                                   "question": t["question"], "choices": []})
    by_tid = {q["id"]: q for qs in tests.values() for q in qs}
    for r in tables["tblTest_res"]:
        by_tid[int(r["test_id"])]["choices"].append({"text": r["answer"], "correct": r["check"] == "1"})

    subs = {}
    for s in tables["tblSubLesson"]:
        subs.setdefault(s["les_id"], []).append(s)

    chapters = []
    for ch in sorted(tables["tblChapter"], key=lambda r: int(r["ch_num"])):
        lessons = []
        for les in sorted((l for l in tables["tblLesson"] if l["ch_id"] == ch["ch_id"]), key=lambda l: int(l["les_num"])):
            L = {"id": int(les["les_id"]), "number": int(les["les_num"]), "title": les["les_title"]}
            if les["article"]:
                L["article"] = les["article"]
            if les["vocabulary"]:
                L["vocabulary"] = [w.strip(" ។") for w in les["vocabulary"].split(",") if w.strip(" ។")]
            items = []
            for s in sorted(subs.get(les["les_id"], []), key=lambda s: int(s["sub_les_id"])):
                it = {}
                fn = s["filename"] or ""
                if fn.endswith(".swf"):
                    it["legacy_swf"] = f"legacy/flash/{'spelling/' if 'spelling' in fn else ''}{fn}"
                elif fn.startswith("con_"):
                    p = SRC / "images/conversation" / fn
                    if p.exists():
                        it["image"] = copy(p, ASSETS / "images/conversation" / slug(fn))
                elif fn:
                    p = SRC / "images" / fn
                    if not p.exists():
                        p = next(iter((SRC / "images").glob(Path(fn).stem + ".*")), p)
                    if p.exists():
                        it["image"] = copy(p, ASSETS / "images/reading" / slug(p.name))
                if s["desc"] and s["desc"] != "dfadfa":
                    it["text"] = s["desc"]
                    m = re.match(r"^([A-D])-\s*(.*)$", s["desc"], re.S)
                    if m:
                        it["speaker"], it["text"] = m.group(1), m.group(2)
                if s["getSound"]:
                    p = SRC / "conversation" / f"{s['getSound']}.mp3"
                    if p.exists():
                        it["audio"] = copy(p, ASSETS / "audio/conversation" / f"{slug(s['getSound'])}.mp3")
                if it:
                    items.append(it)
            if items:
                L["items"] = items
            # spelling chapters: audio per lesson (ch2 -> folders 1..5, ch3 -> 6..9)
            if ch["ch_num"] in ("2", "3"):
                idx = L["number"] + (5 if ch["ch_num"] == "3" else 0)
                d = spelling_dirs.get(idx)
                if d:
                    words = []
                    for f in sorted(d.glob("*.mp3")):
                        rel = copy(f, ASSETS / f"audio/spelling/lesson{idx:02d}" / slug(f.name))
                        if f.stem.startswith("example"):
                            L["article_audio"] = rel
                        else:
                            words.append({"key": re.sub(r"_les\d+$", "", f.stem), "audio": rel})
                    L["word_audio"] = words  # TODO: pair each key with its Khmer word
            if ch["ch_num"] == "4" and les["getLink"]:
                p = SRC / "reading" / f"{les['getLink']}.mp3"
                if p.exists():
                    L["article_audio"] = copy(p, ASSETS / "audio/reading" / p.name)
            if les["les_id"] in tests:
                L["quiz"] = sorted(tests[les["les_id"]], key=lambda q: q["order"])
            lessons.append(L)
        chapters.append({"number": int(ch["ch_num"]), "title": ch["ch_title"].rstrip(","),
                         "intro": ch["ch_desc"], "lessons": lessons})
    write_json("chapters.json", chapters)

    write_json("dictionary.json", [{"id": int(r["ID"]), "word": r["Word"], "meaning": r["Meaning"]}
                                   for r in tables["tblDictionary"]])
    write_json("phrases.json", [{"id": int(r["phrase_id"]), "khmer": r["phrase"], "english": r["meaning"]}
                                for r in tables["tblPhrase"]])
    # A 5th dialogue (con_les4_1..10) has audio but no text in the DB: keep it for re-transcription.
    for f in (SRC / "conversation").glob("con_les4_*.mp3"):
        copy(f, ASSETS / "audio/conversation/untranscribed" / slug(f.name))
    for extra in ("people.mp3",):
        p = SRC / "reading" / extra
        if p.exists():
            copy(p, ASSETS / "audio/reading" / extra)


# --------------------------------------------- texts hard-coded in WinForms
def extract_switch_texts(cs: Path, combo: str, target: str):
    code = cs.read_text(encoding="utf-8")
    titles = [json.loads('"' + t + '"') for t in
              re.findall(r'(?:comboBox\.Items|items)\.Add\("((?:[^"\\]|\\.)*)"\)', code)]
    body = code.split(f"private void {combo}_SelectedIndexChanged", 1)[1]
    cases = re.findall(r"case (\d+):\s*(?:[^\n]*\n\s*)??" + re.escape(target) + r'\.Text = "((?:[^"\\]|\\.)*)";', body)
    texts = {int(n): json.loads('"' + t + '"').replace("\r\n", "\n") for n, t in cases}
    return [{"id": i, "title": titles[i] if i < len(titles) else None, "text": texts.get(i)} for i in sorted(texts)]


def migrate_texts():
    if not DECOMP:
        return
    forms = DECOMP / "reankhmer"
    write_json("grammar.json", extract_switch_texts(forms / "frmGrammar.cs", "cboGrammar", "txtGrammar"))
    write_json("script-notes.json", extract_switch_texts(forms / "frmKhmerLanguage.cs", "cboKhmer", "txtIntro"))
    dst = LEGACY / "decompiled-src"
    if dst.exists():
        shutil.rmtree(dst)
    shutil.copytree(DECOMP, dst, ignore=shutil.ignore_patterns("*.ico"))


# ------------------------------------------------------------ the rest
def migrate_misc():
    groups = {"ui": ["conversation.jpg", "dictionary.jpg", "drawing.jpg", "game.jpg", "grammar.jpg", "help.JPG",
                     "help_1.jpg", "key.JPG", "speaker.JPG", "speaker.png"],
              "team": ["tn_davy.jpg", "tn_leaksmy.jpg", "tn_metrey.jpg", "heinrich.JPG", "rupp_logo.JPG"],
              "photos": ["cambodia1.JPG", "cambodia2.JPG", "landscap_1.jpg", "landscap_2.jpg", "wat1.JPG",
                         "wat2.JPG", "people1.jpg", "people2.jpg", "rupp.JPG", "students.JPG"]}
    for g, names in groups.items():
        for n in names:
            if (SRC / "images" / n).exists():
                copy(SRC / "images" / n, ASSETS / "images" / g / slug(n))
    for f in (SRC / "images").glob("*"):
        if f.is_file() and re.match(r"^(\d+|image\d+)\.", f.name, re.I):
            copy(f, ASSETS / "images/splash" / slug(f.name))
    copy(SRC / "support/installHelp/khmerKeyboard.jpg", ASSETS / "images/ui/khmer-keyboard-2006.jpg")
    copy(SRC / "flash/reankhmer_start_1.mp3", ASSETS / "audio/ui/start.mp3")
    for f in (SRC / "flash").rglob("*.swf"):
        copy(f, LEGACY / "flash" / f.relative_to(SRC / "flash"))
    for f in list((SRC / "help").glob("*.rtf")) + [SRC / "readme.rtf", SRC / "README.md", SRC / "LICENSE"]:
        copy(f, LEGACY / "help" / f.name)
    copy(SRC / "reankhmer.mdb", LEGACY / "reankhmer.mdb")
    copy(SRC / "reankhmer.ico", ASSETS / "images/ui/reankhmer.ico")


if __name__ == "__main__":
    tables = load_db()
    write_json("_raw-db.json", tables)
    migrate_alphabet(tables)
    migrate_curriculum(tables)
    migrate_texts()
    migrate_misc()
    print("done")
