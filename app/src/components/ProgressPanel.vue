<script setup lang="ts">
import { computed, onMounted, ref } from 'vue';
import { prefetch } from '../lib/audio';
import { exportProgress, heardCount, importProgress, loadProgress, progress, resetProgress } from '../lib/progress';
import T from './T.vue';

interface Pack { id: string; km: string; en: string; urls: string[] }
const props = defineProps<{ totals: { letters: number; vowels: number; lessons: number; typing: number }; packs: Pack[] }>();

const persisted = ref<boolean | null>(null);
const message = ref<{ km: string; en: string } | null>(null);
const downloading = ref<Record<string, string>>({});
const fileInput = ref<HTMLInputElement | null>(null);

onMounted(async () => {
  await loadProgress();
  persisted.value = (await navigator.storage?.persisted?.()) ?? null;
});

const stats = computed(() => [
  { km: 'ព្យញ្ជនៈបានស្តាប់', en: 'Letters heard', value: heardCount('c:'), total: props.totals.letters },
  { km: 'ស្រៈបានស្តាប់', en: 'Vowel sounds heard', value: heardCount('v:'), total: props.totals.vowels },
  { km: 'មេរៀនចប់', en: 'Lessons finished', value: Object.values(progress.lessons).filter((l) => l.done).length, total: props.totals.lessons },
  { km: 'មេរៀនវាយអក្សរ', en: 'Typing lessons', value: Object.keys(progress.typing ?? {}).filter((k) => k !== 'game').length, total: props.totals.typing },
]);

async function keepData() {
  persisted.value = (await navigator.storage?.persist?.()) ?? false;
}

function download() {
  const a = document.createElement('a');
  a.href = URL.createObjectURL(exportProgress());
  a.download = `reankhmer-progress-${new Date().toISOString().slice(0, 10)}.json`;
  a.click();
  URL.revokeObjectURL(a.href);
}

async function upload(e: Event) {
  const file = (e.target as HTMLInputElement).files?.[0];
  if (!file) return;
  const ok = await importProgress(await file.text());
  message.value = ok
    ? { km: 'បានបញ្ចូលវឌ្ឍនភាពរួចរាល់', en: 'Progress imported and merged.' }
    : { km: 'ឯកសារនេះមិនត្រឹមត្រូវទេ', en: 'That file is not a ReanKhmer backup.' };
  (e.target as HTMLInputElement).value = '';
}

async function reset() {
  if (!confirm('Delete all progress on this device? / លុបវឌ្ឍនភាពទាំងអស់?')) return;
  await resetProgress();
}

async function offline(p: Pack) {
  downloading.value[p.id] = '0%';
  const { failed } = await prefetch(p.urls, (d, t) => (downloading.value[p.id] = `${Math.round((d / t) * 100)}%`));
  downloading.value[p.id] = failed ? `⚠ ${failed}` : '✓';
  if (persisted.value === false || persisted.value === null) void keepData();
}
</script>

<template>
  <div class="space-y-8">
    <section>
      <ul class="grid gap-3 sm:grid-cols-2 lg:grid-cols-4">
        <li v-for="s in stats" :key="s.en" class="card">
          <p class="text-sm text-slate-500"><T :km="s.km" :en="s.en" stack /></p>
          <p class="mt-1 text-3xl font-semibold">{{ s.value }}<span class="text-lg text-slate-400"> / {{ s.total }}</span></p>
          <div class="mt-2 h-2 rounded-full bg-slate-100 dark:bg-slate-800">
            <div class="h-2 rounded-full bg-brand-600" :style="{ width: `${Math.min(100, (s.value / s.total) * 100)}%` }" />
          </div>
        </li>
      </ul>
    </section>

    <section class="card space-y-3">
      <h2 class="text-lg font-semibold"><T km="រក្សាទុក និងផ្ទេរ" en="Backup & move to another device" /></h2>
      <p class="text-sm text-slate-600 dark:text-slate-400">
        <T km="វឌ្ឍនភាពរក្សាទុកតែនៅលើឧបករណ៍នេះ។ ទាញយកឯកសារបម្រុងទុក ហើយបើកវានៅលើទូរស័ព្ទ ឬកុំព្យូទ័រផ្សេង។"
           en="Progress is saved only on this device. Download a backup file and open it on another phone or computer." stack />
      </p>
      <div class="flex flex-wrap gap-2">
        <button class="btn" @click="download"><T km="ទាញយកឯកសារបម្រុង" en="Download backup" /></button>
        <button class="btn-quiet" @click="fileInput?.click()"><T km="បើកឯកសារបម្រុង" en="Restore from file" /></button>
        <input ref="fileInput" type="file" accept="application/json,.json" class="hidden" @change="upload" />
        <button class="btn-quiet text-rose-700 dark:text-rose-300" @click="reset"><T km="លុបទាំងអស់" en="Reset" /></button>
      </div>
      <p v-if="message" class="text-sm" aria-live="polite"><T :km="message.km" :en="message.en" /></p>
      <p class="text-xs text-slate-500"><T km="ការបម្រុងទុកទៅ Google Drive នឹងមកដល់ឆាប់ៗ។" en="Google Drive backup is coming soon." /></p>
    </section>

    <section class="card space-y-3">
      <h2 class="text-lg font-semibold"><T km="ប្រើពេលគ្មានអ៊ីនធឺណិត" en="Use without internet" /></h2>
      <p class="text-sm text-slate-600 dark:text-slate-400">
        <T km="ទំព័រទាំងអស់ដំណើរការពេលគ្មានអ៊ីនធឺណិត។ ទាញយកសំឡេងជាមុន ដើម្បីស្តាប់ពេលធ្វើដំណើរ។"
           en="Every page works offline. Download the audio first to listen on the go." stack />
      </p>
      <p v-if="persisted === false" class="text-sm">
        <button class="underline" @click="keepData"><T km="សុំរក្សាទុកទិន្នន័យជាអចិន្ត្រៃយ៍" en="Ask the browser to keep this data" /></button>
      </p>
      <ul class="divide-y divide-slate-200 dark:divide-slate-800">
        <li v-for="p in packs" :key="p.id" class="flex items-center gap-3 py-2">
          <span class="flex-1"><T :km="p.km" :en="p.en" stack /></span>
          <span class="text-xs text-slate-500">{{ p.urls.length }} files</span>
          <button class="btn-quiet !px-3 !py-1 text-sm" :disabled="!!downloading[p.id] && downloading[p.id] !== '✓' && !downloading[p.id].startsWith('⚠')" @click="offline(p)">
            <span v-if="downloading[p.id]">{{ downloading[p.id] }}</span>
            <T v-else km="ទាញយក" en="Download" />
          </button>
        </li>
      </ul>
    </section>
  </div>
</template>
