<script setup lang="ts">
import type { NumberWord } from '../lib/content';
import { khmerDigits } from '../lib/content';
import { play } from '../lib/audio';
import { markHeard } from '../lib/progress';

defineProps<{ numbers: NumberWord[] }>();

const SYMBOLS: Record<string, { show: string; en: string }> = {
  cent: { show: '%', en: 'percent' },
  comma: { show: ',', en: 'comma' },
  minus: { show: '−', en: 'minus' },
  point: { show: '.', en: 'point' },
};
const big = (n: NumberWord) => (n.value !== undefined ? khmerDigits(n.value.toLocaleString('en-US')) : SYMBOLS[n.key]?.show ?? n.key);
const small = (n: NumberWord) => (n.value !== undefined ? n.value.toLocaleString('en-US') : SYMBOLS[n.key]?.en ?? n.key);

function hear(n: NumberWord) {
  markHeard(`n:${n.key}`);
  void play(`/${n.audio}`);
}
</script>

<template>
  <ul class="grid grid-cols-2 gap-3 sm:grid-cols-3 lg:grid-cols-4">
    <li v-for="n in numbers" :key="n.key">
      <button type="button" class="card flex w-full items-center justify-between gap-3 text-left hover:border-brand-500" @click="hear(n)">
        <span>
          <span lang="km" class="font-khmer-serif block text-3xl">{{ big(n) }}</span>
          <span class="text-sm text-slate-500">{{ small(n) }}</span>
        </span>
        <svg viewBox="0 0 24 24" class="size-6 text-brand-700 dark:text-brand-200" fill="currentColor" aria-hidden="true"><path d="M4 9v6h4l5 4V5L8 9zm12.5 3a4.5 4.5 0 0 0-2.5-4v8a4.5 4.5 0 0 0 2.5-4z" /></svg>
      </button>
    </li>
  </ul>
</template>
