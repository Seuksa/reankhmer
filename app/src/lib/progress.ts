// Learner progress lives only on this device (IndexedDB). Families back it up by exporting a
// JSON file; Google Drive backup comes in phase 2 and will reuse exportProgress/importProgress.
import { get, set } from 'idb-keyval';
import { reactive } from 'vue';

export interface QuizResult { score: number; total: number; at: number }
/** Structural copy of review.ts StoredCard, kept here to avoid an import cycle. */
export interface StoredCardLike { due: string; last_review?: string; [k: string]: unknown }
export interface TypingResult { kpm: number; acc: number; at: number }
export interface Progress {
  v: 1;
  /** times each item was played: "c:1" consonant 1, "v:3:2" vowel 3 series 2, "n:five", "l:18:3" dialogue line */
  heard: Record<string, number>;
  lessons: Record<string, { done?: number; quiz?: QuizResult }>;
  /** best result per typing lesson: kpm = correct keystrokes per minute, acc = 0..1 */
  typing?: Record<string, TypingResult>;
  /** FSRS review cards by item id (dates as ISO strings) */
  cards?: Record<string, StoredCardLike>;
  reviewDay?: { date: string; newCount: number; reviews?: number };
  updatedAt: number;
}

const KEY = 'reankhmer-progress';
const empty = (): Progress => ({ v: 1, heard: {}, lessons: {}, typing: {}, cards: {}, updatedAt: 0 });
export const progress = reactive<Progress>(empty());

const isProgress = (p: unknown): p is Progress =>
  !!p && typeof p === 'object' && (p as Progress).v === 1 &&
  typeof (p as Progress).heard === 'object' && typeof (p as Progress).lessons === 'object';

const channel = typeof BroadcastChannel !== 'undefined' ? new BroadcastChannel(KEY) : null;
channel?.addEventListener('message', () => { loaded = null; void loadProgress(); });

let loaded: Promise<void> | null = null;
export function loadProgress(): Promise<void> {
  loaded ??= get(KEY)
    .then((p) => { if (isProgress(p)) Object.assign(progress, p); })
    .catch(() => {});
  return loaded;
}

async function save() {
  progress.updatedAt = Date.now();
  try {
    await set(KEY, JSON.parse(JSON.stringify(progress)));
    channel?.postMessage('updated');
  } catch {
    /* private mode or storage blocked: progress lasts for this visit only */
  }
}

export function markHeard(key: string) {
  progress.heard[key] = (progress.heard[key] ?? 0) + 1;
  void save();
}

export function markLessonDone(id: number) {
  (progress.lessons[id] ??= {}).done = Date.now();
  void save();
}

export function saveQuiz(id: number, score: number, total: number) {
  const entry = (progress.lessons[id] ??= {});
  const prev = entry.quiz;
  if (!prev || score / total >= prev.score / prev.total) entry.quiz = { score, total, at: Date.now() };
  if (score === total) entry.done ??= Date.now();
  void save();
}

export function saveTyping(id: string, kpm: number, acc: number) {
  const all = (progress.typing ??= {});
  const prev = all[id];
  if (!prev || kpm * acc > prev.kpm * prev.acc) all[id] = { kpm, acc, at: Date.now() };
  void save();
}

export function saveCards(cards: Record<string, StoredCardLike>, day: Progress['reviewDay']) {
  progress.cards = cards;
  progress.reviewDay = day;
  void save();
}

export const heardCount = (prefix: string) => Object.keys(progress.heard).filter((k) => k.startsWith(prefix)).length;

export function exportProgress(): Blob {
  return new Blob([JSON.stringify({ app: 'reankhmer', ...progress }, null, 2)], { type: 'application/json' });
}

/** Merge a backup into this device: keeps the higher play counts and the better quiz scores. */
export async function importProgress(text: string): Promise<boolean> {
  let data: unknown;
  try { data = JSON.parse(text); } catch { return false; }
  if (!isProgress(data)) return false;
  for (const [k, n] of Object.entries(data.heard)) {
    if (typeof n === 'number') progress.heard[k] = Math.max(progress.heard[k] ?? 0, n);
  }
  for (const [id, l] of Object.entries(data.lessons)) {
    const mine = (progress.lessons[id] ??= {});
    if (l.done) mine.done ??= l.done;
    if (l.quiz && (!mine.quiz || l.quiz.score / l.quiz.total > mine.quiz.score / mine.quiz.total)) mine.quiz = l.quiz;
  }
  for (const [id, t] of Object.entries(data.typing ?? {})) {
    const all = (progress.typing ??= {});
    if (t && typeof t.kpm === 'number' && (!all[id] || t.kpm * t.acc > all[id].kpm * all[id].acc)) all[id] = t;
  }
  // Review cards: keep whichever copy was reviewed most recently.
  for (const [id, c] of Object.entries(data.cards ?? {})) {
    const all = (progress.cards ??= {});
    const mine = all[id];
    if (c && typeof c.due === 'string' && (!mine || (c.last_review ?? '') > (mine.last_review ?? ''))) all[id] = c;
  }
  await save();
  return true;
}

export async function resetProgress() {
  Object.assign(progress, empty());
  await save();
}
