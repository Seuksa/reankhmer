<script setup lang="ts">
/**
 * Re-downloads every sound, picture and animation this device has saved for offline use,
 * so files that were replaced on the site (same name, new recording) are picked up.
 * Each file is swapped one at a time and put back if the download fails, so going offline
 * half-way never loses anything.
 */
import { ref } from 'vue';
import T from './T.vue';

type State = 'idle' | 'working' | 'done' | 'offline' | 'unsupported';
const state = ref<State>('idle');
const done = ref(0);
const total = ref(0);
const failed = ref(0);

async function refresh() {
  if (!('caches' in window)) { state.value = 'unsupported'; return; }
  if (!navigator.onLine) { state.value = 'offline'; return; }
  state.value = 'working';
  done.value = 0;
  failed.value = 0;

  // App code and pages: ask the service worker to check for a newer version too.
  void navigator.serviceWorker?.getRegistration().then((r) => r?.update()).catch(() => {});

  const names = (await caches.keys()).filter((n) => n.startsWith('rk-'));
  const jobs: { cache: Cache; req: Request }[] = [];
  for (const name of names) {
    const cache = await caches.open(name);
    for (const req of await cache.keys()) jobs.push({ cache, req });
  }
  total.value = jobs.length;

  const worker = async () => {
    for (let job = jobs.shift(); job; job = jobs.shift()) {
      const { cache, req } = job;
      const old = await cache.match(req);
      await cache.delete(req);
      try {
        // With the entry gone, the service worker fetches from the network and saves the new copy;
        // 'reload' skips the browser's own HTTP cache.
        const r = await fetch(req.url, { cache: 'reload' });
        if (!r.ok) throw new Error(String(r.status));
        await r.arrayBuffer();
      } catch {
        failed.value++;
        if (old) await cache.put(req, old);
      }
      done.value++;
    }
  };
  await Promise.all(Array.from({ length: 4 }, worker));

  // Caches left empty (old names from earlier versions) can go.
  for (const name of names) {
    const cache = await caches.open(name);
    if ((await cache.keys()).length === 0) await caches.delete(name);
  }
  state.value = 'done';
}
</script>

<template>
  <section class="card flex flex-wrap items-center gap-4">
    <div class="min-w-60 flex-1">
      <h2 class="font-semibold"><T km="ធ្វើបច្ចុប្បន្នភាពសំឡេង និងរូបភាព" en="Refresh sounds and pictures" stack /></h2>
      <p class="mt-1 text-sm text-slate-500">
        <T v-if="state === 'working'" :km="`កំពុងទាញយកឡើងវិញ ${done}/${total}…`" :en="`Downloading again ${done}/${total}…`" />
        <T v-else-if="state === 'done' && total === 0" km="មិនទាន់មានឯកសាររក្សាទុកនៅលើឧបករណ៍នេះទេ។" en="Nothing saved on this device yet." />
        <T v-else-if="state === 'done' && failed" :km="`បានធ្វើរួច ${total - failed}/${total}។ ឯកសារ ${failed} មិនទាន់បាន — សាកម្តងទៀតពេលអ៊ីនធឺណិតល្អ។`" :en="`Updated ${total - failed} of ${total}. ${failed} kept the old copy; try again on a better connection.`" />
        <T v-else-if="state === 'done'" :km="`រួចរាល់! បានទាញយកឡើងវិញ ${total} ឯកសារ។`" :en="`Done! ${total} files downloaded again.`" />
        <T v-else-if="state === 'offline'" km="សូមភ្ជាប់អ៊ីនធឺណិតជាមុនសិន។" en="Connect to the internet first." />
        <T v-else-if="state === 'unsupported'" km="កម្មវិធីរុករកនេះមិនរក្សាទុកឯកសារទេ — គ្មានអ្វីត្រូវធ្វើ។" en="This browser doesn't save files offline, so there is nothing to refresh." />
        <T v-else km="បើសំឡេងហាក់ដូចជាចាស់ ឬខុស ចុចដើម្បីទាញយកឯកសារដែលបានរក្សាទុកឡើងវិញ។" en="If a sound seems old or wrong, download the saved files again." />
      </p>
      <div v-if="state === 'working' && total" class="mt-2 h-2 rounded-full bg-slate-100 dark:bg-slate-800">
        <div class="h-2 rounded-full bg-brand-600 transition-all" :style="{ width: `${(done / total) * 100}%` }" />
      </div>
    </div>
    <button class="btn" :disabled="state === 'working'" @click="refresh">
      <T km="ធ្វើឲ្យស្រស់" en="Refresh" />
    </button>
  </section>
</template>
