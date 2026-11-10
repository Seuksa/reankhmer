<script setup lang="ts">
import { computed, nextTick, onMounted, ref, watch } from 'vue';
import type { Consonant } from '../lib/content';
import { play } from '../lib/audio';
import { loadProgress, markHeard, progress } from '../lib/progress';
import T from './T.vue';
import { consonantSlugs } from '../lib/slug';

const props = defineProps<{ letters: Consonant[] }>();
// /writing?letter=kor opens that letter (links from the letter pages). Rendered client-only, so location exists.
const startAt = (() => {
  if (typeof location === 'undefined') return 0;
  const q = new URLSearchParams(location.search).get('letter');
  if (!q) return 0;
  const slugs = consonantSlugs(props.letters);
  const i = props.letters.findIndex((c) => slugs.get(c.id) === q || c.char === q);
  return Math.max(0, i);
})();
const idx = ref(startAt);
const letter = computed(() => props.letters[idx.value]);

// ---------- 2006 animation (Flash via Ruffle, loaded only on this page) ----------
const stage = ref<HTMLDivElement | null>(null);
const flashState = ref<'idle' | 'loading' | 'ready' | 'error'>('idle');
let player: (HTMLElement & { ruffle: () => { load: (o: unknown) => Promise<void> } }) | null = null;

type RuffleWin = Window & { RufflePlayer?: { config?: unknown; newest: () => { createPlayer: () => typeof player } } };

function loadRuffle(): Promise<void> {
  const w = window as RuffleWin;
  if (w.RufflePlayer?.newest) return Promise.resolve();
  w.RufflePlayer = { ...(w.RufflePlayer ?? {}), config: { publicPath: '/ruffle/', autoplay: 'on', unmuteOverlay: 'hidden', splashScreen: false, contextMenu: 'off', letterbox: 'on', backgroundColor: '#ffffff' } } as RuffleWin['RufflePlayer'];
  return new Promise((ok, fail) => {
    const s = document.createElement('script');
    s.src = '/ruffle/ruffle.js';
    s.onload = () => ok();
    s.onerror = () => fail(new Error('ruffle'));
    document.head.appendChild(s);
  });
}

async function showFlash() {
  const swf = letter.value.legacy_swf?.split('/').pop();
  if (!swf || !stage.value) return;
  flashState.value = 'loading';
  try {
    await loadRuffle();
    if (!player) {
      player = (window as RuffleWin).RufflePlayer!.newest().createPlayer();
      player!.style.width = '100%';
      player!.style.height = '100%';
      stage.value.appendChild(player!);
    }
    await player!.ruffle().load({ url: `/assets/flash/${swf}` });
    flashState.value = 'ready';
  } catch {
    flashState.value = 'error';
  }
}

// ---------- tracing pad ----------
const SIZE = 320;
const canvas = ref<HTMLCanvasElement | null>(null);
const score = ref<{ cover: number; inside: number } | null>(null);
let drawing = false;
let last: { x: number; y: number } | null = null;
const FONT = '"Noto Serif Khmer Variable", "Kantumruy Pro Variable", serif';

function glyph(ctx: CanvasRenderingContext2D, alpha: number) {
  ctx.save();
  ctx.globalAlpha = alpha;
  ctx.fillStyle = '#0f766e';
  ctx.font = `${SIZE * 0.62}px ${FONT}`;
  ctx.textAlign = 'center';
  ctx.textBaseline = 'middle';
  ctx.fillText(letter.value.char, SIZE / 2, SIZE * 0.47);
  ctx.restore();
}

function guides(ctx: CanvasRenderingContext2D) {
  ctx.save();
  ctx.strokeStyle = 'rgba(100,116,139,.25)';
  ctx.lineWidth = 1;
  ctx.setLineDash([6, 6]);
  for (const y of [SIZE * 0.25, SIZE * 0.5, SIZE * 0.75]) { ctx.beginPath(); ctx.moveTo(0, y); ctx.lineTo(SIZE, y); ctx.stroke(); }
  ctx.restore();
}

