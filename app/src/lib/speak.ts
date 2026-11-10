// Speaking practice: record the learner, keep the last few takes on this device only (IndexedDB,
// never uploaded), and describe a voice as a loudness outline + pitch line for the picture.
import { createStore, del, entries, get, set, clear } from 'idb-keyval';

export interface SpeakItem { id: string; text: string; roman?: string; en?: string; audio: string }
export interface SpeakSet { id: string; group: 'letters' | 'vowels' | 'words' | 'sentences'; km: string; en: string; items: SpeakItem[] }

/** How many takes are kept on the device (oldest are removed first). */
export const KEEP = 20;
export const MAX_SECONDS = 12;

// ---------- recording ----------
export type MicError = 'unsupported' | 'denied' | 'nomic' | 'other';

export function micSupported() {
  return typeof window !== 'undefined' && !!navigator.mediaDevices?.getUserMedia && typeof MediaRecorder !== 'undefined';
}

const MIME = ['audio/webm;codecs=opus', 'audio/mp4', 'audio/webm', 'audio/ogg;codecs=opus'];

export interface Recording { stop: () => void; done: Promise<Blob>; level: () => number }

/** Starts recording; the microphone is released as soon as the take ends. */
export async function startRecording(): Promise<Recording> {
  let stream: MediaStream;
  try {
    stream = await navigator.mediaDevices.getUserMedia({ audio: { echoCancellation: true, noiseSuppression: true, autoGainControl: true } });
  } catch (e) {
    const name = (e as DOMException)?.name;
    throw Object.assign(new Error('mic'), { code: (name === 'NotAllowedError' || name === 'SecurityError' ? 'denied' : name === 'NotFoundError' ? 'nomic' : 'other') as MicError });
  }
  const mimeType = MIME.find((m) => MediaRecorder.isTypeSupported?.(m));
  const rec = new MediaRecorder(stream, mimeType ? { mimeType } : undefined);
  const chunks: Blob[] = [];
  rec.ondataavailable = (e) => { if (e.data.size) chunks.push(e.data); };

  // live level for the meter
  const ctx = new AudioContext();
  const an = ctx.createAnalyser();
  an.fftSize = 1024;
  ctx.createMediaStreamSource(stream).connect(an);
  const buf = new Float32Array(an.fftSize);
  const level = () => {
    an.getFloatTimeDomainData(buf);
    let s = 0; for (const v of buf) s += v * v;
    return Math.min(1, Math.sqrt(s / buf.length) * 5);
  };

  const done = new Promise<Blob>((ok) => {
    rec.onstop = () => {
      stream.getTracks().forEach((t) => t.stop());
      void ctx.close();
      ok(new Blob(chunks, { type: rec.mimeType || mimeType || 'audio/webm' }));
    };
  });
  const timer = setTimeout(() => rec.state === 'recording' && rec.stop(), MAX_SECONDS * 1000);
  rec.start();
  return { stop: () => { clearTimeout(timer); if (rec.state === 'recording') rec.stop(); }, done, level };
}

// ---------- the last few takes, on this device only ----------
interface Take { blob: Blob; at: number }
let store: ReturnType<typeof createStore> | null = null;
const takes = () => (store ??= createStore('reankhmer-speak', 'takes'));

export async function saveTake(id: string, blob: Blob) {
  await set(id, { blob, at: Date.now() } satisfies Take, takes());
  const all = (await entries<string, Take>(takes())).sort((a, b) => b[1].at - a[1].at);
  for (const [k] of all.slice(KEEP)) await del(k, takes());
}
export async function loadTake(id: string): Promise<Blob | null> {
  try { return ((await get<Take>(id, takes())) ?? null)?.blob ?? null; } catch { return null; }
}
export async function takeIds(): Promise<string[]> {
  try { return (await entries<string, Take>(takes())).map(([k]) => k); } catch { return []; }
}
export const deleteAllTakes = () => clear(takes());

// ---------- the picture: loudness outline + pitch line ----------
export interface Voice { dur: number; env: number[]; pitch: (number | null)[]; step: number }

const STEP = 0.01; // 10 ms per point

