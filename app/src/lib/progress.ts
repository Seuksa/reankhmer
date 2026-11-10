// Learner progress lives only on this device (IndexedDB), one record per learner (see profiles.ts).
// Families back it up by exporting a JSON file or to Google Drive; a backup holds every learner.
import { get, set } from 'idb-keyval';
import { reactive } from 'vue';
import { activeProfile, ensureProfile, progressKey, readProfiles, type Profile } from './profiles';

export interface QuizResult { score: number; total: number; at: number }
/** Structural copy of review.ts StoredCard, kept here to avoid an import cycle. */
export interface StoredCardLike { due: string; last_review?: string; [k: string]: unknown }
export interface TypingResult { kpm: number; acc: number; at: number }
/** One calendar day of the study plan. */
export interface StudyDay {
  /** the plan step that was today's duty (fixed the first time the learner looks today) */
  step?: string;
  /** daily review finished (or nothing was due) */
  review?: boolean;
  /** time the whole duty was finished */
  done?: number;
}
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
  /** study plan: how many days a week the learner wants to study */
  plan?: { daysPerWeek: number; startedAt: number };
  /** practice steps finished, e.g. "find:3" (Listen & find, lesson 3), "spell:2-1", "speak:5-2" */
  steps?: Record<string, number>;
  /** study days by local date YYYY-MM-DD */
  days?: Record<string, StudyDay>;
  /** the last lesson or practice page opened, for "Continue" */
  last?: { path: string; km: string; en: string; at: number };
  /** badges the learner has already been shown (awards.ts), so a new one can be celebrated once */
  seen?: Record<string, number>;
  updatedAt: number;
}

const empty = (): Progress => ({ v: 1, heard: {}, lessons: {}, typing: {}, cards: {}, updatedAt: 0 });
export const progress = reactive<Progress>(empty());

/** Local calendar date (YYYY-MM-DD), so days change at the learner's midnight, not UTC. */
export const today = () => new Date().toLocaleDateString('en-CA');

const isProgress = (p: unknown): p is Progress =>
  !!p && typeof p === 'object' && (p as Progress).v === 1 &&
  typeof (p as Progress).heard === 'object' && typeof (p as Progress).lessons === 'object';

const key = () => progressKey(activeProfile()?.id);
const channel = typeof BroadcastChannel !== 'undefined' ? new BroadcastChannel('reankhmer-progress') : null;
channel?.addEventListener('message', (e) => {
  // another tab switched learner: this page belongs to the old one, so start again
  if (e.data === 'profile') return location.reload();
  loaded = null;
  void loadProgress();
});

let loaded: Promise<void> | null = null;
export function loadProgress(): Promise<void> {
  loaded ??= get(key())
    .then((p) => { Object.assign(progress, empty(), isProgress(p) ? p : {}); })
    .catch(() => {});
  return loaded;
}

async function save() {
  progress.updatedAt = Date.now();
  try {
    await set(key(), JSON.parse(JSON.stringify(progress)));
    channel?.postMessage('updated');
  } catch {
    /* private mode or storage blocked: progress lasts for this visit only */
  }
}

/** Call after profiles.setActive/addProfile/removeProfile: reloads the page for the new learner. */
export function profileChanged() {
  channel?.postMessage('profile');
  location.reload();
}

export function markHeard(key: string) {
  progress.heard[key] = (progress.heard[key] ?? 0) + 1;
  void save();
}

export function markLessonDone(id: number) {
  (progress.lessons[id] ??= {}).done = Date.now();
  void save();
}

