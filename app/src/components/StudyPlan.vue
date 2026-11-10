<script setup lang="ts">
/**
 * Home page study plan: who is learning, today's duty (daily review + the next ~10-minute step),
 * this week against the weekly goal, and a link to the report for parents.
 */
import { computed, onMounted, ref } from 'vue';
import { kd, lessonCount, lessonsDone, nextStep, stepDone, useStudyDay, type PlanStep } from '../lib/plan';
import { loadProgress, profileChanged, progress, setPlan } from '../lib/progress';
import { addProfile, readProfiles, removeProfile, renameProfile, setActive, type Profile } from '../lib/profiles';
import T from './T.vue';

const ready = ref(false);
const profiles = ref<Profile[]>([]);
const activeId = ref<string | null>(null);
const me = computed(() => profiles.value.find((p) => p.id === activeId.value) ?? profiles.value[0] ?? null);

const { steps, step, stepOk, reviewOk, done, week, weekCount, goal, finishedCourse } = useStudyDay();
const upNext = computed(() => nextStep(steps.value));
const lessons = computed(() => ({ done: lessonsDone(steps.value), total: lessonCount(steps.value) }));
const pathPct = computed(() => (steps.value.length ? Math.round((steps.value.filter((s) => stepDone(s)).length / steps.value.length) * 100) : 0));
const continueHere = computed(() => {
  const l = progress.last;
  return l && l.path !== step.value?.href && Date.now() - l.at < 30 * 864e5 ? l : null;
});

onMounted(async () => {
  const r = readProfiles();
  profiles.value = r.list;
  activeId.value = r.active ?? r.list[0]?.id ?? null;
  await loadProgress();
  ready.value = true;
});

// ---- setting up ----
const name = ref('');
const days = ref(5);
const adding = ref(false);
function start() {
  if (!name.value.trim()) return;
  const first = !profiles.value.length;
  addProfile(name.value);
  if (first) {
    // the first learner keeps whatever progress this device already has
    setPlan(days.value);
    const r = readProfiles();
    profiles.value = r.list;
    activeId.value = r.active;
    name.value = '';
  } else {
    profileChanged(); // a new, empty learner: reload for them
  }
}
function choosePlan() { setPlan(days.value); }

// ---- switching learner ----
const managing = ref(false);
const confirmRemove = ref<string | null>(null);
function switchTo(id: string) {
  if (id === activeId.value) return;
  setActive(id);
  profileChanged();
}
function rename(p: Profile, e: Event) { renameProfile(p.id, (e.target as HTMLInputElement).value); profiles.value = readProfiles().list; }
function remove(p: Profile) {
  removeProfile(p.id);
  // their progress stays in storage under its key, so restoring a backup can bring it back
  if (p.id === activeId.value) return profileChanged();
  profiles.value = readProfiles().list;
  confirmRemove.value = null;
}

const DAY = [
  { km: 'ច', en: 'M' }, { km: 'អ', en: 'T' }, { km: 'ពុ', en: 'W' }, { km: 'ព្រ', en: 'T' }, { km: 'សុ', en: 'F' }, { km: 'ស', en: 'S' }, { km: 'អា', en: 'S' },
];
const partLabel = (s: PlanStep) => ({ km: `ផ្នែក ${kd(s.part)}/${kd(s.parts)}`, en: `Part ${s.part} of ${s.parts}` });
const lessonLabel = (s: PlanStep) => ({ km: `មេរៀន ${kd(s.ch)}.${kd(s.n)} · ${s.title.km}`, en: `Lesson ${s.ch}.${s.n} · ${s.title.en}` });
</script>

