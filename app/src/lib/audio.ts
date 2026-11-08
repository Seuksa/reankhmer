// One shared player. Clips are fetched whole (not streamed with Range requests) so the service
// worker stores a complete copy and the clip plays offline next time.
import { ref } from 'vue';

export const playing = ref<string | null>(null);
let current: HTMLAudioElement | null = null;
const blobs = new Map<string, string>();

async function load(url: string): Promise<string> {
  const cached = blobs.get(url);
  if (cached) return cached;
  const res = await fetch(url);
  if (!res.ok) throw new Error(`audio ${res.status}: ${url}`);
  const obj = URL.createObjectURL(await res.blob());
  blobs.set(url, obj);
  return obj;
}

export function stop() {
  current?.pause();
  current = null;
  playing.value = null;
}

/** Plays a clip and resolves when it ends (or is interrupted). */
export async function play(url: string): Promise<void> {
  stop();
  playing.value = url;
  try {
    const el = new Audio(await load(url));
    current = el;
    await el.play();
    await new Promise<void>((done) => {
      el.addEventListener('ended', () => done(), { once: true });
      el.addEventListener('pause', () => done(), { once: true });
    });
  } catch (err) {
    console.warn('[reankhmer] audio', err);
  } finally {
    if (playing.value === url) playing.value = null;
  }
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
