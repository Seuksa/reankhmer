// Google Drive backup, entirely in the browser (works on static hosting).
// Uses the hidden "appDataFolder": only ReanKhmer can read or write this file; it does not
// see or touch anything else in the learner's Drive. Needs PUBLIC_GOOGLE_CLIENT_ID at build time.
import { exportProgress, importProgress } from './progress';

const CLIENT_ID = import.meta.env.PUBLIC_GOOGLE_CLIENT_ID as string | undefined;
export const driveEnabled = !!CLIENT_ID;

const SCOPE = 'https://www.googleapis.com/auth/drive.appdata';
const FILE = 'reankhmer-progress.json';
const API = 'https://www.googleapis.com/drive/v3';
const UPLOAD = 'https://www.googleapis.com/upload/drive/v3';

interface TokenResponse { access_token?: string; expires_in?: number; error?: string }
type Google = { accounts: { oauth2: { initTokenClient: (o: unknown) => { requestAccessToken: (o?: unknown) => void } } } };

let token: { value: string; exp: number } | null = null;

function loadGis(): Promise<void> {
  if ((window as unknown as { google?: Google }).google?.accounts) return Promise.resolve();
  return new Promise((ok, fail) => {
    const s = document.createElement('script');
    s.src = 'https://accounts.google.com/gsi/client';
    s.async = true;
    s.onload = () => ok();
    s.onerror = () => fail(new Error('Could not load Google sign-in'));
    document.head.appendChild(s);
  });
}

async function getToken(): Promise<string> {
  if (token && token.exp > Date.now()) return token.value;
  if (!CLIENT_ID) throw new Error('Drive backup is not configured');
  await loadGis();
  const google = (window as unknown as { google: Google }).google;
  return new Promise((ok, fail) => {
    const client = google.accounts.oauth2.initTokenClient({
      client_id: CLIENT_ID,
      scope: SCOPE,
      callback: (r: TokenResponse) => {
        if (!r.access_token) return fail(new Error(r.error ?? 'Sign-in cancelled'));
        token = { value: r.access_token, exp: Date.now() + ((r.expires_in ?? 3600) - 60) * 1000 };
        ok(r.access_token);
      },
      error_callback: (e: { message?: string }) => fail(new Error(e?.message ?? 'Sign-in cancelled')),
    });
    client.requestAccessToken({ prompt: '' });
  });
}

async function call(url: string, init: RequestInit = {}) {
  const t = await getToken();
  const res = await fetch(url, { ...init, headers: { ...(init.headers ?? {}), Authorization: `Bearer ${t}` } });
  if (res.status === 401) token = null;
  if (!res.ok) throw new Error(`Google Drive error ${res.status}`);
  return res;
}

async function findFile(): Promise<{ id: string; modifiedTime: string } | null> {
  const q = encodeURIComponent(`name='${FILE}'`);
  const res = await call(`${API}/files?spaces=appDataFolder&q=${q}&fields=files(id,modifiedTime)&orderBy=modifiedTime desc`);
  const { files } = (await res.json()) as { files: { id: string; modifiedTime: string }[] };
  return files[0] ?? null;
}

/** Saves this device's progress to Drive (replaces the previous backup). Returns the save time. */
export async function backupToDrive(): Promise<string> {
  const body = await exportProgress();
  const existing = await findFile();
  if (existing) {
    const res = await call(`${UPLOAD}/files/${existing.id}?uploadType=media&fields=modifiedTime`, {
      method: 'PATCH', headers: { 'Content-Type': 'application/json' }, body,
    });
    return ((await res.json()) as { modifiedTime: string }).modifiedTime;
  }
  const boundary = `rk${Date.now()}`;
  const meta = JSON.stringify({ name: FILE, parents: ['appDataFolder'], mimeType: 'application/json' });
  const multipart = new Blob([
    `--${boundary}\r\nContent-Type: application/json; charset=UTF-8\r\n\r\n${meta}\r\n`,
    `--${boundary}\r\nContent-Type: application/json\r\n\r\n`, body, `\r\n--${boundary}--`,
  ]);
  const res = await call(`${UPLOAD}/files?uploadType=multipart&fields=modifiedTime`, {
    method: 'POST', headers: { 'Content-Type': `multipart/related; boundary=${boundary}` }, body: multipart,
  });
  return ((await res.json()) as { modifiedTime: string }).modifiedTime;
}

/** Merges the Drive backup into this device (same rules as restoring from a file). */
export async function restoreFromDrive(): Promise<'restored' | 'none' | 'invalid'> {
  const file = await findFile();
  if (!file) return 'none';
  const res = await call(`${API}/files/${file.id}?alt=media`);
  return (await importProgress(await res.text())) ? 'restored' : 'invalid';
}
