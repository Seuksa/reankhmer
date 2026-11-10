<script setup lang="ts">
/**
 * Speaking practice: Listen (native) → Record me → Compare (native, then me), with a picture of
 * both voices. Recordings stay on this device (IndexedDB), only the last few are kept.
 * No automatic scoring: the learner listens and compares.
 */
import { computed, nextTick, onBeforeUnmount, onMounted, ref, watch } from 'vue';
import { play, playing, stop as stopAudio } from '../lib/audio';
import {
  KEEP, MAX_SECONDS, deleteAllTakes, describe, loadTake, micSupported, saveTake, startRecording, takeIds,
  type MicError, type Recording, type SpeakSet, type Voice,
} from '../lib/speak';
import T from './T.vue';
import VoicePicture from './VoicePicture.vue';

const props = defineProps<{ sets: SpeakSet[] }>();

const GROUPS = [
  { key: 'letters', km: 'អក្សរ', en: 'Letters' },
  { key: 'vowels', km: 'ស្រៈ', en: 'Vowels' },
  { key: 'words', km: 'ពាក្យ', en: 'Words' },
  { key: 'sentences', km: 'ប្រយោគ', en: 'Sentences' },
] as const;

const setId = ref(props.sets[0]?.id ?? '');
const set = computed(() => props.sets.find((s) => s.id === setId.value) ?? props.sets[0]);
const index = ref(0);
const item = computed(() => set.value?.items[index.value]);
const textSize = computed(() => {
  const n = [...(item.value?.text ?? '')].length;
  return n <= 3 ? 'text-7xl sm:text-8xl' : n <= 8 ? 'text-5xl sm:text-6xl' : n <= 20 ? 'text-3xl sm:text-4xl' : 'text-2xl sm:text-3xl';
});

// ---- recordings ----
const supported = ref(true);
const micError = ref<MicError | null>(null);
const recording = ref<Recording | null>(null);
const level = ref(0);
const elapsed = ref(0);
const take = ref<Blob | null>(null);
const takeUrl = ref<string | null>(null);
const saved = ref(new Set<string>());
const nativeVoice = ref<Voice | null>(null);
const myVoice = ref<Voice | null>(null);
const comparing = ref(false);
let meter = 0;
// The intro and tips live behind a Guide toggle so the practice card sits near the top.
const showGuide = ref(false);
function toggleGuide() {
  showGuide.value = !showGuide.value;
  try { localStorage.setItem('rk-speak-guide', showGuide.value ? '1' : '0'); } catch {}
}
let loadToken = 0;

onMounted(async () => {
  supported.value = micSupported();
  try { showGuide.value = localStorage.getItem('rk-speak-guide') === '1'; } catch {}
  const q = new URLSearchParams(location.search).get('set');
  if (q && props.sets.some((s) => s.id === q)) setId.value = q;
  saved.value = new Set(await takeIds());
  await showItem();
  addEventListener('keydown', onKey);
});
onBeforeUnmount(() => { removeEventListener('keydown', onKey); recording.value?.stop(); setTakeUrl(null); });

function setTakeUrl(b: Blob | null) {
  if (takeUrl.value) URL.revokeObjectURL(takeUrl.value);
  takeUrl.value = b ? URL.createObjectURL(b) : null;
}

async function showItem() {
  const it = item.value;
  const token = ++loadToken;
  stopAudio(); recording.value?.stop();
  take.value = null; setTakeUrl(null); myVoice.value = null; nativeVoice.value = null;
  if (!it) return;
  const blob = await loadTake(it.id);
  if (token !== loadToken) return;
  if (blob) { take.value = blob; setTakeUrl(blob); }
  // pictures are made in the background so the buttons are ready straight away
  void fetch(it.audio).then((r) => r.arrayBuffer()).then(describe).then((v) => { if (token === loadToken) nativeVoice.value = v; }).catch(() => {});
  if (blob) void describe(blob).then((v) => { if (token === loadToken) myVoice.value = v; });
}

watch(setId, () => { index.value = 0; history.replaceState(null, '', `?set=${setId.value}`); void showItem(); });
function go(i: number) {
  const n = set.value.items.length;
  index.value = (i + n) % n;
  void showItem();
}

const listen = () => item.value && play(item.value.audio);

