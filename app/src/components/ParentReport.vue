<script setup lang="ts">
/**
 * "Show my parents": the active learner's progress on one card — this week, the last four weeks,
 * lessons, letters, quizzes and what comes next. Can be shared as a picture or printed.
 * Everything is drawn on this device; nothing is uploaded.
 */
import { computed, onMounted, ref } from 'vue';
import { goalWeeks, kd, lessonCount, lessonsDone, loadSteps, nextStep, studied, studyDays, weekDates, type PlanStep } from '../lib/plan';
import { heardCount, loadProgress, progress } from '../lib/progress';
import { badges } from '../lib/awards';
import { activeProfile, type Profile } from '../lib/profiles';
import T from './T.vue';

const props = defineProps<{ totals: { letters: number; vowels: number } }>();
const steps = ref<PlanStep[]>([]);
const me = ref<Profile | null>(null);
const ready = ref(false);
onMounted(async () => {
  me.value = activeProfile();
  [steps.value] = await Promise.all([loadSteps(), loadProgress()]);
  ready.value = true;
});

const goal = computed(() => progress.plan?.daysPerWeek ?? 5);
const thisWeek = computed(() => weekDates().filter((d) => studied(d)).length);
/** the last 4 weeks, oldest first, Monday to Sunday */
const weeks = computed(() => [3, 2, 1, 0].map((w) => {
  const ref = new Date(); ref.setDate(ref.getDate() - 7 * w);
  return weekDates(ref).map((d) => ({ date: d, done: studied(d), future: d > new Date().toLocaleDateString('en-CA') }));
}));
const lessonTitle = computed(() => new Map(steps.value.map((s) => [s.lesson, s])));
const quizzes = computed(() => Object.entries(progress.lessons)
  .filter(([, l]) => l.quiz)
  .map(([id, l]) => ({ s: lessonTitle.value.get(+id), q: l.quiz! }))
  .filter((x) => x.s));
const next = computed(() => nextStep(steps.value));
const badgeCount = computed(() => { const b = steps.value.length ? badges(steps.value) : []; return { got: b.filter((x) => x.earned).length, all: b.length }; });
const stats = computed(() => [
  { km: 'ថ្ងៃបានរៀនសរុប', en: 'Study days in total', v: `${studyDays()}`, kv: kd(studyDays()) },
  { km: 'សប្តាហ៍សម្រេចគោលដៅជាប់ៗគ្នា', en: 'Weeks in a row on goal', v: `${goalWeeks()}`, kv: kd(goalWeeks()) },
  { km: 'មេរៀនចប់', en: 'Lessons finished', v: `${lessonsDone(steps.value)} / ${lessonCount(steps.value)}`, kv: `${kd(lessonsDone(steps.value))} / ${kd(lessonCount(steps.value))}` },
  { km: 'ព្យញ្ជនៈបានស្តាប់', en: 'Letters heard', v: `${heardCount('c:')} / ${props.totals.letters}`, kv: `${kd(heardCount('c:'))} / ${kd(props.totals.letters)}` },
  { km: 'សំឡេងស្រៈបានស្តាប់', en: 'Vowel sounds heard', v: `${heardCount('v:')} / ${props.totals.vowels}`, kv: `${kd(heardCount('v:'))} / ${kd(props.totals.vowels)}` },
  { km: 'មេដាយ', en: 'Badges', v: `${badgeCount.value.got} / ${badgeCount.value.all}`, kv: `${kd(badgeCount.value.got)} / ${kd(badgeCount.value.all)}` },
  { km: 'ពាក្យ និងអក្សរកំពុងរំលឹក', en: 'Letters and words in review', v: `${Object.keys(progress.cards ?? {}).length}`, kv: kd(Object.keys(progress.cards ?? {}).length) },
]);
const dateStr = new Date().toLocaleDateString('en-GB', { day: 'numeric', month: 'long', year: 'numeric' });

// ---------- picture ----------
const busy = ref(false);
const note = ref<{ km: string; en: string } | null>(null);
const FONT = '"Kantumruy Pro Variable", "Noto Sans Khmer", system-ui, sans-serif';
const css = (name: string, fallback: string) => getComputedStyle(document.documentElement).getPropertyValue(name).trim() || fallback;

