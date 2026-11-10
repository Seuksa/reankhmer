// Step D: stars per lesson, badges (one per chapter + three for the study habit) and chapter
// certificates. Everything is worked out from the learner's progress; nothing extra is stored
// except which badges the learner has already seen (for the "New badge!" moment).
import { CHAPTER_TITLE, type Bi } from './chapter-titles';
import { stepDone, weekDates, type PlanStep } from './plan';
import { progress, type Progress } from './progress';

/** 0–3 stars: ★ a first part done, ★★ everything but the last part, ★★★ lesson finished. */
export function lessonStars(lesson: number, steps: PlanStep[], p: Progress = progress): number {
  if (p.lessons[lesson]?.done) return 3;
  const mine = steps.filter((s) => s.lesson === lesson);
  const done = mine.filter((s) => stepDone(s, p)).length;
  if (!mine.length || !done) return 0;
  return done >= mine.length - 1 ? 2 : 1;
}

export const starText = (n: number) => '★'.repeat(n) + '☆'.repeat(3 - n);

export interface Badge {
  id: string;
  icon: string;
  title: Bi;
  how: Bi;            // how to earn it
  chapter?: number;   // chapter badges come with a certificate
  earned: number | null;
}

const CHAPTER_BADGE: Record<number, { icon: string; title: Bi }> = {
  1: { icon: 'ក', title: { km: 'អ្នកស្គាល់ព្យញ្ជនៈ', en: 'Letter explorer' } },
  2: { icon: 'ក់', title: { km: 'អ្នកប្រកបពាក្យ', en: 'Speller' } },
  3: { icon: 'ស្ក', title: { km: 'អ្នកស្គាល់ជើងអក្សរ', en: 'Subscript star' } },
  4: { icon: '📖', title: { km: 'អ្នកអាន', en: 'Reader' } },
  5: { icon: '💬', title: { km: 'អ្នកនិយាយ', en: 'Speaker' } },
};

/** Study days (local dates) with the time each was completed, oldest first. */
function doneDays(p: Progress) {
  return Object.entries(p.days ?? {}).filter(([, d]) => d.done).map(([date, d]) => ({ date, at: d.done! })).sort((a, b) => a.date.localeCompare(b.date));
}

/** Weeks (Monday dates) that reached the goal, each with the time the goal was reached. */
function goalWeeks(p: Progress) {
  const goal = p.plan?.daysPerWeek ?? 5;
  const byWeek = new Map<string, { at: number }[]>();
  for (const d of doneDays(p)) {
    const [y, m, day] = d.date.split('-').map(Number);
    const monday = weekDates(new Date(y, m - 1, day))[0];
    (byWeek.get(monday) ?? byWeek.set(monday, []).get(monday)!).push(d);
  }
  return [...byWeek.entries()].filter(([, ds]) => ds.length >= goal).map(([monday, ds]) => ({ monday, at: ds[goal - 1].at })).sort((a, b) => a.monday.localeCompare(b.monday));
}

const nextMonday = (monday: string) => {
  const [y, m, d] = monday.split('-').map(Number);
  return new Date(y, m - 1, d + 7).toLocaleDateString('en-CA');
};

export function badges(steps: PlanStep[], p: Progress = progress): Badge[] {
  const out: Badge[] = [];
  for (const ch of [...new Set(steps.map((s) => s.ch))].sort()) {
    const ids = [...new Set(steps.filter((s) => s.ch === ch).map((s) => s.lesson))];
    const times = ids.map((id) => p.lessons[id]?.done);
    const meta = CHAPTER_BADGE[ch] ?? { icon: String(ch), title: CHAPTER_TITLE[ch] };
    out.push({
      id: `ch${ch}`, icon: meta.icon, title: meta.title, chapter: ch,
      how: { km: `រៀនចប់ជំពូក ${CHAPTER_TITLE[ch]?.km ?? ch}`, en: `Finish chapter ${ch}: ${CHAPTER_TITLE[ch]?.en ?? ''}` },
      earned: times.every(Boolean) ? Math.max(...(times as number[])) : null,
    });
  }
  const days = doneDays(p);
  out.push({ id: 'day1', icon: '🌱', title: { km: 'ថ្ងៃដំបូង', en: 'First study day' }, how: { km: 'ធ្វើកិច្ចការថ្ងៃនេះឲ្យរួចម្តង', en: "Finish a day's task once" }, earned: days[0]?.at ?? null });
  const weeks = goalWeeks(p);
  out.push({ id: 'week1', icon: '⭐', title: { km: 'សប្តាហ៍ជោគជ័យ', en: 'Goal week' }, how: { km: 'សម្រេចគោលដៅប្រចាំសប្តាហ៍', en: 'Reach your weekly goal' }, earned: weeks[0]?.at ?? null });
  let run = 0, four: number | null = null;
  for (let i = 0; i < weeks.length && four === null; i++) {
    run = i > 0 && weeks[i].monday === nextMonday(weeks[i - 1].monday) ? run + 1 : 1;
    if (run >= 4) four = weeks[i].at;
  }
  out.push({ id: 'week4', icon: '🏆', title: { km: 'ជោគជ័យ ៤ សប្តាហ៍ជាប់ៗគ្នា', en: '4 goal weeks in a row' }, how: { km: 'សម្រេចគោលដៅ ៤ សប្តាហ៍ជាប់ៗគ្នា', en: 'Reach the weekly goal 4 weeks in a row' }, earned: four });
  return out;
}