async function toggleRecord() {
  if (recording.value) return recording.value.stop();
  if (!item.value) return;
  stopAudio(); micError.value = null;
  const it = item.value;
  try {
    const rec = await startRecording();
    recording.value = rec;
    const t0 = performance.now();
    const tick = () => {
      level.value = rec.level();
      elapsed.value = (performance.now() - t0) / 1000;
      meter = requestAnimationFrame(tick);
    };
    tick();
    const blob = await rec.done;
    cancelAnimationFrame(meter);
    recording.value = null; level.value = 0;
    // a tap-tap under half a second is a slip, not a take: keep the previous recording
    if (item.value?.id !== it.id || blob.size < 500 || performance.now() - t0 < 500) return;
    take.value = blob; setTakeUrl(blob); myVoice.value = null;
    await saveTake(it.id, blob).catch(() => {});
    saved.value = new Set(await takeIds());
    void describe(blob).then((v) => { if (item.value?.id === it.id) myVoice.value = v; });
    await compare();
  } catch (e) {
    recording.value = null;
    micError.value = (e as { code?: MicError }).code ?? 'other';
  }
}

const playMine = () => takeUrl.value && play(takeUrl.value);

async function compare() {
  if (!item.value || !takeUrl.value) return;
  comparing.value = true;
  try {
    await play(item.value.audio);
    if (!comparing.value) return;
    await new Promise((r) => setTimeout(r, 350));
    if (comparing.value && takeUrl.value) await play(takeUrl.value);
  } finally { comparing.value = false; }
}

async function forget() {
  await deleteAllTakes().catch(() => {});
  saved.value = new Set();
  take.value = null; setTakeUrl(null); myVoice.value = null;
}

function onKey(e: KeyboardEvent) {
  const el = e.target as HTMLElement;
  if (el.closest('input, select, textarea') || e.ctrlKey || e.metaKey || e.altKey) return;
  if (e.key === ' ' && supported.value) { e.preventDefault(); void toggleRecord(); }
  else if (e.key === 'ArrowRight') go(index.value + 1);
  else if (e.key === 'ArrowLeft') go(index.value - 1);
  else if (e.key === 'l' || e.key === 'L') void listen();
  else if (e.key === 'c' || e.key === 'C') void compare();
  else return;
  (document.activeElement as HTMLElement | null)?.blur?.();
}

const isPlayingNative = computed(() => !!item.value && playing.value === item.value.audio);
const isPlayingMine = computed(() => !!takeUrl.value && playing.value === takeUrl.value);
watch(index, () => nextTick(() => document.querySelector('[data-current-chip]')?.scrollIntoView({ block: 'nearest', inline: 'center' })));
</script>

