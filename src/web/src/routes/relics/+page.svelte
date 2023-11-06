<script lang="ts">
	import type { PageData } from './$types';

	export let data: PageData;
</script>

{#if data.relics.error}
	<div>There was an error: {data.relics.error}</div>
{:else if data.relics.data}
	<pre><code class="text-white">{JSON.stringify(data.relics.data, undefined, 2)}</code></pre>
{:else}
	<div>Loading...</div>
{/if}