async function draw(): Promise<Blob> {
  await Promise.all([document.fonts.load(`600 40px ${FONT}`, 'ករៀនខ្មែរ A'), document.fonts.load(`400 28px ${FONT}`, 'ករៀន A')]).catch(() => {});
  const W = 1080, H = 1350;
  const c = document.createElement('canvas');
  c.width = W; c.height = H;
  const g = c.getContext('2d')!;
  const brand = css('--color-brand-700', '#0f766e');
  g.fillStyle = '#ffffff'; g.fillRect(0, 0, W, H);
  g.fillStyle = brand; g.fillRect(0, 0, W, 250);
  const text = (s: string, x: number, y: number, size: number, color: string, weight = 400, align: CanvasTextAlign = 'left') => {
    g.font = `${weight} ${size}px ${FONT}`; g.fillStyle = color; g.textAlign = align; g.fillText(s, x, y);
  };
  const name = me.value?.name ?? '';
  text('រៀនខ្មែរ ReanKhmer', 60, 80, 34, '#ccfbf1', 600);
  text(name, 60, 160, 64, '#ffffff', 700);
  text(`របាយការណ៍សិក្សា · Progress report · ${dateStr}`, 60, 215, 28, '#ccfbf1');

  // this week
  text(`សប្តាហ៍នេះ ${kd(thisWeek.value)}/${kd(goal.value)} ថ្ងៃ · This week: ${thisWeek.value} of ${goal.value} days`, 60, 320, 34, '#0f172a', 600);
  const DAYS = ['M', 'T', 'W', 'T', 'F', 'S', 'S'];
  weeks.value[3].forEach((d, i) => {
    const x = 60 + i * 136, y = 350;
    g.beginPath(); g.arc(x + 50, y + 50, 46, 0, Math.PI * 2);
    g.fillStyle = d.done ? '#059669' : '#ffffff'; g.fill();
    g.lineWidth = 5; g.strokeStyle = d.done ? '#059669' : '#cbd5e1'; g.stroke();
    text(d.done ? '✓' : DAYS[i], x + 50, y + 62, 34, d.done ? '#ffffff' : '#64748b', 600, 'center');
  });
  if (thisWeek.value >= goal.value) text('⭐ សម្រេចគោលដៅ! Goal reached!', 60, 500, 32, '#047857', 600);

  // stats
  let y = 590;
  for (const s of stats.value) {
    text(s.km, 60, y, 30, '#0f172a', 600);
    text(s.en, 60, y + 36, 24, '#64748b');
    text(s.v, W - 60, y + 18, 44, brand, 700, 'right');
    g.fillStyle = '#e2e8f0'; g.fillRect(60, y + 54, W - 120, 2);
    y += 84;
  }
  if (next.value) {
    text('បន្ទាប់ · Next', 60, y + 30, 26, '#64748b', 600);
    text(`${next.value.title.km} · ${next.value.task.km}`, 60, y + 72, 30, '#0f172a', 600);
    text(`${next.value.title.en}: ${next.value.task.en}`, 60, y + 110, 26, '#475569');
  }
  text('rean.seuksa.com', W / 2, H - 28, 26, '#94a3b8', 400, 'center');
  return new Promise((ok, no) => c.toBlob((b) => (b ? ok(b) : no(new Error('canvas'))), 'image/png'));
}

if (import.meta.env.DEV && typeof window !== 'undefined') (window as unknown as { __rkReportPicture: typeof draw }).__rkReportPicture = draw;

const fileName = () => `reankhmer-${(me.value?.name ?? 'report').replace(/[^\p{L}\p{N}]+/gu, '-')}-${new Date().toLocaleDateString('en-CA')}.png`;

async function share() {
  busy.value = true; note.value = null;
  try {
    const file = new File([await draw()], fileName(), { type: 'image/png' });
    if (navigator.canShare?.({ files: [file] })) {
      await navigator.share({ files: [file], title: 'ReanKhmer' }).catch(() => {});
    } else {
      save(file);
      note.value = { km: 'បានរក្សាទុករូបភាព។ ផ្ញើវាតាម Telegram ឬ Messenger បាន។', en: 'Picture saved. You can send it by Telegram or Messenger.' };
    }
  } catch {
    note.value = { km: 'មិនអាចបង្កើតរូបភាពបានទេ។', en: "Couldn't make the picture." };
  } finally { busy.value = false; }
}
async function download() {
  busy.value = true;
  try { save(new File([await draw()], fileName(), { type: 'image/png' })); } finally { busy.value = false; }
}
function save(f: File) {
  const a = document.createElement('a');
  a.href = URL.createObjectURL(f); a.download = f.name; a.click();
  setTimeout(() => URL.revokeObjectURL(a.href), 5000);
}
</script>