async function reset() {
  score.value = null;
  const c = canvas.value;
  if (!c) return;
  await document.fonts.load(`100px ${FONT}`, letter.value.char).catch(() => {});
  const ctx = c.getContext('2d')!;
  ctx.clearRect(0, 0, SIZE, SIZE);
  ctx.fillStyle = '#ffffff';
  ctx.fillRect(0, 0, SIZE, SIZE);
  guides(ctx);
  glyph(ctx, 0.14);
}

const ink = document.createElement('canvas');
ink.width = ink.height = SIZE;

function pos(e: PointerEvent) {
  const r = canvas.value!.getBoundingClientRect();
  return { x: ((e.clientX - r.left) / r.width) * SIZE, y: ((e.clientY - r.top) / r.height) * SIZE };
}
function line(ctx: CanvasRenderingContext2D, a: { x: number; y: number }, b: { x: number; y: number }, color: string) {
  ctx.strokeStyle = color;
  ctx.lineWidth = SIZE * 0.05;
  ctx.lineCap = ctx.lineJoin = 'round';
  ctx.beginPath(); ctx.moveTo(a.x, a.y); ctx.lineTo(b.x, b.y); ctx.stroke();
}
function down(e: PointerEvent) {
  drawing = true; last = pos(e); score.value = null;
  canvas.value!.setPointerCapture(e.pointerId);
  move(e);
}
function move(e: PointerEvent) {
  if (!drawing || !last) return;
  const p = pos(e);
  line(canvas.value!.getContext('2d')!, last, p, '#1e293b');
  line(ink.getContext('2d')!, last, p, '#000');
  last = p;
}
function up() { drawing = false; last = null; }

function clearAll() {
  ink.getContext('2d')!.clearRect(0, 0, SIZE, SIZE);
  void reset();
}

/** cover = share of the letter's shape you traced; inside = share of your ink that stayed on the letter. */
function check() {
  const mask = document.createElement('canvas');
  mask.width = mask.height = SIZE;
  const m = mask.getContext('2d')!;
  glyph(m, 1);
  const g = m.getImageData(0, 0, SIZE, SIZE).data;
  const d = ink.getContext('2d')!.getImageData(0, 0, SIZE, SIZE).data;
  let shape = 0, hit = 0, inked = 0;
  for (let i = 3; i < g.length; i += 4 * 2) {
    const onShape = g[i] > 60, onInk = d[i] > 60;
    if (onShape) shape++;
    if (onInk) inked++;
    if (onShape && onInk) hit++;
  }
  score.value = { cover: shape ? hit / shape : 0, inside: inked ? hit / inked : 0 };
  if (score.value.cover >= 0.6 && score.value.inside >= 0.6) markHeard(`w:${letter.value.id}`);
}
const stars = computed(() => {
  if (!score.value) return 0;
  const s = Math.min(score.value.cover, score.value.inside);
  return s >= 0.75 ? 3 : s >= 0.6 ? 2 : s >= 0.4 ? 1 : 0;
});

watch(idx, async () => { ink.getContext('2d')!.clearRect(0, 0, SIZE, SIZE); await nextTick(); void reset(); void showFlash(); });
onMounted(() => {
  void loadProgress(); void reset(); void showFlash();
  if (startAt) document.querySelector('[role=tab][aria-selected=true]')?.scrollIntoView({ block: 'nearest', inline: 'center' });
});
</script>

