// NiDA Khmer Unicode keyboard (the KhmerOS standard; Windows "Khmer (NIDA)").
// Each key: physical KeyboardEvent.code, the Latin label, and what it types without / with Shift.
// The trainer turns physical keys into these characters, so learners need no Khmer keyboard installed.

export interface TypingLesson { id: string; km: string; en: string; kind: 'drill' | 'text'; items: string[] }
export interface KeyDef { code: string; latin: string; normal: string; shift: string }

const k = (code: string, latin: string, normal: string, shift: string): KeyDef => ({ code, latin, normal, shift });

export const ROWS: KeyDef[][] = [
  [
    k('Backquote', '`', '«', '»'), k('Digit1', '1', '១', '!'), k('Digit2', '2', '២', 'ៗ'), k('Digit3', '3', '៣', '"'),
    k('Digit4', '4', '៤', '៛'), k('Digit5', '5', '៥', '%'), k('Digit6', '6', '៦', '៍'), k('Digit7', '7', '៧', '័'),
    k('Digit8', '8', '៨', '៏'), k('Digit9', '9', '៩', '('), k('Digit0', '0', '០', ')'), k('Minus', '-', 'ឥ', '៌'),
    k('Equal', '=', 'ឲ', '='),
  ],
  [
    k('KeyQ', 'Q', 'ឆ', 'ឈ'), k('KeyW', 'W', 'ឹ', 'ឺ'), k('KeyE', 'E', 'េ', 'ែ'), k('KeyR', 'R', 'រ', 'ឬ'),
    k('KeyT', 'T', 'ត', 'ទ'), k('KeyY', 'Y', 'យ', 'ួ'), k('KeyU', 'U', 'ុ', 'ូ'), k('KeyI', 'I', 'ិ', 'ី'),
    k('KeyO', 'O', 'ោ', 'ៅ'), k('KeyP', 'P', 'ផ', 'ភ'), k('BracketLeft', '[', 'ៀ', 'ឿ'), k('BracketRight', ']', 'ឪ', 'ឧ'),
    k('Backslash', '\\', 'ឮ', 'ឭ'),
  ],
  [
    k('KeyA', 'A', 'ា', 'ាំ'), k('KeyS', 'S', 'ស', 'ៃ'), k('KeyD', 'D', 'ដ', 'ឌ'), k('KeyF', 'F', 'ថ', 'ធ'),
    k('KeyG', 'G', 'ង', 'អ'), k('KeyH', 'H', 'ហ', 'ះ'), k('KeyJ', 'J', '្', 'ញ'), k('KeyK', 'K', 'ក', 'គ'),
    k('KeyL', 'L', 'ល', 'ឡ'), k('Semicolon', ';', 'ើ', 'ោះ'), k('Quote', "'", '់', '៉'),
  ],
  [
    k('KeyZ', 'Z', 'ឋ', 'ឍ'), k('KeyX', 'X', 'ខ', 'ឃ'), k('KeyC', 'C', 'ច', 'ជ'), k('KeyV', 'V', 'វ', 'េះ'),
    k('KeyB', 'B', 'ប', 'ព'), k('KeyN', 'N', 'ន', 'ណ'), k('KeyM', 'M', 'ម', 'ំ'), k('Comma', ',', 'ុំ', 'ុះ'),
    k('Period', '.', '។', '៕'), k('Slash', '/', '៊', '?'),
  ],
];

export const KEYS = new Map(ROWS.flat().map((d) => [d.code, d]));

export interface Stroke { out: string; code: string; shift: boolean }
const BY_OUTPUT = new Map<string, Stroke>();
for (const d of ROWS.flat()) {
  BY_OUTPUT.set(d.shift, { out: d.shift, code: d.code, shift: true });
  BY_OUTPUT.set(d.normal, { out: d.normal, code: d.code, shift: false }); // normal layer wins on duplicates
}
BY_OUTPUT.set(' ', { out: ' ', code: 'Space', shift: false });

const ZWSP = /[​‌‍]/g;

/** Splits text into the keystrokes a NiDA typist presses (longest key output first). */
export function strokes(text: string): Stroke[] | null {
  const s = text.replace(ZWSP, '');
  const out: Stroke[] = [];
  for (let i = 0; i < s.length; ) {
    const two = BY_OUTPUT.get(s.slice(i, i + 2));
    const one = BY_OUTPUT.get(s[i]);
    const hit = two ?? one;
    if (!hit) return null; // character not on the keyboard (Latin, rare signs): skip this text
    out.push(hit);
    i += hit.out.length;
  }
  return out;
}

/** What a key press types: the OS Khmer layout's character if one is active, else NiDA emulation. */
export function typed(e: KeyboardEvent): string | null {
  if (e.ctrlKey || e.metaKey || e.altKey) return null;
  if (e.code === 'Space') return ' ';
  if (/[ក-៿«»]/.test(e.key)) return e.key;
  const d = KEYS.get(e.code);
  return d ? (e.shiftKey ? d.shift : d.normal) : null;
}

/** Combining signs are shown on a dotted circle so they are visible on their own. */
export const display = (ch: string) => (/^[ា-៓៝]/.test(ch) ? `◌${ch}` : ch);
