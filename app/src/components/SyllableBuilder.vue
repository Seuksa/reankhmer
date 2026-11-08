<script setup lang="ts">
import { computed, ref } from 'vue';
import type { Consonant, Vowel } from '../lib/content';
import { play } from '../lib/audio';
import { markHeard } from '../lib/progress';
import T from './T.vue';

const props = defineProps<{ consonants: Consonant[]; vowels: Vowel[] }>();
const c = ref<Consonant>(props.consonants[0]);
const v = ref<Vowel>(props.vowels[1]);
const sub = ref<Consonant | null>(null);

const text = computed(() => c.value.char + (sub.value ? '្' + sub.value.char : '') + v.value.sign);
const vowelAudio = computed(() => (c.value.series === 1 ? v.value.audio_series1 : v.value.audio_series2));
const other = computed(() => (c.value.series === 1 ? v.value.audio_series2 : v.value.audio_series1));
const ring = (s: 1 | 2) => (s === 1 ? 'border-teal-300 bg-teal-50 text-teal-900 dark:border-teal-800 dark:bg-teal-950/50 dark:text-teal-100' : 'border-amber-300 bg-amber-50 text-amber-900 dark:border-amber-800 dark:bg-amber-950/40 dark:text-amber-100');

async function hear() {
  markHeard(`s:${c.value.id}:${v.value.id}`);
  if (c.value.audio) await play(`/${c.value.audio}`);
  if (vowelAudio.value) await play(`/${vowelAudio.value}`);
}
</script>

<template>
  <div>
    <!-- result -->
    <div class="card mb-6 flex flex-col items-center gap-4 sm:flex-row sm:justify-center">
      <div class="grid size-40 place-items-center rounded-3xl border-4" :class="ring(c.series)">
        <span lang="km" class="font-khmer-serif text-7xl leading-none">{{ text }}</span>
      </div>
      <div class="max-w-sm space-y-2 text-sm">
        <p>
          <span lang="km" class="font-khmer-serif text-xl">{{ c.char }}</span>
          <T v-if="c.series === 1" km=" ជាអក្សរសំឡេង «អ» ដូច្នេះស្រៈអានតាមសំឡេង «អ»។" en=" is a-series, so the vowel takes its a-series sound." />
          <T v-else km=" ជាអក្សរសំឡេង «អូ» ដូច្នេះស្រៈអានតាមសំឡេង «អូ»។" en=" is o-series, so the vowel takes its o-series sound." />
        </p>
        <div class="flex flex-wrap gap-2">
          <button type="button" class="btn" @click="hear"><T km="ស្តាប់" en="Listen" /> 🔊</button>
          <button v-if="other" type="button" class="btn-quiet" @click="play(`/${other}`)">
            <T km="សំឡេងស្រៈពីក្រុមម្ខាងទៀត" en="The vowel's other-series sound" />
          </button>
        </div>
        <p class="text-xs text-slate-500">
          <T km="ស្តាប់៖ ព្យញ្ជនៈ រួចសំឡេងស្រៈ។ ព្យាង្គពេញមិនទាន់មានសំឡេងថតទេ។" en="Plays the consonant, then the vowel's sound for its series. Whole syllables are not recorded yet." stack />
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
          :class="x.id === v.id ? 'border-brand-600 bg-brand-600 text-white' : 'border-slate-200 bg-white dark:border-slate-700 dark:bg-slate-900'"
          :aria-pressed="x.id === v.id" @click="v = x">{{ x.sign ? '◌' + x.sign : '◌' }}</button>
      </div>
    </section>
    <section>
      <h2 class="mb-2 font-semibold"><T km="៣. ជើងអក្សរ (ស្រេចចិត្ត)" en="3. Subscript (optional)" /></h2>
      <div class="flex flex-wrap gap-1.5">
        <button type="button" class="chip" :class="!sub && '!border-brand-600 !bg-brand-50 dark:!bg-brand-900/50'" @click="sub = null"><T km="គ្មាន" en="None" /></button>
        <button v-for="x in consonants" :key="x.id" type="button" lang="km"
          class="font-khmer-serif grid h-11 min-w-11 place-items-center rounded-xl border-2 px-1 text-2xl"
          :class="sub?.id === x.id ? 'border-brand-600 bg-brand-600 text-white' : 'border-slate-200 bg-white dark:border-slate-700 dark:bg-slate-900'"
          :aria-pressed="sub?.id === x.id" @click="sub = x">{{ '◌្' + x.char }}</button>
      </div>
    </section>
  </div>
</template>
