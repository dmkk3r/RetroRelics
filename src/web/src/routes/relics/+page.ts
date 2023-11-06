import client from '$lib/api/index.js';

export async function load({ fetch }) {
	const relics = await client.GET('/relics', {
		fetch
	});

	return {
		relics: {
			data: relics.data,
			error: relics.error
		}
	};
}
