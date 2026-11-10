<script setup lang="ts">
/** Two voices drawn on one time line: the shaded shape is loudness, the line is the pitch (melody). */
import { computed } from 'vue';
import { semitones, type Voice } from '../lib/speak';
import T from './T.vue';

const props = defineProps<{ native: Voice | null; mine: Voice | null }>();
const W = 600, ROW = 84, AMP = 26, ST = 9; // ±9 semitones fill the row

const span = computed(() => Math.max(props.native?.dur ?? 0, props.mine?.dur ?? 0, 0.3));

function shape(v: Voice, y0: number) {
  const x = (i: number) => ((i * v.step) / span.value) * W;
  const top = v.env.map((e, i) => `${x(i).toFixed(1)},${(y0 - e * AMP).toFixed(1)}`);
  const bot = v.env.map((e, i) => `${x(i).toFixed(1)},${(y0 + e * AMP).toFixed(1)}`).reverse();
  const area = `M${top.join('L')}L${bot.join('L')}Z`;
  let line = '', pen = false;
  semitones(v).forEach((s, i) => {
    if (s == null) { pen = false; return; }
    const y = y0 - (Math.max(-ST, Math.min(ST, s)) / ST) * (ROW / 2 - 6);
    line += `${pen ? 'L' : 'M'}${x(i).toFixed(1)},${y.toFixed(1)}`;
    pen = true;
  });
  return { area, line };
}

const rows = computed(() => [
  { key: 'native', v: props.native, y: ROW / 2, cls: 'voice-native', km: 'គ្រូ', en: 'Teacher' },
  { key: 'mine', v: props.mine, y: ROW * 1.5 + 8, cls: 'voice-mine', km: 'អ្នក', en: 'You' },
].map((r) => ({ ...r, d: r.v ? shape(r.v, r.y) : null })));

const secs = (v: Voice | null) => (v ? `${v.dur.toFixed(1)} s` : '');
</script>

<template>
  <figure class="rounded-2xl border border-slate-200 p-3 dark:border-slate-700">
    <svg :viewBox="`0 0 ${W} ${ROW * 2 + 8}`" class="h-auto w-full" role="img" aria-label="Teacher's voice and your voice">
      <g v-for="r in rows" :key="r.key" :class="r.cls">
        <line x1="0" :x2="W" :y1="r.y" :y2="r.y" class="voice-axis" />
        <template v-if="r.d">
          <path :d="r.d.area" class="voice-area" />
          <path :d="r.d.line" class="voice-line" />
        </template>
      </g>
    </svg>
    <figcaption class="mt-2 flex flex-wrap items-center gap-x-4 gap-y-1 text-sm text-slate-600 dark:text-slate-400">
      <span class="inline-flex items-center gap-1.5"><i class="size-3 rounded-full bg-brand-600" /><T km="គ្រូ" en="Teacher" /> {{ secs(native) }}</span>
      <span class="inline-flex items-center gap-1.5"><i class="size-3 rounded-full bg-amber-500" /><T km="អ្នក" en="You" /> {{ secs(mine) }}</span>
      <span class="basis-full text-xs">
        <T km="ផ្ទៃពណ៌ = សំឡេងខ្លាំង/ខ្សោយ · ខ្សែ = សំឡេងឡើង/ចុះ។ មើលរាង មិនមែនកម្ពស់ទេ។" en="Shaded shape = loud and soft · line = voice going up and down. Compare the shape, not the height." />
      </span>
    </figcaption>
  </figure>
</template>

<style scoped>
.voice-axis { stroke: currentColor; opacity: 0.12; stroke-width: 1; }
.voice-area { opacity: 0.22; }
.voice-line { fill: none; stroke-width: 3.5; stroke-linecap: round; stroke-linejoin: round; }
.voice-native { color: var(--color-brand-600); }
.voice-native .voice-area { fill: var(--color-brand-500); }
.voice-native .voice-line { stroke: var(--color-brand-700); }
.voice-mine { color: var(--color-amber-500); }
.voice-mine .voice-area { fill: var(--color-amber-400); }
.voice-mine .voice-line { stroke: var(--color-amber-600); }
:global(.dark) .voice-native .voice-line { stroke: var(--color-brand-300); }
:global(.dark) .voice-mine .voice-line { stroke: var(--color-amber-300); }
</style>
