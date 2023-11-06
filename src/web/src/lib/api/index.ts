import createClient from 'openapi-fetch';
import type { paths } from './retrorelics';

const httpClient = createClient<paths>({ baseUrl: 'http://localhost:5276' });
export default httpClient;
