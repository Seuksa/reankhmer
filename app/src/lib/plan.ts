// The study plan: the whole course as a path of ~10-minute steps (2–3 per lesson), a daily duty
// (the daily review + the next step) and a weekly goal (3, 5 or 7 study days).
// Steps are built at publish time from the content (content.ts → planSteps) and published once as
// /plan-steps.json (precached for offline); this file only reads progress, so it stays small.
import { computed, onMounted, ref, watch } from 'vue';
import { loadProgress, progress, today, updateDay, type Progress } from './progress';

export interface Bi { km: string; en: string }
/** How a step is recognised as done, from what the learner actually did. */
export type Check = { heard: string[] } | { step: string } | { done: number };
export interface PlanStep {
  id: string;          // "18:2" = lesson id 18, part 2
  lesson: number;      // lesson id
  ch: number;
  n: number;           // lesson number in its chapter
  title: Bi;           // the lesson's title
  part: number;
  parts: number;
  task: Bi;            // what to do, e.g. "Play Listen & find"
  href: string;
  check: Check;
}

/** Khmer digits (kept here so the plan islands don't import content.ts). */
export const kd = (n: number | string) => String(n).replace(/\d/g, (d) => '០១២៣៤៥៦៧៨៩'[+d]);

let stepsReq: Promise<PlanStep[]> | null = null;
/** The plan path, fetched once per page (the service worker serves it offline). */
export function loadSteps(): Promise<PlanStep[]> {
  stepsReq ??= fetch('/plan-steps.json')
    .then((r) => (r.ok ? (r.json() as Promise<PlanStep[]>) : Promise.reject(new Error(String(r.status)))))
    .catch(() => { stepsReq = null; return []; });
  return stepsReq;
}

export function stepDone(s: PlanStep, p: Progress = progress): boolean {
  if (p.lessons[s.lesson]?.done) return true; // finishing a lesson covers all its steps
  const c = s.check;
  if ('heard' in c) return c.heard.every((k) => (p.heard[k] ?? 0) > 0);
  if ('step' in c) return !!p.steps?.[c.step];
  return !!p.lessons[c.done]?.done;
}

/** The first step not done yet (or null when the whole course is finished). */
export const nextStep = (steps: PlanStep[], p: Progress = progress) => steps.find((s) => !stepDone(s, p)) ?? null;

export const lessonsDone = (steps: PlanStep[], p: Progress = progress) =>
  new Set(steps.filter((s) => p.lessons[s.lesson]?.done).map((s) => s.lesson)).size;
export const lessonCount = (steps: PlanStep[]) => new Set(steps.map((s) => s.lesson)).size;

// ---------- weeks (Monday to Sunday, local time) ----------
const iso = (d: Date) => d.toLocaleDateString('en-CA');
export function weekDates(ref = new Date()): string[] {
  const d = new Date(ref.getFullYear(), ref.getMonth(), ref.getDate());
  const monday = new Date(d);
  monday.setDate(d.getDate() - ((d.getDay() + 6) % 7));
  return Array.from({ length: 7 }, (_, i) => iso(new Date(monday.getFullYear(), monday.getMonth(), monday.getDate() + i)));
}
export const studied = (date: string, p: Progress = progress) => !!p.days?.[date]?.done;
export const studyDays = (p: Progress = progress) => Object.values(p.days ?? {}).filter((d) => d.done).length;

/** Weeks in a row (ending with last week, plus this week if already reached) that met the goal. */
export function goalWeeks(p: Progress = progress): number {
  const goal = p.plan?.daysPerWeek ?? 5;
  let n = 0;
  const ref = new Date();
  const thisWeek = weekDates(ref).filter((d) => studied(d, p)).length;
  if (thisWeek >= goal) n++;
  for (let w = 1; w < 520; w++) {
    const r = new Date(ref.getFullYear(), ref.getMonth(), ref.getDate() - 7 * w);
    if (weekDates(r).filter((d) => studied(d, p)).length >= goal) n++;
    else break;
  }
  return n;
}

/**
 * Today's duty, kept up to date as the learner works: fixes today's step the first time it is
 * looked at, and records the day as studied once the step and the review are both done.
 */
export function useStudyDay() {
  const steps = ref<PlanStep[]>([]);
  const day = computed(() => progress.days?.[today()] ?? {});
  const step = computed(() => steps.value.find((s) => s.id === day.value.step) ?? nextStep(steps.value));
  const stepOk = computed(() => !!step.value && stepDone(step.value));
  const reviewOk = computed(() => !!day.value.review);
  const done = computed(() => !!day.value.done);
  const week = computed(() => weekDates().map((d) => ({ date: d, done: studied(d), today: d === today() })));
  const weekCount = computed(() => week.value.filter((d) => d.done).length);
  const goal = computed(() => progress.plan?.daysPerWeek ?? 5);
  const finishedCourse = computed(() => steps.value.length > 0 && !nextStep(steps.value));

  onMounted(async () => {
    const [list] = await Promise.all([loadSteps(), loadProgress()]);
    steps.value = list;
    watch(
      () => [progress.plan, day.value.step, stepOk.value, reviewOk.value, done.value, finishedCourse.value] as const,
      () => {
        if (!progress.plan || !steps.value.length) return;
        if (!day.value.step && step.value) updateDay({ step: step.value.id });
        if (!done.value && (stepOk.value || finishedCourse.value) && reviewOk.value) updateDay({ done: Date.now() });
      },
      { immediate: true },
    );
  });
  return { steps, day, step, stepOk, reviewOk, done, week, weekCount, goal, finishedCourse };
}