/** Decodes a clip and returns its outline, trimmed to the voiced part (with a small margin). */
export async function describe(data: Blob | ArrayBuffer): Promise<Voice | null> {
  try {
    const bytes = data instanceof Blob ? await data.arrayBuffer() : data;
    const ctx = new OfflineAudioContext(1, 1, 16000);
    const audio = await ctx.decodeAudioData(bytes.slice(0));
    const sr = audio.sampleRate;
    const ch = audio.getChannelData(0);
    const hop = Math.round(sr * STEP);
    const win = Math.round(sr * 0.04);
    const env: number[] = [];
    for (let i = 0; i + hop <= ch.length; i += hop) {
      let s = 0; for (let j = i; j < i + hop; j++) s += ch[j] * ch[j];
      env.push(Math.sqrt(s / hop));
    }
    const top = Math.max(...env, 1e-6);
    const sorted = [...env].sort((a, b) => a - b);
    // noise floor ×3, but never above half the peak: a take with no silence around it is still all voice
    const thr = Math.min(top * 0.5, Math.max(top * 0.08, (sorted[Math.floor(sorted.length * 0.1)] ?? 0) * 3));
    let first = env.findIndex((v) => v > thr);
    let last = env.length - 1 - [...env].reverse().findIndex((v) => v > thr);
    if (first < 0) return null;
    first = Math.max(0, first - 5); last = Math.min(env.length - 1, last + 8);

    const out: number[] = [], pitch: (number | null)[] = [];
    const minLag = Math.floor(sr / 450), maxLag = Math.ceil(sr / 70);
    for (let f = first; f <= last; f++) {
      out.push(env[f] / top);
      pitch.push(env[f] > thr ? pitchAt(ch, f * hop, win, minLag, maxLag, sr) : null);
    }
    return { dur: out.length * STEP, env: out, pitch: smooth(pitch), step: STEP };
  } catch (e) {
    console.warn('[reankhmer] describe', e);
    return null;
  }
}

/** Autocorrelation pitch (Hz) of one window, or null when it isn't clearly voiced. */
function pitchAt(ch: Float32Array, start: number, win: number, minLag: number, maxLag: number, sr: number): number | null {
  if (start + win + maxLag > ch.length) return null;
  let e0 = 0; for (let i = 0; i < win; i++) e0 += ch[start + i] * ch[start + i];
  if (e0 <= 0) return null;
  const r: number[] = [];
  let best = 0;
  for (let lag = minLag; lag <= maxLag; lag++) {
    let c = 0, e1 = 0;
    for (let i = 0; i < win; i++) { const b = ch[start + i + lag]; c += ch[start + i] * b; e1 += b * b; }
    r.push(c / Math.sqrt(e0 * e1 || 1));
    best = Math.max(best, r[r.length - 1]);
  }
  if (best < 0.6) return null;
  // the shortest lag that is almost as good as the best: avoids reading half the pitch (an octave low)
  for (let k = 1; k < r.length - 1; k++) {
    if (r[k] >= best * 0.88 && r[k] >= r[k - 1] && r[k] >= r[k + 1]) return sr / (k + minLag);
  }
  return null;
}

/** Median of 5 to remove octave jumps; drops single isolated points. */
function smooth(p: (number | null)[]): (number | null)[] {
  return p.map((v, i) => {
    if (v == null) return null;
    const near = p.slice(Math.max(0, i - 2), i + 3).filter((x): x is number => x != null).sort((a, b) => a - b);
    return near.length < 3 ? null : near[Math.floor(near.length / 2)];
  });
}

/** Pitch as semitones around the speaker's own middle, so a child and an adult can be compared. */
export function semitones(v: Voice): (number | null)[] {
  const vals = v.pitch.filter((x): x is number => x != null).sort((a, b) => a - b);
  if (!vals.length) return v.pitch.map(() => null);
  const mid = vals[Math.floor(vals.length / 2)];
  return v.pitch.map((x) => {
    if (x == null) return null;
    let st = 12 * Math.log2(x / mid);
    while (st > 8) st -= 12;   // fold leftover octave slips back next to the rest of the line
    while (st < -8) st += 12;
    return st;
  });
}
