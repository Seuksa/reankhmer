// Turns a typed number into the word clips that say it, following the 2006 ReadNum.swf rules:
// left to right, each non-zero digit is said with its place word (១២៥០ = one thousand · two hundred · fifty),
// the tens place uses twenty…ninety (១១ = ten one, ដប់មួយ) and zeros are silent.
// Beyond 2006: numbers past a million are split at the million (១២ លាន = ten two million),
// leading zeros after the point are read (3.05 = three point zero five, not 3.5), and a trailing % adds ភាគរយ.
// The point is said ចុច.

const DIGIT = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];
const TENS = ['', 'ten', 'twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'];
const PLACE: Record<number, string> = { 3: 'hundred', 4: 'thousand', 5: 'ten-thousand', 6: 'hundred_thousand' };

export const MAX_INT_DIGITS = 12; // up to 999,999 million (Khmer: …ពាន់លាន)
export const MAX_FRACTION_DIGITS = 6;

const KHMER_DIGITS = '០១២៣៤៥៦៧៨៩';

/** Accepts Latin or Khmer digits, spaces and thousands commas; returns "-123.45" form or null. */
export function normalize(input: string): string | null {
  const s = input
    .replace(/[០-៩]/g, (d) => String(KHMER_DIGITS.indexOf(d)))
    .replace(/[\s,]/g, '')
    .replace(/[−–]/g, '-')
    .replace(/\.(?=%?$)/, ''); // a trailing point while typing
  return /^-?\d+(\.\d+)?%?$/.test(s) ? s : null;
}

function intWords(digits: string): string[] {
  const d = digits.replace(/^0+(?=\d)/, '');
  if (d === '0') return ['zero'];
  if (d.length > 6) {
    const hi = d.slice(0, -6);
    const lo = d.slice(-6);
    return [...intWords(hi), 'million', ...(/[1-9]/.test(lo) ? intWords(lo) : [])];
  }
  const out: string[] = [];
  for (let k = 0; k < d.length; k++) {
    const n = +d[k];
    const place = d.length - k; // 1 = units, 2 = tens, 3 = hundreds …
    if (n === 0) continue;
    if (place === 2) out.push(TENS[n]);
    else {
      out.push(DIGIT[n]);
      if (PLACE[place]) out.push(PLACE[place]);
    }
  }
  return out;
}

export type ReadResult = { ok: true; words: string[] } | { ok: false; reason: 'empty' | 'invalid' | 'too-long' };

export function readNumber(input: string): ReadResult {
  if (!input.trim()) return { ok: false, reason: 'empty' };
  const s = normalize(input);
  if (!s) return { ok: false, reason: 'invalid' };
  const neg = s.startsWith('-');
  const pct = s.endsWith('%');
  const [int, frac = ''] = s.replace('-', '').replace('%', '').split('.');
  if (int.replace(/^0+(?=\d)/, '').length > MAX_INT_DIGITS || frac.length > MAX_FRACTION_DIGITS) return { ok: false, reason: 'too-long' };
  const words = neg && /[1-9]/.test(int + frac) ? ['minus'] : [];
  words.push(...intWords(int));
  if (frac) {
    words.push('point');
    const lead = frac.match(/^0*/)![0];
    const rest = frac.slice(lead.length);
    words.push(...[...lead].map(() => 'zero'));
    if (rest) words.push(...intWords(rest));
  }
  if (pct) words.push('percent');
  return { ok: true, words };
}
