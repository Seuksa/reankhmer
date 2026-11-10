// Learners on this device ("Who is learning?"). Only a name and a colour, kept in this browser;
// nothing is sent anywhere. Each learner's progress is stored under its own IndexedDB key.
// The first learner uses the original key, so progress made before profiles existed becomes theirs.

export interface Profile { id: string; name: string; color: string; created: number }
interface Registry { list: Profile[]; active: string | null }

const KEY = 'rk-profiles';
export const COLORS = ['#0f766e', '#2563eb', '#c026d3', '#ea580c', '#16a34a', '#dc2626'];

export function readProfiles(): Registry {
  try {
    const r = JSON.parse(localStorage.getItem(KEY) ?? 'null') as Registry | null;
    if (r && Array.isArray(r.list)) return { list: r.list.filter((p) => p?.id && typeof p.name === 'string'), active: r.active ?? null };
  } catch { /* storage blocked or corrupt */ }
  return { list: [], active: null };
}

function write(r: Registry) {
  try { localStorage.setItem(KEY, JSON.stringify(r)); } catch { /* private mode: profiles last this visit */ }
}

export const activeProfile = (): Profile | null => {
  const r = readProfiles();
  return r.list.find((p) => p.id === r.active) ?? r.list[0] ?? null;
};

/** IndexedDB key for a learner's progress. "p1" (the first learner) keeps the pre-profiles key. */
export const progressKey = (id: string | null | undefined) => (!id || id === 'p1' ? 'reankhmer-progress' : `reankhmer-progress:${id}`);

export function addProfile(name: string, color?: string): Profile {
  const r = readProfiles();
  let n = r.list.length + 1;
  while (r.list.some((p) => p.id === `p${n}`)) n++;
  const p: Profile = { id: `p${n}`, name: name.trim().slice(0, 40), color: color ?? COLORS[(n - 1) % COLORS.length], created: Date.now() };
  write({ list: [...r.list, p], active: p.id });
  return p;
}

/** Adds a learner from a backup if this device doesn't have one with that id yet. */
export function ensureProfile(p: Profile) {
  const r = readProfiles();
  if (!r.list.some((x) => x.id === p.id)) write({ list: [...r.list, { ...p }], active: r.active ?? p.id });
}

export function renameProfile(id: string, name: string) {
  const r = readProfiles();
  write({ ...r, list: r.list.map((p) => (p.id === id ? { ...p, name: name.trim().slice(0, 40) || p.name } : p)) });
}

export function setActive(id: string) {
  const r = readProfiles();
  if (r.list.some((p) => p.id === id)) write({ ...r, active: id });
}

export function removeProfile(id: string) {
  const r = readProfiles();
  const list = r.list.filter((p) => p.id !== id);
  write({ list, active: r.active === id ? (list[0]?.id ?? null) : r.active });
}