<template>
  <section v-if="ready" class="card mb-10 border-brand-200 dark:border-brand-900" aria-labelledby="plan-h">
    <!-- 1. nobody yet: start a plan -->
    <form v-if="!me || adding" class="space-y-4" @submit.prevent="start">
      <h2 id="plan-h" class="text-xl font-semibold"><T km="ផែនការសិក្សារបស់ខ្ញុំ" en="My study plan" /></h2>
      <p class="text-slate-600 dark:text-slate-400">
        <T km="រៀនបន្តិចម្តងៗ ប្រហែល ១០ នាទីក្នុងមួយថ្ងៃ។ គេហទំព័រនឹងចាំថាអ្នករៀនដល់ណា ហើយប្រាប់ពីកិច្ចការថ្ងៃនេះ។"
           en="A little at a time, about 10 minutes a day. The site remembers where you are and gives you today's task." stack />
      </p>
      <label class="block max-w-sm">
        <span class="mb-1 block text-sm font-medium"><T km="ឈ្មោះអ្នករៀន" en="Learner's name" /></span>
        <input v-model="name" required maxlength="40" autocomplete="off" class="w-full rounded-xl border border-slate-300 bg-white px-3 py-2 dark:border-slate-700 dark:bg-slate-900" />
      </label>
      <fieldset v-if="!me">
        <legend class="mb-1 text-sm font-medium"><T km="ចង់រៀនប៉ុន្មានថ្ងៃក្នុងមួយសប្តាហ៍?" en="How many days a week?" /></legend>
        <div class="flex flex-wrap gap-2">
          <label v-for="n in [3, 5, 7]" :key="n" class="chip cursor-pointer" :class="days === n ? '!border-brand-600 !bg-brand-50 dark:!bg-brand-900/40' : ''">
            <input v-model="days" type="radio" :value="n" class="sr-only" /> <T :km="`${kd(n)} ថ្ងៃ`" :en="`${n} days`" />
          </label>
        </div>
      </fieldset>
      <p class="text-xs text-slate-500"><T km="ឈ្មោះ និងវឌ្ឍនភាពនៅលើឧបករណ៍នេះតែប៉ុណ្ណោះ។" en="The name and progress stay on this device only." /></p>
      <div class="flex gap-2">
        <button class="btn" type="submit"><T km="ចាប់ផ្តើម" en="Start" /></button>
        <button v-if="adding" type="button" class="btn-quiet" @click="adding = false"><T km="បោះបង់" en="Cancel" /></button>
      </div>
    </form>

    <!-- 2. a learner without a plan yet (e.g. added from a backup) -->
    <div v-else-if="!progress.plan" class="space-y-3">
      <h2 id="plan-h" class="text-xl font-semibold"><T :km="`សួស្តី ${me.name}!`" :en="`Hi ${me.name}!`" /></h2>
      <p><T km="ចង់រៀនប៉ុន្មានថ្ងៃក្នុងមួយសប្តាហ៍?" en="How many days a week would you like to study?" /></p>
      <div class="flex flex-wrap gap-2">
        <button v-for="n in [3, 5, 7]" :key="n" type="button" class="chip" :class="days === n ? '!border-brand-600' : ''" @click="days = n"><T :km="`${kd(n)} ថ្ងៃ`" :en="`${n} days`" /></button>
      </div>
      <button class="btn" type="button" @click="choosePlan"><T km="ចាប់ផ្តើម" en="Start" /></button>
      <p v-if="profiles.length > 1" class="flex flex-wrap items-center gap-2 border-t border-slate-200 pt-3 text-sm dark:border-slate-800">
        <T km="មិនមែន​អ្នកទេ? ប្តូរទៅ៖" en="Not you? Switch to:" />
        <button v-for="p in profiles.filter((x) => x.id !== me!.id)" :key="p.id" type="button" class="chip" @click="switchTo(p.id)">
          <span class="inline-block size-3 rounded-full" :style="{ background: p.color }" aria-hidden="true" /> {{ p.name }}
        </button>
      </p>
    </div>

    <!-- 3. the plan -->
    <div v-else>
      <div class="mb-4 flex flex-wrap items-center gap-3">
        <span class="grid size-10 place-items-center rounded-full text-lg font-semibold text-white" :style="{ background: me.color }" aria-hidden="true">{{ [...me.name][0] }}</span>
        <h2 id="plan-h" class="text-xl font-semibold"><T :km="`សួស្តី ${me.name}!`" :en="`Hi ${me.name}!`" /></h2>
        <button type="button" class="btn-quiet ml-auto !py-1 text-sm" :aria-expanded="managing" @click="managing = !managing">
          <T km="ប្តូរអ្នករៀន" en="Switch learner" /> {{ managing ? '▴' : '▾' }}
        </button>
      </div>

      <div v-if="managing" class="mb-4 space-y-2 rounded-xl bg-slate-50 p-3 dark:bg-slate-900">
        <div v-for="p in profiles" :key="p.id" class="flex flex-wrap items-center gap-2">
          <button type="button" class="chip" :class="p.id === me.id ? '!border-brand-600' : ''" @click="switchTo(p.id)">
            <span class="inline-block size-3 rounded-full" :style="{ background: p.color }" aria-hidden="true" /> {{ p.name }}
            <span v-if="p.id === me.id" class="text-xs text-slate-500">✓</span>
          </button>
          <input :value="p.name" maxlength="40" :aria-label="`Rename ${p.name}`" class="w-32 rounded-lg border border-slate-300 bg-white px-2 py-1 text-sm dark:border-slate-700 dark:bg-slate-950" @change="rename(p, $event)" />
          <button v-if="confirmRemove !== p.id" type="button" class="text-sm text-slate-500 underline" @click="confirmRemove = p.id"><T km="ដកចេញ" en="Remove" /></button>
          <span v-else class="text-sm">
            <T km="ដកអ្នករៀននេះចេញ?" en="Remove this learner?" />
            <button type="button" class="ml-1 font-medium text-rose-700 underline dark:text-rose-300" @click="remove(p)"><T km="បាទ/ចាស" en="Yes" /></button>
            <button type="button" class="ml-1 underline" @click="confirmRemove = null"><T km="ទេ" en="No" /></button>
          </span>
        </div>
        <button type="button" class="btn-quiet !py-1 text-sm" @click="adding = true; managing = false">+ <T km="បន្ថែមអ្នករៀន" en="Add a learner" /></button>
        <p class="text-xs text-slate-500"><T km="អ្នករៀននីមួយៗមានផែនការ និងវឌ្ឍនភាពផ្ទាល់ខ្លួន។" en="Each learner has their own plan and progress." /></p>
      </div>

      <!-- today's duty -->
      <h3 class="mb-2 font-semibold"><T km="កិច្ចការថ្ងៃនេះ (~១០ នាទី)" en="Today's task (about 10 minutes)" /></h3>
      <ol class="mb-4 space-y-2">
        <li>
          <a href="/review" class="flex items-center gap-3 rounded-xl border px-3 py-2" :class="reviewOk ? 'border-emerald-300 bg-emerald-50 dark:border-emerald-800 dark:bg-emerald-950/40' : 'border-slate-200 hover:border-brand-500 dark:border-slate-700'">
            <span class="grid size-7 shrink-0 place-items-center rounded-full border-2 text-sm" :class="reviewOk ? 'border-emerald-600 bg-emerald-600 text-white' : 'border-slate-300'">{{ reviewOk ? '✓' : '1' }}</span>
            <span class="flex-1"><T km="រំលឹកប្រចាំថ្ងៃ" en="Daily review" /> <span class="text-sm text-slate-500"><T km="· ពីរបីនាទី" en="· a few minutes" /></span></span>
            <span v-if="!reviewOk" aria-hidden="true">→</span>
          </a>
        </li>
        <li v-if="step">
          <a :href="step.href" class="flex items-center gap-3 rounded-xl border px-3 py-2" :class="stepOk ? 'border-emerald-300 bg-emerald-50 dark:border-emerald-800 dark:bg-emerald-950/40' : 'border-slate-200 hover:border-brand-500 dark:border-slate-700'">
            <span class="grid size-7 shrink-0 place-items-center rounded-full border-2 text-sm" :class="stepOk ? 'border-emerald-600 bg-emerald-600 text-white' : 'border-slate-300'">{{ stepOk ? '✓' : '2' }}</span>
            <span class="flex-1">
              <span class="block"><T :km="step.task.km" :en="step.task.en" /></span>
              <span class="block text-sm text-slate-500"><T v-bind="lessonLabel(step)" /> · <T v-bind="partLabel(step)" /></span>
            </span>
            <span v-if="!stepOk" aria-hidden="true">→</span>
          </a>
        </li>
        <li v-else-if="finishedCourse" class="rounded-xl bg-emerald-50 px-3 py-2 dark:bg-emerald-950/40">
          🎓 <T km="អ្នករៀនចប់មេរៀនទាំងអស់ហើយ! បន្តរំលឹក និងហាត់ប្រចាំថ្ងៃ។" en="You have finished every lesson! Keep up the daily review and practice." />
        </li>
      </ol>

      <p v-if="done" class="mb-4 rounded-xl bg-emerald-50 px-4 py-3 font-medium text-emerald-800 dark:bg-emerald-950/50 dark:text-emerald-200" aria-live="polite">
        🎉 <T km="កិច្ចការថ្ងៃនេះរួចរាល់! ល្អណាស់។" en="Today's task is done! Well done." />
        <a v-if="upNext && upNext.id !== step?.id" :href="upNext.href" class="ml-1 underline"><T km="ចង់រៀនបន្តទៀត?" en="Want to keep going?" /> →</a>
      </p>

      <a v-if="continueHere" :href="continueHere.path" class="mb-4 inline-block text-sm text-brand-700 underline underline-offset-2 dark:text-brand-300">
        ↩ <T km="ត្រឡប់ទៅកន្លែងដែលអ្នកឈប់៖" en="Back to where you stopped:" /> {{ continueHere.en }}
      </a>

      <!-- this week -->
      <div class="flex flex-wrap items-center gap-x-6 gap-y-3 border-t border-slate-200 pt-4 dark:border-slate-800">
        <div>
          <p class="mb-1 text-sm font-medium"><T :km="`សប្តាហ៍នេះ៖ ${kd(weekCount)}/${kd(goal)} ថ្ងៃ`" :en="`This week: ${weekCount} of ${goal} days`" /></p>
          <ol class="flex gap-1.5" aria-label="This week">
            <li v-for="(d, i) in week" :key="d.date" class="grid size-8 place-items-center rounded-full border-2 text-xs"
                :class="[d.done ? 'border-emerald-600 bg-emerald-600 text-white' : 'border-slate-300 dark:border-slate-700', d.today ? 'ring-2 ring-brand-300 dark:ring-brand-800' : '']"
                :title="d.date">
              <span lang="km" class="t-km">{{ DAY[i].km }}</span><span lang="en" class="t-en">{{ DAY[i].en }}</span>
            </li>
          </ol>
          <p v-if="weekCount >= goal" class="mt-1 text-sm text-emerald-700 dark:text-emerald-300">⭐ <T km="សម្រេចគោលដៅសប្តាហ៍នេះ!" en="Weekly goal reached!" /></p>
        </div>
        <div class="min-w-40 flex-1">
          <p class="mb-1 text-sm font-medium"><T :km="`មេរៀនចប់ ${kd(lessons.done)}/${kd(lessons.total)}`" :en="`Lessons finished: ${lessons.done} of ${lessons.total}`" /></p>
          <div class="h-2 rounded-full bg-slate-100 dark:bg-slate-800"><div class="h-2 rounded-full bg-brand-600" :style="{ width: `${pathPct}%` }" /></div>
        </div>
        <a href="/report" class="btn-quiet"><T km="បង្ហាញឪពុកម្តាយ" en="Show my parents" /> →</a>
      </div>
    </div>
  </section>
</template>
