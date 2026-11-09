<script setup lang="ts">
import { computed, onBeforeUnmount, ref, watch } from 'vue';
import { onCircle, type Consonant, type Vowel } from '../lib/content';
import { play, stop } from '../lib/audio';
import { markHeard } from '../lib/progress';
import { romanOf, seriesOf, syllableAudio, vowelRoman } from '../lib/syllable';
import T from './T.vue';

const props = defineProps<{ consonants: Consonant[]; vowels: Vowel[] }>();
const c = ref<Consonant>(props.consonants[0]);
const v = ref<Vowel>(props.vowels[1]);
const sub = ref<Consonant | null>(null);

const text = computed(() => c.value.char + (sub.value ? '្' + sub.value.char : '') + v.value.sign);
const series = computed(() => seriesOf(c.value, sub.value));
const roman = computed(() => romanOf(c.value, sub.value, v.value));
const audioFor = (s: 1 | 2) => (s === 1 ? v.value.audio_series1 : v.value.audio_series2);
const otherAudio = computed(() => audioFor(series.value === 1 ? 2 : 1));
const wholeAudio = computed(() => syllableAudio(c.value, sub.value, v.value));
// The subscript decides the series only when it is not a sonorant; say so when that matters.
const clusterNote = computed(() => {
  const s = sub.value;
  if (!s || s.series === c.value.series) return null;
  return series.value === s.series ? 'sub' : 'head';
});

interface Step { key: string; char: string; label: string; note?: { km: string; en: string }; audio?: string; series?: 1 | 2 }
const steps = computed<Step[]>(() => {
  const list: Step[] = [{ key: 'c', char: c.value.char, label: c.value.name, audio: c.value.audio, series: c.value.series }];
  if (sub.value) list.push({ key: 's', char: '◌្' + sub.value.char, label: sub.value.name, note: { km: 'ជើង', en: 'subscript' }, audio: sub.value.audio, series: sub.value.series });
  list.push({
    key: 'v', char: onCircle(v.value.sign), label: vowelRoman(v.value, series.value),
    note: v.value.sign ? { km: 'ស្រៈ', en: 'vowel' } : { km: 'គ្មានស្រៈ', en: 'no vowel sign' },
    audio: audioFor(series.value),
  });
  return list;
});

const ring = (s: 1 | 2) => (s === 1 ? 'border-teal-300 bg-teal-50 text-teal-900 dark:border-teal-800 dark:bg-teal-950/50 dark:text-teal-100' : 'border-amber-300 bg-amber-50 text-amber-900 dark:border-amber-800 dark:bg-amber-950/40 dark:text-amber-100');
const neutral = 'border-slate-200 bg-white dark:border-slate-700 dark:bg-slate-900';

// Which tile is sounding: a step key, 'all' for the whole syllable, or null.
const active = ref<string | null>(null);
let run = 0; // bumps to cancel a "Spell it" sequence when something else starts
const gap = () => new Promise((r) => setTimeout(r, 250));

async function say(key: string, audio?: string) {
  if (!audio) return;
  const mine = ++run;
  active.value = key;
  await play(`/${audio.replace(/^\//, '')}`);
  if (mine === run) active.value = null;
}

async function spell() {
  const mine = ++run;
  markHeard(`s:${c.value.id}:${v.value.id}`);
  const queue: [string, string | undefined][] = [...steps.value.map((s) => [s.key, s.audio] as [string, string | undefined]), ['all', wholeAudio.value]];
  for (const [key, audio] of queue) {
    if (mine !== run) return;
    if (!audio) continue;
    active.value = key;
    await play(`/${audio.replace(/^\//, '')}`);
    if (mine !== run) return;
    await gap();
  }
  if (mine === run) active.value = null;
}

watch([c, v, sub], () => { run++; active.value = null; stop(); });
onBeforeUnmount(() => { run++; stop(); });

const on = (key: string) => active.value === key && 'ring-4 ring-brand-500 ring-offset-2 dark:ring-offset-slate-950';
</script>