<template>
  <div>
    <!-- letter picker -->
    <div class="mb-5 flex gap-1.5 overflow-x-auto pb-2" role="tablist" aria-label="Letters">
      <button
        v-for="(c, i) in letters"
        :key="c.id"
        type="button"
        role="tab"
        :aria-selected="i === idx"
        lang="km"
        class="font-khmer-serif relative grid size-11 shrink-0 place-items-center rounded-xl border-2 text-2xl"
        :class="[
          i === idx ? 'border-brand-600 bg-brand-600 text-white' : c.series === 1 ? 'border-teal-200 bg-teal-50 text-teal-900 dark:border-teal-900 dark:bg-teal-950/40 dark:text-teal-100' : 'border-amber-200 bg-amber-50 text-amber-900 dark:border-amber-900 dark:bg-amber-950/40 dark:text-amber-100',
        ]"
        @click="idx = i"
      >{{ c.char }}<span v-if="progress.heard[`w:${c.id}`]" class="absolute -top-1 -right-1 text-[0.6rem] text-emerald-600">●</span></button>
    </div>

    <div class="grid gap-6 lg:grid-cols-2">
      <section>
        <h2 class="mb-2 font-semibold"><T km="មើលរបៀបសរសេរ (ឆ្នាំ ២០០៦)" en="Watch how it is written (2006 animation)" /></h2>
        <div class="relative aspect-[6/5] overflow-hidden rounded-2xl border border-slate-200 bg-white dark:border-slate-800">
          <div ref="stage" class="absolute inset-0" />
          <p v-if="flashState === 'loading'" class="absolute inset-0 grid place-items-center text-sm text-slate-500"><T km="កំពុងផ្ទុក…" en="Loading…" /></p>
          <p v-if="flashState === 'error'" class="absolute inset-0 grid place-items-center p-4 text-center text-sm text-slate-500">
            <T km="មិនអាចបង្ហាញចលនាបានទេ។ សូមភ្ជាប់អ៊ីនធឺណិតម្តង ហើយសាកម្តងទៀត។" en="The animation could not load. Connect to the internet once and try again." stack />
          </p>
        </div>
        <p class="mt-2 text-xs text-slate-500">
          <T km="ចុច ▶ ក្នុងរូប ដើម្បីមើលការសរសេរម្តងមួយគូស។" en="Press ▶ inside the picture to watch the letter drawn stroke by stroke." />
        </p>
        <p v-if="letter.legacy_swf_note" role="note" class="mt-2 rounded-xl border border-amber-300 bg-amber-50 p-3 text-sm text-amber-900 dark:border-amber-800 dark:bg-amber-950/40 dark:text-amber-100">
          ⚠️ <T :km="letter.legacy_swf_note.km" :en="letter.legacy_swf_note.en" stack />
        </p>
      </section>

      <section>
        <div class="mb-2 flex items-center gap-3">
          <h2 class="font-semibold"><T km="សរសេរតាម" en="Trace it" /></h2>
          <button v-if="letter.audio" type="button" class="chip" @click="play(`/${letter.audio}`)">🔊 {{ letter.roman }}</button>
        </div>
        <canvas
          ref="canvas"
          :width="SIZE"
          :height="SIZE"
          class="aspect-square w-full max-w-[420px] touch-none rounded-2xl border border-slate-200 dark:border-slate-800"
          aria-label="Tracing pad: draw over the faded letter"
          @pointerdown="down"
          @pointermove="move"
          @pointerup="up"
          @pointercancel="up"
          @pointerleave="up"
        />
        <div class="mt-3 flex flex-wrap items-center gap-2">
          <button type="button" class="btn" @click="check"><T km="ពិនិត្យ" en="Check" /></button>
          <button type="button" class="btn-quiet" @click="clearAll"><T km="លុប" en="Clear" /></button>
          <button type="button" class="btn-quiet ml-auto" :disabled="idx >= letters.length - 1" @click="idx++"><T km="បន្ទាប់" en="Next" /> →</button>
        </div>
        <p v-if="score" class="mt-3" aria-live="polite">
          <span class="text-2xl text-amber-500">{{ '★'.repeat(stars) }}{{ '☆'.repeat(3 - stars) }}</span>
          <span class="ml-2 text-sm text-slate-500">
            <T km="គ្របលើអក្សរ" en="covered" /> {{ Math.round(score.cover * 100) }}% ·
            <T km="នៅលើបន្ទាត់" en="on the letter" /> {{ Math.round(score.inside * 100) }}%
          </span>
        </p>
      </section>
    </div>
  </div>
</template>
