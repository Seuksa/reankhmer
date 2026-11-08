// @ts-check
import { defineConfig } from 'astro/config';
import vue from '@astrojs/vue';
import tailwindcss from '@tailwindcss/vite';
import { AstroPWAIntegration as AstroPWA } from '@vite-pwa/astro';

/**
 * Workbox serialises urlPattern into sw.js, so it must be a RegExp (a closure would lose `prefix`).
 * @param {RegExp} pattern
 * @param {string} cacheName
 * @param {number} maxEntries
 */
const media = (pattern, cacheName, maxEntries) => ({
  urlPattern: pattern,
  handler: /** @type {const} */ ('CacheFirst'),
  options: {
    cacheName,
    expiration: { maxEntries },
    cacheableResponse: { statuses: [0, 200] },
    rangeRequests: true,
  },
});

export default defineConfig({
  site: 'https://reankhmer.seuksa.com',
  trailingSlash: 'ignore',
  // /letters -> letters.html: works on GitHub Pages and with Workbox cleanURLs offline.
  build: { format: 'file' },
  integrations: [
    vue(),
    AstroPWA({
      registerType: 'autoUpdate',
      includeAssets: ['icons/apple-touch-icon.png'],
      manifest: {
        name: 'ReanKhmer · រៀនខ្មែរ',
        short_name: 'រៀនខ្មែរ',
        description: 'Learn to read, hear and speak Khmer — for Khmer families abroad.',
        lang: 'km',
        start_url: '/',
        scope: '/',
        display: 'standalone',
        background_color: '#ffffff',
        theme_color: '#0f766e',
        icons: [
          { src: '/icons/icon-192.png', sizes: '192x192', type: 'image/png' },
          { src: '/icons/icon-512.png', sizes: '512x512', type: 'image/png' },
          { src: '/icons/maskable-512.png', sizes: '512x512', type: 'image/png', purpose: 'maskable' },
        ],
      },
      workbox: {
        // App shell + every page is precached; lesson audio/images are cached on first use
        // or all at once from the Progress page ("Download for offline").
        globPatterns: ['**/*.{html,js,css,svg,woff2}'],
        globIgnores: ['assets/**'],
        navigateFallback: null,
        cleanURLs: true,
        runtimeCaching: [media(/\/assets\/audio\//, 'rk-audio', 800), media(/\/assets\/images\//, 'rk-images', 300)],
      },
    }),
  ],
  vite: {
    plugins: [tailwindcss()],
    server: { fs: { allow: ['..'] } },
  },
});
