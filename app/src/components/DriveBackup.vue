<script setup lang="ts">
import { onMounted, ref } from 'vue';
import { backupToDrive, driveEnabled, restoreFromDrive } from '../lib/drive';
import T from './T.vue';

const busy = ref(false);
const online = ref(true);
const msg = ref<{ km: string; en: string; ok: boolean } | null>(null);
const lastSaved = ref<string | null>(null);

onMounted(() => {
  online.value = navigator.onLine;
  addEventListener('online', () => (online.value = true));
  addEventListener('offline', () => (online.value = false));
  try { lastSaved.value = localStorage.getItem('rk-drive-saved'); } catch {}
});

const when = (iso: string) => new Date(iso).toLocaleString();

async function run(kind: 'backup' | 'restore') {
  busy.value = true;
  msg.value = null;
  try {
    if (kind === 'backup') {
      lastSaved.value = await backupToDrive();
      try { localStorage.setItem('rk-drive-saved', lastSaved.value); } catch {}
      msg.value = { km: 'បានរក្សាទុកក្នុង Google Drive', en: 'Saved to Google Drive.', ok: true };
    } else {
      const r = await restoreFromDrive();
      msg.value = r === 'restored' ? { km: 'បានយកវឌ្ឍនភាពពី Google Drive', en: 'Progress restored from Google Drive.', ok: true }
        : r === 'none' ? { km: 'មិនទាន់មានការបម្រុងទុកនៅ Google Drive ទេ', en: 'No backup in Google Drive yet.', ok: false }
        : { km: 'ឯកសារបម្រុងខូច', en: 'The Drive backup could not be read.', ok: false };
    }
  } catch (e) {
    msg.value = { km: 'មិនបានសម្រេច សូមសាកម្តងទៀត', en: `Did not work: ${(e as Error).message}`, ok: false };
  } finally {
    busy.value = false;
  }
}
</script>

<template>
  <div class="border-t border-slate-200 pt-3 dark:border-slate-800">
    <p v-if="!driveEnabled" class="text-xs text-slate-500"><T km="ការបម្រុងទុកទៅ Google Drive នឹងមកដល់ឆាប់ៗ។" en="Google Drive backup is coming soon." /></p>
    <template v-else>
      <div class="flex flex-wrap items-center gap-2">
        <button type="button" class="btn" :disabled="busy || !online" @click="run('backup')">
          <svg viewBox="0 0 24 24" class="size-5" fill="currentColor" aria-hidden="true"><path d="M8 3h8l6 10-4 7H6l-4-7zm1.2 2L4.4 13h6.5l4.8-8z" /></svg>
          <T km="បម្រុងទុកទៅ Google Drive" en="Back up to Google Drive" />
        </button>
        <button type="button" class="btn-quiet" :disabled="busy || !online" @click="run('restore')"><T km="យកពី Google Drive" en="Restore from Drive" /></button>
      </div>
      <p class="mt-2 text-xs text-slate-500">
        <T km="ឯកសារត្រូវបានរក្សាទុកក្នុងថតលាក់របស់ រៀនខ្មែរ ក្នុង Drive របស់អ្នក។ យើងមើលមិនឃើញឯកសារផ្សេងទៀតរបស់អ្នកទេ។"
           en="Saved in a hidden ReanKhmer folder in your own Drive. The app cannot see any of your other files." stack />
      </p>
      <p v-if="!online" class="mt-1 text-xs text-amber-700 dark:text-amber-300"><T km="ត្រូវការអ៊ីនធឺណិត" en="Needs an internet connection" /></p>
      <p v-if="lastSaved" class="mt-1 text-xs text-slate-500"><T km="បម្រុងទុកចុងក្រោយ" en="Last backup" />: {{ when(lastSaved) }}</p>
      <p v-if="msg" class="mt-2 text-sm" :class="msg.ok ? 'text-emerald-700 dark:text-emerald-300' : 'text-rose-700 dark:text-rose-300'" aria-live="polite"><T :km="msg.km" :en="msg.en" /></p>
    </template>
  </div>
</template>
