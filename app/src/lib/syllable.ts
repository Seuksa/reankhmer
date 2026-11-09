// How a built syllable reads: its series, simple romanization and (once recorded) its audio.
// Rules and spellings live in content/romanization.json so a teacher can review them in one place.
import romJson from '../../../content/romanization.json';
import syllablesJson from '../../../content/syllables.json';
import type { Consonant, Vowel } from './content';

const rom = romJson as {
  initials: Record<string, string>; vowels: Record<string, string[]>; sonorants: number[];
  subscript: { word: string; roman: string; audio: string };
};

/** A subscript is read aloud as ជើង ("cherng") + the letter's name: ្ញ = "cherng nhou". */
export const SUBSCRIPT = rom.subscript;
const sonorants = new Set(rom.sonorants);

/** A cluster takes the subscript's series, unless the subscript is a sonorant (then the head's). */
export function seriesOf(c: Consonant, sub: Consonant | null): 1 | 2 {
  return sub && !sonorants.has(sub.id) ? sub.series : c.series;
}

export const initialOf = (c: Consonant) => rom.initials[c.id] ?? '';
export const vowelRoman = (v: Vowel, s: 1 | 2) => rom.vowels[v.id]?.[s - 1] ?? '';

export function romanOf(c: Consonant, sub: Consonant | null, v: Vowel): string {
  return initialOf(c) + (sub ? initialOf(sub) : '') + vowelRoman(v, seriesOf(c, sub));
}

// Basic syllables (no subscript) that already have a recording, keyed "consonant-vowel".
const recorded = new Map(
  (syllablesJson as { consonant: number; vowel: number; audio: string | null }[])
    .filter((s) => s.audio)
    .map((s) => [`${s.consonant}-${s.vowel}`, `/${s.audio}`]),
);

export function syllableAudio(c: Consonant, sub: Consonant | null, v: Vowel): string | undefined {
  return sub ? undefined : recorded.get(`${c.id}-${v.id}`);
}

export const recordedSyllableMedia = () => [...new Set(recorded.values())];
