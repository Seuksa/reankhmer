// Typed access to the shared content package (../../content). The app never edits it.
import consonantsJson from '../../../content/consonants.json';
import vowelsJson from '../../../content/vowels.json';
import numbersJson from '../../../content/numbers.json';
import chaptersJson from '../../../content/chapters.json';
import dictionaryJson from '../../../content/dictionary.json';
import phrasesJson from '../../../content/phrases.json';

export interface Consonant {
  id: number; char: string; name: string; series: 1 | 2; roman: string;
  audio?: string; audio_alt?: string; image?: string; legacy_swf?: string;
}
export interface Vowel {
  id: number; sign: string; roman_hint?: string; audio_series1?: string; audio_series2?: string;
}
export interface NumberWord { key: string; audio: string; value?: number; digit?: string }
export interface Choice { text: string; correct: boolean }
export interface Question { id: number; order: number; question: string; choices: Choice[] }
export interface Item { image?: string; text?: string; speaker?: string; audio?: string; legacy_swf?: string }
export interface Lesson {
  id: number; number: number; title: string; article?: string; vocabulary?: string[];
  items?: Item[]; article_audio?: string; word_audio?: { key: string; audio: string }[]; quiz?: Question[];
}
export interface Chapter { number: number; title: string; intro: string; lessons: Lesson[] }
export interface Bi { km: string; en: string }

export const consonants = consonantsJson as Consonant[];
export const vowels = vowelsJson as Vowel[];
export const numbers = numbersJson as NumberWord[];
export const chapters = chaptersJson as Chapter[];
export const phrases = phrasesJson as { id: number; khmer: string; english: string }[];
export const dictionary = new Map((dictionaryJson as { word: string; meaning: string }[]).map((d) => [d.word, d.meaning]));

/** Content paths are repo-relative ("assets/audio/…"); the app serves them from /assets. */
export const asset = (p?: string) => (p ? `/${p}` : undefined);

const KHMER_DIGITS = '០១២៣៤៥៦៧៨៩';
export const khmerDigits = (n: number | string) => String(n).replace(/\d/g, (d) => KHMER_DIGITS[+d]);

export const CHAPTER_TITLE: Record<number, Bi> = {
  1: { km: 'ព្យញ្ជនៈ និង ស្រៈ', en: 'Consonants & vowels' },
  2: { km: 'ការប្រកបពាក្យ', en: 'Spelling with final consonants' },
  3: { km: 'ជើងអក្សរ', en: 'Subscript consonants' },
  4: { km: 'អំណាន', en: 'Reading' },
  5: { km: 'សន្ទនា', en: 'Conversation' },
};

/** Khmer vowel signs are shown on a dotted circle (◌) when written alone. */
export const onCircle = (sign: string) => (sign ? `◌${sign}` : '◌');

const ZWSP = /​/g;
export function lessonTitle(ch: number, les: Lesson): Bi {
  const t = les.title.replace(ZWSP, '').trim();
  if (ch === 1) {
    const letters = t.replace(/^Consonants\s*\(|\)$/g, '').replace(/,\s*/g, ' ').trim();
    return { km: `ព្យញ្ជនៈ ${letters}`, en: `Consonants ${letters}` };
  }
  if (ch === 2) {
    // 2006 wrote "[ ] ក" for "any consonant + final ក"; the standard notation is a dotted circle.
    const s = t.replace(/\[\s*\]\s*/g, '◌');
    return { km: s.replace(/\s+and\s+/g, ' និង '), en: `Final consonants: ${s}` };
  }
  if (ch === 3) return { km: `ជើងអក្សរ ${t}`, en: `Subscripts: ${t}` };
  const m = t.match(/^(.*?)\s*\(([^()]*)\)\s*$/);
  return m ? { km: m[1], en: m[2] } : { km: t, en: t };
}

export function lessonLetters(les: Lesson): Consonant[] {
  const swfs = new Set((les.items ?? []).map((i) => i.legacy_swf));
  return consonants.filter((c) => swfs.has(c.legacy_swf));
}

export const lessonHref = (ch: number, n: number) => `/lessons/${ch}/${n}`;

/** Every media file a chapter needs, for "download for offline". */
export function chapterMedia(ch: Chapter): string[] {
  const urls = new Set<string>();
  const add = (p?: string) => p && urls.add(`/${p}`);
  for (const les of ch.lessons) {
    add(les.article_audio);
    les.word_audio?.forEach((w) => add(w.audio));
    les.items?.forEach((i) => { add(i.audio); add(i.image); });
    if (ch.number === 1) lessonLetters(les).forEach((c) => { add(c.audio); add(c.image); });
  }
  return [...urls];
}

export function alphabetMedia(): string[] {
  const urls: (string | undefined)[] = [
    ...consonants.flatMap((c) => [c.audio, c.audio_alt, c.image]),
    ...vowels.flatMap((v) => [v.audio_series1, v.audio_series2]),
    ...numbers.map((n) => n.audio),
  ];
  return urls.filter(Boolean).map((p) => `/${p}`);
}
