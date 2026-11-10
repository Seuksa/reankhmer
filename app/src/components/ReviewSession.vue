<script setup lang="ts">
import { computed, onMounted, ref } from 'vue';
import { play } from '../lib/audio';
import { grade, options, ratingFor, sessionIds, NEW_PER_DAY, type ReviewItem } from '../lib/review';
import { markHeard, progress, updateDay } from '../lib/progress';
import T from './T.vue';

const props = defineProps<{ items: ReviewItem[] }>();
const byId = new Map(props.items.map((i) => [i.id, i]));

const loading = ref(true);
const queue = ref<string[]>([]);
const counts = ref({ due: 0, fresh: 0 });
const current = ref<ReviewItem | null>(null);
const choices = ref<string[]>([]);
const picked = ref<string | null>(null);
const slipped = ref(false);
const shownAt = ref(0);
const done = ref({ right: 0, total: 0 });
const finished = ref(false);

onMounted(async () => {
  const { due, fresh } = await sessionIds(props.items);
  counts.value = { due: due.length, fresh: fresh.length };
  queue.value = [...due, ...fresh];
  loading.value = false;
  if (!queue.value.length) updateDay({ review: true }); // nothing due today: the review part of the duty is done
});

const nextDue = computed(() => {
  const all = Object.values(progress.cards ?? {}).map((c) => c.due).sort();
  return all.find((d) => d > new Date().toISOString()) ?? null;
});

function start() { done.value = { right: 0, total: 0 }; finished.value = false; void next(); }

async function next() {
  picked.value = null;
  slipped.value = false;
  const id = queue.value.shift();
  if (!id) { current.value = null; finished.value = true; updateDay({ review: true }); return; }
  current.value = byId.get(id) ?? null;
  if (!current.value) return next();
  choices.value = options(current.value, props.items);
  await play(current.value.audio);
  shownAt.value = Date.now();
}

async function choose(c: string) {
  const it = current.value;
  if (!it || picked.value === it.answer) return;
  if (c !== it.answer) {
    if (!slipped.value && picked.value === null) {
      // First answer wrong: score Again now, show the right one, and see it again later in this session.
      picked.value = c;
      grade(it.id, ratingFor(false, false, 0));
      done.value.total++;
      queue.value.splice(Math.min(3, queue.value.length), 0, it.id);
      await play(it.audio);
      slipped.value = true;
    }
    return;
  }
  picked.value = c;
  if (!slipped.value) {
    grade(it.id, ratingFor(true, false, Date.now() - shownAt.value));
    done.value.right++;
    done.value.total++;
  }
  markHeard(it.id);
  setTimeout(next, slipped.value ? 900 : 600);
}

const label = (it: ReviewItem) =>
  it.kind === 'consonant' ? { km: 'ព្យញ្ជនៈណា?', en: 'Which consonant?' }
  : it.kind === 'vowel' ? { km: 'សំឡេងណា?', en: 'Which sound?' }
  : it.kind === 'word' ? { km: 'សរសេរយ៉ាងដូចម្តេច?', en: 'Which spelling?' }
  : { km: 'លេខណា?', en: 'Which number?' };
const fmtDate = (iso: string) => new Date(iso).toLocaleString(undefined, { weekday: 'short', hour: '2-digit', minute: '2-digit' });
</script>

<template>
  <div>
    <p v-if="loading" class="text-slate-500">…</p>

    <!-- Start screen -->
    <div v-else-if="!current && !finished" class="card text-center">
      <p class="text-lg">
        <T km="ត្រូវរំលឹកថ្ងៃនេះ" en="Due today" />: <b>{{ counts.due }}</b> ·
        <T km="ថ្មី" en="New" />: <b>{{ counts.fresh }}</b>
      </p>
      <p class="mt-2 text-sm text-slate-500">
        <T :km="`ស្តាប់ ហើយជ្រើសរើសចម្លើយត្រូវ។ កាតថ្មីរហូតដល់ ${NEW_PER_DAY} ក្នុងមួយថ្ងៃ។`" :en="`Listen, then pick the right answer. Up to ${NEW_PER_DAY} new cards a day.`" stack />
      </p>
      <button v-if="counts.due + counts.fresh > 0" class="btn mt-4" @click="start"><T km="ចាប់ផ្តើម" en="Start review" /></button>
      <p v-else class="mt-4 font-medium text-emerald-700 dark:text-emerald-300">
        ✓ <T km="គ្មានអ្វីត្រូវរំលឹកទេ។ ត្រឡប់មកវិញពេលក្រោយ!" en="All caught up. Come back later!" />
        <span v-if="nextDue" class="block text-sm font-normal text-slate-500"><T km="បន្ទាប់" en="Next" />: {{ fmtDate(nextDue) }}</span>
      </p>
    </div>

    <!-- Question -->
    <div v-else-if="current" class="card">
      <div class="mb-4 flex items-center justify-between gap-3">
        <p class="font-medium"><T v-bind="label(current)" /></p>
        <span class="text-sm text-slate-500">{{ queue.length + 1 }} <T km="នៅសល់" en="left" /></span>
      </div>
      <button class="btn mb-5 w-full sm:w-auto" @click="play(current.audio)">
        <svg viewBox="0 0 24 24" class="size-5" fill="currentColor" aria-hidden="true"><path d="M4 9v6h4l5 4V5L8 9zm12.5 3a4.5 4.5 0 0 0-2.5-4v8a4.5 4.5 0 0 0 2.5-4z" /></svg>
        <T km="ស្តាប់ម្តងទៀត" en="Hear again" />
      </button>
      <div class="grid grid-cols-2 gap-3 sm:grid-cols-4">
        <button
          v-for="c in choices"
          :key="c"
          type="button"
          lang="km"
          class="font-khmer-serif aspect-[4/3] rounded-2xl border-2 transition"
          :class="[
            current.kind === 'word' ? 'text-2xl sm:text-3xl px-2' : 'text-5xl',
            picked && c === current.answer ? 'border-emerald-500 bg-emerald-50 dark:bg-emerald-950/50' :
            picked === c ? 'border-rose-500 bg-rose-50 dark:bg-rose-950/40' :
            current.kind === 'word' ? 'border-slate-200 hover:border-brand-500 dark:border-slate-700' : current.series === 2 ? 'border-amber-200 hover:border-amber-400 dark:border-amber-900' : 'border-teal-200 hover:border-teal-400 dark:border-teal-900',
          ]"
          @click="choose(c)"
        >{{ c }}</button>
      </div>
      <p v-if="slipped" class="mt-4 text-sm text-slate-600 dark:text-slate-400" aria-live="polite">
        <T km="ចម្លើយត្រូវបានបង្ហាញជាពណ៌បៃតង។ ចុចលើវា ដើម្បីបន្ត។" en="The right answer is in green. Tap it to continue; this card comes back soon." />
      </p>
    </div>

    <!-- Done -->
    <div v-else class="card text-center" aria-live="polite">
      <p class="text-3xl font-semibold">{{ done.right }} / {{ done.total }}</p>
      <p class="mt-1 text-slate-500"><T km="ត្រូវលើកដំបូង" en="right on the first try" /></p>
      <p class="mt-3 font-medium text-emerald-700 dark:text-emerald-300"><T km="ល្អណាស់! ជួបគ្នាថ្ងៃស្អែក។" en="Well done! See you tomorrow." /></p>
      <a href="/practice" class="btn-quiet mt-4"><T km="ហាត់ផ្សេងទៀត" en="More practice" /></a>
    </div>
  </div>
</template>
