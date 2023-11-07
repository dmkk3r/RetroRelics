<script lang="ts">
	import type { PageData } from './$types';

	export let data: PageData;
</script>

<div class="">
	<h1 class="text-white">Relics</h1>
	{#if data.relics.error}
		<div class="text-white">There was an error: {data.relics.error}</div>
	{:else if data.relics.data}
		<pre><code class="text-white">{JSON.stringify(data.relics.data, undefined, 2)}</code></pre>
	{:else}
		<div class="text-white">Loading...</div>
	{/if}
</div>
