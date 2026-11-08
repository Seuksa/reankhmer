# ReanKhmer (រៀនខ្មែរ)

A new home for **ReanKhmer**, the Khmer learning course first released in 2006 at the
Royal University of Phnom Penh Science Fair ([original binaries](https://github.com/metrey/LearningKhmer), MIT).

## Credits

- **Sok Pongsametrey** — all content, project lead and management (2006 and today).
- **Audio** — recorded in 2006 at the CSC Cambodia studio, where the project was part of Sok Pongsametrey's
  work, with his colleagues there.
- **Platform and Flash development** — Sok Pongsametrey, Sok Leaksmy, Ouk Sidavy · RUPP Science Fair 2006.

The 2006 app was a VB.NET + Flash 8 + Access program for Windows XP. Its source was lost, but the
exe decompiles cleanly, and all lesson data and ~300 native-speaker recordings were recovered.
This folder holds that material in an open, app-independent format, ready for a new web app.

Analysis and recommendations: https://claude.ai/artifact/6mXdHvT7vQSe4WgRn9wXAK

## Layout

| Path | What |
| --- | --- |
| `content/consonants.json` | 33 consonants: char, series, romanisation, audio, glyph image |
| `content/vowels.json` | 24 dependent vowels + inherent vowel, audio for both series |
| `content/numbers.json` | Number words with audio |
| `content/chapters.json` | 5 chapters / 21 lessons: rules, stories, vocabulary, dialogue lines, quizzes |
| `content/dictionary.json`, `phrases.json` | 43 dictionary entries, 8 typing-game phrases |
| `content/grammar.json`, `script-notes.json` | 13 grammar notes, 12 notes on the writing system |
| `content/_raw-db.json` | Unmodified export of every table in `reankhmer.mdb` (for audits) |
| `assets/audio/**` | MP3s, renamed to `NN-name.mp3` |
| `assets/images/**` | Letter/vowel glyphs, dialogue pictures, photos, 2006 UI art |
| `legacy/` | Original DB, help files, 71 Flash `.swf`, decompiled C# — reference only |
| `tools/migrate_legacy.py` | Re-runs the whole export from `../LearningKhmer` |

## The web app (`app/`)

Offline-first PWA at **https://rean.seuksa.com** — Astro 7 + Vue 3 islands + Tailwind 4, same fonts as seuksa.com.
Bilingual Khmer–English UI (toggle: both / ខ្មែរ / EN), progress kept on the device (IndexedDB) with backup/restore as a JSON file.

```sh
cd app
npm install
npm run dev      # http://localhost:4321 (copies ../assets into public/assets first)
npm run build    # static site in app/dist, service worker included
npm run preview  # test the PWA and offline mode
```

| Page | What |
| --- | --- |
| `/letters` | 33 consonants coloured by series, tap to hear, "Listen & find" game |
| `/vowels` | every vowel after ក (a-series) and គ (o-series), both recordings |
| `/numbers` | number words with audio |
| `/typing` | NiDA (KhmerOS) typing trainer: 9 lessons, on-screen keyboard, 2-minute game; no Khmer keyboard install needed |
| `/lessons/{chapter}/{lesson}` | 21 lessons: stories with audio, vocabulary, dialogue player, quizzes |
| `/progress` | stats, backup/restore, "download for offline" per chapter |

Deploy: push to GitHub; `.github/workflows/deploy.yml` builds `app/` and publishes to Pages.
DNS: add a `CNAME` record `rean` → `<github-user>.github.io` on seuksa.com, then set the custom
domain in the repo's Pages settings (the build already ships `CNAME`).

## Re-running the export

```sh
python -m venv .venv && .venv/Scripts/pip install access-parser
dotnet tool install ilspycmd --version 8.2.0.7535 --tool-path .tools
.tools/ilspycmd -p -o .decomp ../LearningKhmer/reankhmer.exe
.venv/Scripts/python tools/migrate_legacy.py ../LearningKhmer .decomp
```

## Known gaps

- `vowels.json` romanisation hints come from 2006 file names and need native review.
- Spelling word audio (`word_audio`) is keyed by romanised file name; each still needs its Khmer word.
- `assets/audio/conversation/untranscribed/` holds a 10-line dialogue with no text in the DB.
- The "Khmer Language" notes and the Sally Morris dialogues may come from a published textbook;
  confirm their origin before publishing.
- Photos in `assets/images/photos` and `team` have unknown or personal rights; treat as placeholders.