<template>
  <div v-if="ready">
    <div v-if="!me || !progress.plan" class="card">
      <p><T km="មិនទាន់មានផែនការសិក្សានៅឡើយទេ។ ចាប់ផ្តើមនៅទំព័រដើម។" en="No study plan yet. Start one on the home page." /></p>
      <a href="/" class="btn mt-3"><T km="ទៅទំព័រដើម" en="Go to the home page" /></a>
    </div>

    <template v-else>
      <article class="card report space-y-6">
        <header class="flex flex-wrap items-center gap-4">
          <span class="grid size-14 place-items-center rounded-full text-2xl font-semibold text-white" :style="{ background: me.color }" aria-hidden="true">{{ [...me.name][0] }}</span>
          <div>
            <h2 class="text-2xl font-semibold">{{ me.name }}</h2>
            <p class="text-sm text-slate-500"><T km="របាយការណ៍សិក្សា" en="Progress report" /> · {{ dateStr }}</p>
          </div>
        </header>

        <section>
          <h3 class="mb-2 font-semibold"><T :km="`សប្តាហ៍នេះ៖ ${kd(thisWeek)}/${kd(goal)} ថ្ងៃ`" :en="`This week: ${thisWeek} of ${goal} days`" /> <span v-if="thisWeek >= goal">⭐</span></h3>
          <p class="mb-2 text-sm text-slate-500"><T km="៤ សប្តាហ៍ចុងក្រោយ (ចន្ទ → អាទិត្យ)" en="The last 4 weeks (Monday → Sunday)" /></p>
          <div class="space-y-1.5" aria-label="Study days, last 4 weeks">
            <div v-for="(w, i) in weeks" :key="i" class="flex gap-1.5">
              <span v-for="d in w" :key="d.date" class="grid size-8 place-items-center rounded-md border text-xs"
                    :class="d.done ? 'border-emerald-600 bg-emerald-600 text-white' : d.future ? 'border-dashed border-slate-200 dark:border-slate-800' : 'border-slate-300 dark:border-slate-700'"
                    :title="d.date">{{ d.done ? '✓' : '' }}</span>
            </div>
          </div>
        </section>

        <dl class="grid gap-3 sm:grid-cols-2">
          <div v-for="s in stats" :key="s.en" class="rounded-xl bg-slate-50 px-4 py-3 dark:bg-slate-900">
            <dt class="text-sm text-slate-500"><T :km="s.km" :en="s.en" /></dt>
            <dd class="text-2xl font-semibold text-brand-700 dark:text-brand-200"><span lang="km" class="t-km">{{ s.kv }}</span><span lang="en" class="t-en">{{ s.v }}</span></dd>
          </div>
        </dl>

        <section v-if="quizzes.length">
          <h3 class="mb-2 font-semibold"><T km="លទ្ធផលសំណួរ" en="Quiz results" /></h3>
          <ul class="space-y-1">
            <li v-for="x in quizzes" :key="x.s!.lesson" class="flex justify-between gap-3 border-b border-slate-100 py-1 dark:border-slate-800">
              <T :km="x.s!.title.km" :en="x.s!.title.en" /><span class="font-medium">{{ x.q.score }} / {{ x.q.total }}</span>
            </li>
          </ul>
        </section>

        <section v-if="next">
          <h3 class="mb-1 font-semibold"><T km="បន្ទាប់" en="Next" /></h3>
          <p><T :km="`${next.title.km} · ${next.task.km}`" :en="`${next.title.en}: ${next.task.en}`" /></p>
        </section>
        <p v-else>🎓 <T km="រៀនចប់មេរៀនទាំងអស់ហើយ!" en="Every lesson finished!" /></p>
      </article>

      <div class="mt-4 flex flex-wrap gap-3 print:hidden">
        <button type="button" class="btn" :disabled="busy" @click="share"><T km="ផ្ញើជារូបភាព" en="Share as a picture" /></button>
        <button type="button" class="btn-quiet" :disabled="busy" @click="download"><T km="រក្សាទុករូបភាព" en="Save picture" /></button>
        <button type="button" class="btn-quiet" @click="() => print()"><T km="បោះពុម្ព" en="Print" /></button>
      </div>
      <p v-if="note" class="mt-2 text-sm text-slate-600 dark:text-slate-400" aria-live="polite"><T :km="note.km" :en="note.en" /></p>
    </template>
  </div>
</template>

<style scoped>
@media print {
  .report { border: 0; box-shadow: none; padding: 0; }
}
</style>
