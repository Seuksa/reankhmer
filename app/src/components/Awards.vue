<script setup lang="ts">
/**
 * Badges and certificates (step D): every badge, earned in colour, the rest greyed with how to earn
 * it. A finished chapter opens its certificate: share as a picture, save, or print.
 */
import { computed, onBeforeUnmount, onMounted, ref } from 'vue';
import { badges, type Badge } from '../lib/awards';
import { drawCertificate } from '../lib/certificate';
import { loadSteps, type PlanStep } from '../lib/plan';
import { loadProgress, markSeen, progress } from '../lib/progress';
import { activeProfile, type Profile } from '../lib/profiles';
import { fileSafe, saveFile, sharePicture } from '../lib/share';
import T from './T.vue';

const steps = ref<PlanStep[]>([]);
const me = ref<Profile | null>(null);
const ready = ref(false);
onMounted(async () => {
  me.value = activeProfile();
  [steps.value] = await Promise.all([loadSteps(), loadProgress()]);
  ready.value = true;
  markSeen(all.value.filter((b) => b.earned).map((b) => b.id)); // seen here: no "new badge" banner any more
  const want = new URLSearchParams(location.search).get('certificate');
  const b = all.value.find((x) => x.id === want && x.earned);
  if (b) void open(b);
});
const all = computed<Badge[]>(() => (steps.value.length ? badges(steps.value) : []));
const earnedCount = computed(() => all.value.filter((b) => b.earned).length);

// ---- certificate ----
const cert = ref<{ badge: Badge; url: string; blob: Blob } | null>(null);
const busy = ref(false);
const note = ref<{ km: string; en: string } | null>(null);
async function open(b: Badge) {
  if (!b.chapter || !b.earned || !me.value) return;
  busy.value = true; note.value = null;
  try {
    const blob = await drawCertificate(me.value.name, b);
    if (cert.value) URL.revokeObjectURL(cert.value.url);
    cert.value = { badge: b, blob, url: URL.createObjectURL(blob) };
    requestAnimationFrame(() => document.getElementById('certificate')?.scrollIntoView({ behavior: 'smooth', block: 'start' }));
  } finally { busy.value = false; }
}
const certName = () => `reankhmer-certificate-${fileSafe(me.value?.name ?? '')}-chapter-${cert.value?.badge.chapter}.png`;
async function share() {
  if (!cert.value) return;
  const r = await sharePicture(cert.value.blob, certName(), 'ReanKhmer');
  if (r === 'saved') note.value = { km: 'បានរក្សាទុករូបភាព។', en: 'Picture saved.' };
}
function save() { if (cert.value) saveFile(new File([cert.value.blob], certName(), { type: 'image/png' })); }
function printCert() {
  document.documentElement.dataset.print = 'certificate';
  print();
}
const afterPrint = () => { delete document.documentElement.dataset.print; };
onMounted(() => addEventListener('afterprint', afterPrint));
onBeforeUnmount(() => { removeEventListener('afterprint', afterPrint); if (cert.value) URL.revokeObjectURL(cert.value.url); });

const date = (t: number) => new Date(t).toLocaleDateString('en-GB', { day: 'numeric', month: 'short', year: 'numeric' });
</script>

<template>
  <section v-if="ready && me && progress.plan" id="badges" class="card mt-6 print:hidden">
    <h2 class="mb-1 text-xl font-semibold"><T km="មេដាយ" en="Badges" /> <span class="text-base font-normal text-slate-500">{{ earnedCount }}/{{ all.length }}</span></h2>
    <p class="mb-4 text-sm text-slate-500"><T km="រៀនចប់ជំពូកមួយ ទទួលបានវិញ្ញាបនបត្រ។" en="Finish a chapter to get its certificate." /></p>
    <ul class="grid grid-cols-2 gap-3 sm:grid-cols-4">
      <li v-for="b in all" :key="b.id">
        <component :is="b.earned && b.chapter ? 'button' : 'div'" type="button"
          class="flex h-full w-full flex-col items-center gap-1 rounded-2xl border p-3 text-center"
          :class="b.earned ? 'border-amber-300 bg-amber-50 dark:border-amber-800 dark:bg-amber-950/30' + (b.chapter ? ' hover:border-amber-500' : '') : 'border-slate-200 opacity-60 dark:border-slate-800'"
          @click="b.earned && b.chapter && open(b)">
          <span class="font-khmer-serif grid size-14 place-items-center rounded-full text-2xl"
            :class="b.earned ? 'bg-brand-700 text-white' : 'bg-slate-200 text-slate-500 grayscale dark:bg-slate-800'" aria-hidden="true">{{ b.icon }}</span>
          <span class="text-sm font-medium"><T :km="b.title.km" :en="b.title.en" stack /></span>
          <span v-if="b.earned" class="text-xs text-slate-500">{{ date(b.earned) }}</span>
          <span v-else class="text-xs text-slate-500"><T :km="b.how.km" :en="b.how.en" /></span>
          <span v-if="b.earned && b.chapter" class="text-xs font-medium text-brand-700 underline dark:text-brand-200"><T km="វិញ្ញាបនបត្រ" en="Certificate" /></span>
        </component>
      </li>
    </ul>
  </section>

  <section v-if="cert" id="certificate" class="card mt-6">
    <h2 class="mb-3 text-lg font-semibold print:hidden"><T km="វិញ្ញាបនបត្រ" en="Certificate" /></h2>
    <img :src="cert.url" alt="Certificate" class="cert-print w-full rounded-lg border border-slate-200 dark:border-slate-700" />
    <div class="mt-4 flex flex-wrap gap-3 print:hidden">
      <button type="button" class="btn" @click="share"><T km="ផ្ញើជារូបភាព" en="Share as a picture" /></button>
      <button type="button" class="btn-quiet" @click="save"><T km="រក្សាទុករូបភាព" en="Save picture" /></button>
      <button type="button" class="btn-quiet" @click="printCert"><T km="បោះពុម្ព" en="Print" /></button>
    </div>
    <p v-if="note" class="mt-2 text-sm text-slate-600 dark:text-slate-400"><T :km="note.km" :en="note.en" /></p>
  </section>
  <p v-if="busy" class="mt-3 text-sm text-slate-500" aria-live="polite"><T km="កំពុងរៀបចំ…" en="Preparing…" /></p>
</template>

<style>
/* Printing a certificate: only the certificate, landscape, full page. */
@media print {
  html[data-print='certificate'] body * { visibility: hidden; }
  html[data-print='certificate'] .cert-print { visibility: visible; position: fixed; inset: 0; width: 100%; height: auto; border: 0; border-radius: 0; }
  @page { margin: 8mm; }
}
</style>
