// Builds the 825 basic syllables (33 consonants × 25 vowels, no subscript) from the content package:
//   content/syllables.json            – what the app reads (text, series, romanization, audio if recorded)
//   content/recording/syllables.csv   – the recording sheet (opens in Excel / Google Sheets)
// Recordings go in assets/audio/syllables/<consonant>-<vowel>.mp3, e.g. 02-01.mp3 = ខា.
// Re-run after adding recordings (npm run syllables); the app then plays them.
import { existsSync, mkdirSync, readFileSync, writeFileSync } from 'node:fs';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

const root = resolve(dirname(fileURLToPath(import.meta.url)), '../..');
const read = (p) => JSON.parse(readFileSync(resolve(root, p), 'utf8'));
const consonants = read('content/consonants.json');
const vowels = read('content/vowels.json');
const rom = read('content/romanization.json');

const pad = (n) => String(n).padStart(2, '0');
const rows = [];
for (const c of consonants) {
  for (const v of vowels) {
    const id = `${pad(c.id)}-${pad(v.id)}`;
    const file = `assets/audio/syllables/${id}.mp3`;
    const recorded = existsSync(resolve(root, file));
    // With no vowel sign the syllable is the letter's own name, which is already recorded.
    const letterClip = v.id === 0 && c.audio ? c.audio : null;
    rows.push({
      id,
      text: c.char + v.sign,
      consonant: c.id,
      vowel: v.id,
      series: c.series,
      roman: rom.initials[c.id] + rom.vowels[v.id][c.series - 1],
      audio: recorded ? file : letterClip,
      _file: file,
      _status: recorded ? 'recorded' : letterClip ? 'letter clip used (optional)' : 'to record',
    });
  }
}

writeFileSync(
  resolve(root, 'content/syllables.json'),
  JSON.stringify(rows.map(({ _file, _status, ...r }) => r), null, 0).replace(/},{/g, '},\n{') + '\n',
);

const csv = (s) => (/[",\n]/.test(String(s)) ? `"${String(s).replace(/"/g, '""')}"` : String(s));
const name = Object.fromEntries(consonants.map((c) => [c.id, c]));
const vow = Object.fromEntries(vowels.map((v) => [v.id, v]));
const lines = [
  ['no', 'file', 'syllable', 'spelling', 'roman', 'series', 'consonant', 'status'].join(','),
  ...rows.map((r, i) => [
    i + 1,
    r._file.split('/').pop(),
    r.text,
    `${name[r.consonant].char} + ${vow[r.vowel].sign ? '◌' + vow[r.vowel].sign : '(no sign)'}`,
    r.roman,
    r.series === 1 ? 'a (អ)' : 'o (អូ)',
    name[r.consonant].name,
    r._status,
  ].map(csv).join(',')),
];
mkdirSync(resolve(root, 'content/recording'), { recursive: true });
// BOM so Excel opens the Khmer text as UTF-8.
writeFileSync(resolve(root, 'content/recording/syllables.csv'), '﻿' + lines.join('\r\n') + '\r\n');

const count = (s) => rows.filter((r) => r._status === s).length;
console.log(`${rows.length} syllables: ${count('recorded')} recorded, ${count('to record')} to record, ${count('letter clip used (optional)')} use the letter clip`);