<template>
  <div v-if="set" class="space-y-3">
    <div class="flex items-center gap-3">
      <label class="block min-w-0 max-w-xl flex-1">
        <span class="sr-only"><T km="ជ្រើសអ្វីដែលត្រូវហាត់" en="What to practise" /></span>
        <select v-model="setId" class="w-full rounded-xl border border-slate-300 bg-white px-3 py-2 dark:border-slate-700 dark:bg-slate-900">
          <optgroup v-for="g in GROUPS" :key="g.key" :label="`${g.km} · ${g.en}`">
            <option v-for="s in sets.filter((x) => x.group === g.key)" :key="s.id" :value="s.id">{{ s.km }}{{ s.en !== s.km ? ` · ${s.en}` : '' }} ({{ s.items.length }})</option>
          </optgroup>
        </select>
      </label>
      <button type="button" class="btn-quiet shrink-0 !py-1.5 text-sm" :aria-expanded="showGuide" @click="toggleGuide">
        <T km="ការណែនាំ" en="Guide" /> {{ showGuide ? '▴' : '▾' }}
      </button>
    </div>
    <div v-if="showGuide" class="card space-y-2 text-sm text-slate-600 dark:text-slate-400">
      <p><T km="ស្តាប់គ្រូ ថតសំឡេងខ្លួនឯង រួចប្រៀបធៀប។ សំឡេងរបស់អ្នកនៅលើឧបករណ៍នេះតែប៉ុណ្ណោះ។" en="Listen to the teacher, record yourself, then compare. Your voice stays on this device." stack /></p>
      <ul class="list-disc space-y-1 pl-5">
        <li><T km="ស្តាប់គ្រូ ២-៣ ដង រួចថតសំឡេងខ្លួនឯង ហើយចុចប្រៀបធៀប៖ គ្រូ រួចអ្នក។ ថតម្តងទៀតរហូតដល់ស្តាប់ទៅដូចគ្នា។" en="Listen to the teacher 2–3 times, record yourself, then Compare: teacher first, then you. Record again until they sound alike." /></li>
        <li><T km="រូបភាព៖ ផ្ទៃពណ៌ជាសំឡេងខ្លាំង/ខ្សោយ ខ្សែជាសំឡេងឡើង/ចុះ។ ព្យាយាមឲ្យរាង និងប្រវែងប្រហាក់ប្រហែលគ្នា។" en="The picture: the shaded shape is loud and soft, the line is the voice going up and down. Try to match the shape and the length." /></li>
        <li><T km="ក្តារចុច៖ Space ថត/ឈប់ · L ស្តាប់ · C ប្រៀបធៀប · ← → មុន/បន្ទាប់" en="Keyboard: Space record/stop · L listen · C compare · ← → previous/next" /></li>
        <li><T :km="`សំឡេងរបស់អ្នកនៅលើឧបករណ៍នេះតែប៉ុណ្ណោះ មិនផ្ញើទៅណាទេ។ រក្សាទុកតែ ${KEEP} ចុងក្រោយ។`" :en="`Your voice stays on this device and is never sent anywhere. Only the last ${KEEP} recordings are kept.`" /></li>
      </ul>
      <button v-if="saved.size" type="button" class="btn-quiet mt-3 !py-1 text-sm" @click="forget">
        <T km="លុបការថតរបស់ខ្ញុំទាំងអស់" en="Delete all my recordings" /> ({{ saved.size }})
      </button>
    </div>

    <div v-if="item" class="card text-center">
      <div class="flex items-center justify-between text-sm text-slate-500">
        <button type="button" class="btn-quiet !px-3 !py-1" aria-label="Previous" @click="go(index - 1)">←</button>
        <span>{{ index + 1 }} / {{ set.items.length }}</span>
        <button type="button" class="btn-quiet !px-3 !py-1" aria-label="Next" @click="go(index + 1)">→</button>
      </div>

      <p lang="km" class="font-khmer-serif py-1 leading-snug text-slate-900 dark:text-slate-50" :class="textSize">{{ item.text }}</p>
      <p v-if="item.roman || item.en" class="mb-3 text-slate-500">
        <span v-if="item.roman">({{ item.roman }})</span><span v-if="item.roman && item.en"> · </span><span v-if="item.en">{{ item.en }}</span>
      </p>

      <div class="flex flex-wrap items-stretch justify-center gap-3">
        <button type="button" class="speak-step" :class="isPlayingNative && !comparing ? 'speak-step-on' : ''" @click="listen">
          <span class="speak-num">1</span>
          <svg viewBox="0 0 24 24" class="size-6" fill="currentColor" aria-hidden="true"><path d="M4 9v6h4l5 4V5L8 9zm12.5 3a4.5 4.5 0 0 0-2.5-4v8a4.5 4.5 0 0 0 2.5-4zM14 3.2v2.1a7 7 0 0 1 0 13.4v2.1a9 9 0 0 0 0-17.6z" /></svg>
          <T km="ស្តាប់" en="Listen" />
        </button>

        <button v-if="supported" type="button" class="speak-step" :class="recording ? '!border-red-600 !bg-red-600 !text-white' : ''" :aria-pressed="!!recording" @click="toggleRecord">
          <span class="speak-num">2</span>
          <svg viewBox="0 0 24 24" class="size-6" fill="currentColor" aria-hidden="true">
            <rect v-if="recording" x="6" y="6" width="12" height="12" rx="2" />
            <path v-else d="M12 15a3 3 0 0 0 3-3V6a3 3 0 0 0-6 0v6a3 3 0 0 0 3 3zm5-3a5 5 0 0 1-10 0H5a7 7 0 0 0 6 6.9V21h2v-2.1A7 7 0 0 0 19 12z" />
          </svg>
          <T v-if="recording" km="ឈប់" en="Stop" />
          <T v-else-if="take" km="ថតម្តងទៀត" en="Record again" />
          <T v-else km="ថតសំឡេងខ្ញុំ" en="Record me" />
        </button>

        <button v-if="supported" type="button" class="speak-step" :class="comparing ? 'speak-step-on' : ''" :disabled="!take || !!recording" @click="compare">
          <span class="speak-num">3</span>
          <svg viewBox="0 0 24 24" class="size-6" fill="currentColor" aria-hidden="true"><path d="M3 10h4v4H3zm7-4h4v12h-4zm7 2h4v8h-4z" /></svg>
          <T km="ប្រៀបធៀប" en="Compare" />
        </button>
      </div>

      <div v-if="recording" class="mx-auto mt-4 max-w-xs" aria-live="polite">
        <div class="h-2 overflow-hidden rounded-full bg-slate-200 dark:bg-slate-700">
          <div class="h-full rounded-full bg-red-500 transition-[width] duration-75" :style="{ width: `${Math.round(level * 100)}%` }" />
        </div>
        <p class="mt-1 text-sm text-slate-500"><T km="កំពុងថត… និយាយឥឡូវនេះ" en="Recording… speak now" /> {{ elapsed.toFixed(1) }} / {{ MAX_SECONDS }} s</p>
      </div>

      <p v-if="take && !recording" class="mt-3 text-sm">
        <button type="button" class="text-brand-700 underline underline-offset-2 dark:text-brand-300" :aria-pressed="isPlayingMine" @click="playMine">
          <T km="ស្តាប់តែសំឡេងខ្ញុំ" en="Play only my voice" />
        </button>
      </p>

      <p v-if="!supported" class="mt-4 rounded-xl bg-amber-50 p-3 text-sm text-amber-900 dark:bg-amber-900/30 dark:text-amber-100">
        <T km="កម្មវិធីរុករកនេះមិនអាចថតសំឡេងបានទេ។ សាកល្បង Chrome, Edge ឬ Safari ថ្មី។ អ្នកនៅតែអាចស្តាប់ ហើយនិយាយតាមបាន។" en="This browser can't record. Try a recent Chrome, Edge or Safari. You can still listen and repeat aloud." stack />
      </p>
      <p v-else-if="micError" class="mt-4 rounded-xl bg-amber-50 p-3 text-sm text-amber-900 dark:bg-amber-900/30 dark:text-amber-100" role="alert">
        <T v-if="micError === 'denied'" km="មិនអាចប្រើមីក្រូហ្វូនបានទេ។ សូមអនុញ្ញាតមីក្រូហ្វូនសម្រាប់គេហទំព័រនេះ (រូបសោរ ឬរូបមីក្រូហ្វូន នៅជាប់អាសយដ្ឋាន) ហើយសាកម្តងទៀត។" en="The microphone isn't allowed. Allow it for this site (the lock or microphone icon next to the address) and try again." stack />
        <T v-else-if="micError === 'nomic'" km="រកមិនឃើញមីក្រូហ្វូនទេ។ សូមភ្ជាប់មួយ ហើយសាកម្តងទៀត។" en="No microphone found. Plug one in and try again." stack />
        <T v-else km="មិនអាចចាប់ផ្តើមថតបានទេ។ សាកម្តងទៀត។" en="Recording couldn't start. Please try again." stack />
      </p>
    </div>

    <VoicePicture v-if="item && (take || nativeVoice)" :native="nativeVoice" :mine="myVoice" />

    <div class="flex gap-1.5 overflow-x-auto pb-2" role="list" aria-label="Items in this set">
      <button
        v-for="(it, i) in set.items" :key="it.id" type="button" role="listitem" lang="km"
        class="font-khmer-serif relative shrink-0 rounded-lg border px-2.5 py-1 text-lg transition"
        :class="i === index ? 'border-brand-600 bg-brand-50 text-brand-800 dark:bg-brand-900/40 dark:text-brand-100' : 'border-slate-200 hover:border-brand-500 dark:border-slate-700'"
        :data-current-chip="i === index ? '' : undefined"
        :title="saved.has(it.id) ? 'Recorded' : undefined"
        @click="go(i)"
      >
        {{ [...it.text].length > 10 ? [...it.text].slice(0, 9).join('') + '…' : it.text }}
        <span v-if="saved.has(it.id)" class="absolute -top-1 -right-1 size-2.5 rounded-full bg-amber-500" aria-hidden="true" />
      </button>
    </div>

  </div>
</template>

<style scoped>
@reference '../styles/global.css';
.speak-step {
  @apply relative inline-flex min-w-28 flex-col items-center gap-1 rounded-2xl border-2 border-brand-600 bg-white px-4 py-3 font-medium text-brand-800 transition hover:bg-brand-50 disabled:cursor-not-allowed disabled:border-slate-300 disabled:text-slate-400 disabled:hover:bg-white dark:bg-slate-900 dark:text-brand-100 dark:hover:bg-brand-900/40 dark:disabled:border-slate-700 dark:disabled:text-slate-600 dark:disabled:hover:bg-slate-900;
}
.speak-step-on { @apply bg-brand-700 text-white hover:bg-brand-700 dark:bg-brand-700; }
.speak-num {
  @apply absolute top-1.5 left-2 text-xs opacity-60;
}
</style>