<template>
  <div>
    <!-- spelling steps: ក + ា = កា -->
    <div class="card mb-6">
      <div class="flex flex-wrap items-center justify-center gap-2 sm:gap-3">
        <template v-for="(s, i) in steps" :key="s.key">
          <span v-if="i > 0" aria-hidden="true" class="text-2xl text-slate-400">+</span>
          <button type="button" class="flex min-w-20 flex-col items-center gap-1 rounded-2xl border-2 px-3 pb-2 pt-3 transition"
            :class="[s.series ? ring(s.series) : neutral, on(s.key)]"
            :aria-label="`${s.char} ${s.label}`" @click="say(s.key, s.audio)">
            <span lang="km" class="font-khmer-serif text-5xl leading-tight">{{ s.char }}</span>
            <span class="text-sm font-medium">{{ s.label }} <span aria-hidden="true">🔊</span></span>
            <span v-if="s.note" class="text-xs opacity-70"><T :km="s.note.km" :en="s.note.en" /></span>
          </button>
        </template>
        <span aria-hidden="true" class="text-2xl text-slate-400">=</span>
        <div class="flex min-w-28 flex-col items-center gap-1 rounded-3xl border-4 px-4 pb-2 pt-3 transition" :class="[ring(series), on('all')]">
          <span lang="km" class="font-khmer-serif text-6xl leading-tight">{{ text }}</span>
          <span class="text-lg font-semibold">{{ roman }}</span>
          <button v-if="wholeAudio" type="button" class="chip" @click="say('all', wholeAudio)">🔊 <T km="ស្តាប់" en="Listen" /></button>
          <span v-else class="text-xs opacity-70"><T km="មិនទាន់ថតសំឡេង" en="not recorded yet" /></span>
        </div>
      </div>

      <div class="mt-5 flex flex-wrap justify-center gap-2">
        <button type="button" class="btn" @click="spell"><T km="ប្រកប" en="Spell it" /> ▶</button>
        <button v-if="otherAudio" type="button" class="btn-quiet" @click="say('other', otherAudio)">
          <T km="សំឡេងស្រៈពីក្រុមម្ខាងទៀត" en="The vowel's other-series sound" />
        </button>
      </div>

      <div class="mx-auto mt-4 max-w-xl space-y-2 text-center text-sm">
        <p v-if="!clusterNote">
          <span lang="km" class="font-khmer-serif text-xl">{{ c.char }}</span>
          <T v-if="series === 1" km=" ជាអក្សរសំឡេង «អ» ដូច្នេះស្រៈអានតាមសំឡេង «អ»។" en=" is a-series, so the vowel takes its a-series sound." />
          <T v-else km=" ជាអក្សរសំឡេង «អូ» ដូច្នេះស្រៈអានតាមសំឡេង «អូ»។" en=" is o-series, so the vowel takes its o-series sound." />
        </p>
        <p v-else-if="clusterNote === 'sub' && sub">
          <T :km="`ព្យាង្គនេះអានតាមក្រុមរបស់ជើង «${sub.char}» (សំឡេង «${series === 1 ? 'អ' : 'អូ'}»)។`"
            :en="`This cluster takes the series of the subscript ${sub.char} (${series === 1 ? 'a' : 'o'}-series).`" stack />
        </p>
        <p v-else-if="sub">
          <T :km="`ជើង «${sub.char}» មិនប្តូរក្រុមទេ ដូច្នេះអានតាមក្រុមរបស់ «${c.char}» (សំឡេង «${series === 1 ? 'អ' : 'អូ'}»)។`"
            :en="`Subscript ${sub.char} is a sonorant and doesn't change the series, so it reads in ${c.char}'s ${series === 1 ? 'a' : 'o'}-series.`" stack />
        </p>
        <p class="text-xs text-slate-500">
          <T km="ចុចលើអក្សរនីមួយៗ ដើម្បីស្តាប់។ អក្សរឡាតាំងគ្រាន់តែជាជំនួយប៉ុណ្ណោះ។" en="Tap each part to hear it. The Latin spelling is only a guide to the sound." stack />
        </p>
        <p v-if="sub" class="text-xs text-amber-700 dark:text-amber-300">
          <T km="ជើងអក្សរអាចផ្លាស់ប្តូរសំឡេងបាន — សូមពិនិត្យជាមួយមេរៀនជំពូក ៣។" en="A subscript can change the sound; check it against the Chapter 3 lessons." stack />
        </p>
      </div>
    </div>

    <!-- pickers -->
    <section class="mb-5">
      <h2 class="mb-2 font-semibold"><T km="១. ព្យញ្ជនៈ" en="1. Consonant" /></h2>
      <div class="flex flex-wrap gap-1.5">
        <button v-for="x in consonants" :key="x.id" type="button" lang="km"
          class="font-khmer-serif grid size-11 place-items-center rounded-xl border-2 text-2xl"
          :class="x.id === c.id ? 'border-brand-600 bg-brand-600 text-white' : ring(x.series)"
          :aria-pressed="x.id === c.id" @click="c = x">{{ x.char }}</button>
      </div>
    </section>
    <section class="mb-5">
      <h2 class="mb-2 font-semibold"><T km="២. ស្រៈ" en="2. Vowel" /></h2>
      <div class="flex flex-wrap gap-1.5">
        <button v-for="x in vowels" :key="x.id" type="button" lang="km"
          class="font-khmer-serif grid h-11 min-w-11 place-items-center rounded-xl border-2 px-1 text-2xl"
          :class="x.id === v.id ? 'border-brand-600 bg-brand-600 text-white' : neutral"
          :aria-pressed="x.id === v.id" @click="v = x">{{ onCircle(x.sign) }}</button>
      </div>
    </section>
    <section>
      <h2 class="mb-2 font-semibold"><T km="៣. ជើងអក្សរ (ស្រេចចិត្ត)" en="3. Subscript (optional)" /></h2>
      <div class="flex flex-wrap gap-1.5">
        <button type="button" class="chip" :class="!sub && '!border-brand-600 !bg-brand-50 dark:!bg-brand-900/50'" @click="sub = null"><T km="គ្មាន" en="None" /></button>
        <button v-for="x in consonants" :key="x.id" type="button" lang="km"
          class="font-khmer-serif grid h-11 min-w-11 place-items-center rounded-xl border-2 px-1 text-2xl"
          :class="sub?.id === x.id ? 'border-brand-600 bg-brand-600 text-white' : neutral"
          :aria-pressed="sub?.id === x.id" @click="sub = x">{{ '◌្' + x.char }}</button>
      </div>
    </section>
  </div>
</template>
