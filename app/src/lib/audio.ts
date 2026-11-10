// One shared player. iPhones (every iOS browser is Safari inside) only start sound from a tap, so
// play() must call el.play() straight away, with no await before it, on one element that is reused:
// once a tap has started it, Safari lets later clips (Play all, Compare) start on it too.
// The first time, the clip streams from its URL (the service worker answers Range requests); in the
// background it is also fetched whole, so the service worker stores a complete copy for offline use
// and later plays come from memory.
import { ref } from 'vue';

export const playing = ref<string | null>(null);
const blobs = new Map<string, string>();
let el: HTMLAudioElement | null = null;
let finish: (() => void) | null = null;

function keep(url: string) {
  if (blobs.has(url) || url.startsWith('blob:')) return;
  blobs.set(url, url); // placeholder: don't fetch twice
  fetch(url)
    .then((r) => (r.ok ? r.blob() : Promise.reject(new Error(String(r.status)))))
    .then((b) => blobs.set(url, URL.createObjectURL(b)))
    .catch(() => blobs.delete(url));
}

export function stop() {
  el?.pause();
  const f = finish;
  finish = null;
  f?.();
  playing.value = null;
}

/** Plays a clip and resolves when it ends (or is interrupted). */
export function play(url: string): Promise<void> {
  stop();
  playing.value = url;
  el ??= new Audio();
  const a = el;
  a.src = blobs.get(url) ?? url;
  return new Promise<void>((resolve) => {
    const onPause = () => { if (a.paused && !a.ended) done(); };
    const done = () => {
      if (finish !== done) return;
      finish = null;
      a.removeEventListener('ended', done);
      a.removeEventListener('error', done);
      a.removeEventListener('pause', onPause);
      if (playing.value === url) playing.value = null;
      resolve();
    };
    finish = done;
    a.addEventListener('ended', done);
    a.addEventListener('error', done);
    a.play()
      .then(() => { if (finish === done) a.addEventListener('pause', onPause); }) // paused from outside (e.g. a call)
      .catch((err) => { console.warn('[reankhmer] audio', err); done(); });
    keep(url);
  });
}

/** Fetches files so the service worker caches them; reports progress. */
export async function prefetch(urls: string[], onStep?: (done: number, total: number) => void) {
  let done = 0;
  let failed = 0;
  const queue = [...urls];
  const worker = async () => {
    for (let u = queue.shift(); u; u = queue.shift()) {
      try { const r = await fetch(u); if (!r.ok) failed++; } catch { failed++; }
      onStep?.(++done, urls.length);
    }
  };
  await Promise.all(Array.from({ length: 4 }, worker));
  return { done, failed };
}