/** A practice step of the study plan was finished (see plan.ts). Only the first time counts. */
export function markStep(id: string) {
  const s = (progress.steps ??= {});
  if (s[id]) return;
  s[id] = Date.now();
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

export function setPlan(daysPerWeek: number) {
  progress.plan = { daysPerWeek, startedAt: progress.plan?.startedAt ?? Date.now() };
  void save();
}

/** Updates today's study-day record (merging the given fields). */
export function updateDay(fields: StudyDay) {
  const days = (progress.days ??= {});
  const d = today();
  const cur = days[d] ?? {};
  if (Object.entries(fields).every(([k, v]) => cur[k as keyof StudyDay] === v)) return;
  days[d] = { ...cur, ...fields };
  void save();
}

export function setLast(path: string, km: string, en: string) {
  if (progress.last?.path === path) return;
  progress.last = { path, km, en, at: Date.now() };
  void save();
}

export function markSeen(ids: string[]) {
  const s = (progress.seen ??= {});
  const fresh = ids.filter((id) => !s[id]);
  if (!fresh.length) return;
  for (const id of fresh) s[id] = Date.now();
  void save();
}

export const heardCount = (prefix: string) => Object.keys(progress.heard).filter((k) => k.startsWith(prefix)).length;

// ---------- backup: every learner on this device ----------
interface Bundle { app: 'reankhmer'; v: 2; profiles: { profile: Profile; progress: Progress }[] }

export async function exportProgress(): Promise<Blob> {
  await loadProgress();
  const { list } = readProfiles();
  const active = activeProfile();
  const profiles: Bundle['profiles'] = [];
  for (const p of list) {
    const data = p.id === active?.id ? JSON.parse(JSON.stringify(progress)) : await get(progressKey(p.id)).catch(() => null);
    if (isProgress(data)) profiles.push({ profile: p, progress: data });
  }
  // No learners yet (progress made before profiles existed): back up that progress on its own.
  const body = profiles.length ? ({ app: 'reankhmer', v: 2, profiles } satisfies Bundle) : { app: 'reankhmer', ...JSON.parse(JSON.stringify(progress)) };
  return new Blob([JSON.stringify(body, null, 2)], { type: 'application/json' });
}

/** Merges `from` into `into`: higher play counts, better scores, the most recent review cards. */
function merge(into: Progress, from: Progress) {
  for (const [k, n] of Object.entries(from.heard)) {
    if (typeof n === 'number') into.heard[k] = Math.max(into.heard[k] ?? 0, n);
  }
  for (const [id, l] of Object.entries(from.lessons)) {
    const mine = (into.lessons[id] ??= {});
    if (l.done) mine.done ??= l.done;
    if (l.quiz && (!mine.quiz || l.quiz.score / l.quiz.total > mine.quiz.score / mine.quiz.total)) mine.quiz = l.quiz;
  }
  for (const [id, t] of Object.entries(from.typing ?? {})) {
    const all = (into.typing ??= {});
    if (t && typeof t.kpm === 'number' && (!all[id] || t.kpm * t.acc > all[id].kpm * all[id].acc)) all[id] = t;
  }
  for (const [id, c] of Object.entries(from.cards ?? {})) {
    const all = (into.cards ??= {});
    const mine = all[id];
    if (c && typeof c.due === 'string' && (!mine || (c.last_review ?? '') > (mine.last_review ?? ''))) all[id] = c;
  }
  for (const [id, at] of Object.entries(from.steps ?? {})) {
    const all = (into.steps ??= {});
    if (typeof at === 'number') all[id] = Math.min(all[id] ?? at, at);
  }
  for (const [d, day] of Object.entries(from.days ?? {})) {
    const all = (into.days ??= {});
    const mine = all[d] ?? {};
    all[d] = { step: mine.step ?? day.step, review: mine.review || day.review, done: mine.done ?? day.done };
  }
  for (const [id, at] of Object.entries(from.seen ?? {})) (into.seen ??= {})[id] ??= at;
  if (from.plan && !into.plan) into.plan = from.plan;
  if (from.last && (!into.last || from.last.at > into.last.at)) into.last = from.last;
}

/** Restores a backup into this device (merging, never deleting). Accepts old one-learner files too. */
export async function importProgress(text: string): Promise<boolean> {
  let data: unknown;
  try { data = JSON.parse(text); } catch { return false; }
  await loadProgress();
  const b = data as Bundle;
  if (b && b.app === 'reankhmer' && b.v === 2 && Array.isArray(b.profiles)) {
    const active = activeProfile()?.id;
    let any = false;
    for (const { profile, progress: p } of b.profiles) {
      if (!profile?.id || !isProgress(p)) continue;
      ensureProfile(profile);
      any = true;
      if (profile.id === (active ?? readProfiles().active)) { merge(progress, p); await save(); continue; }
      const stored = await get(progressKey(profile.id)).catch(() => null);
      const into = isProgress(stored) ? stored : empty();
      merge(into, p);
      into.updatedAt = Date.now();
      await set(progressKey(profile.id), JSON.parse(JSON.stringify(into))).catch(() => {});
    }
    return any;
  }
  if (!isProgress(data)) return false;
  merge(progress, data);
  await save();
  return true;
}

export async function resetProgress() {
  Object.assign(progress, empty());
  await save();
}
