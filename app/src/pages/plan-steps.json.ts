// The study-plan path (see content.ts → planSteps), published once as a small JSON file that the
// plan islands fetch (and the service worker precaches), instead of repeating it in every page.
import type { APIRoute } from 'astro';
import { planSteps } from '../lib/content';

export const GET: APIRoute = () => new Response(JSON.stringify(planSteps()), { headers: { 'Content-Type': 'application/json' } });
