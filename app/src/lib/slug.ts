// Stable ASCII URL slugs for the letter and vowel pages (/letters/kor, /vowels/ar).
// Kept free of content imports so client components can use it without bundling the JSON.

const ascii = (s: string) => s.toLowerCase().replace(/[^a-z0-9]+/g, '-').replace(/^-|-$/g, '');

/**
 * Slug from a romanised name; names used more than once get "-<id>" on every use
 * (ឋ and ថ are both "thor" → thor-12, thor-17), so no slug changes when content is reordered.
 */
export function slugMap<T extends { id: number }>(items: T[], name: (item: T) => string | undefined): Map<number, string> {
  const base = new Map(items.map((i) => [i.id, ascii(name(i) ?? '') || String(i.id)]));
  const count = new Map<string, number>();
  for (const b of base.values()) count.set(b, (count.get(b) ?? 0) + 1);
  const out = new Map<number, string>();
  for (const [id, b] of base) out.set(id, count.get(b)! > 1 ? `${b}-${id}` : b);
  return out;
}

export const consonantSlugs = <T extends { id: number; name: string }>(items: T[]) => slugMap(items, (c) => c.name);
export const vowelSlugs = <T extends { id: number; roman_hint?: string }>(items: T[]) => slugMap(items, (v) => v.roman_hint);
