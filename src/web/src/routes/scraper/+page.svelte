<script lang="ts">
	import { BookPlus, LogOut } from 'lucide-svelte';
	import { onMount } from 'svelte';

	onMount(() => {
		let string =
			'<!DOCTYPE><html><head><title>Iframe</title></head><body>Placeholder HTML</body></html>';
		let blob = new Blob([string], { type: 'text/html' });
		let url = URL.createObjectURL(blob);
		let iframe = document.getElementById('iframe') as HTMLIFrameElement;

		iframe.src = url;
	});
</script>

<div class="flex h-full w-full flex-row space-x-4">
	<iframe id="iframe" class="rounded-sm bg-white" width="100%" height="100%" title=""></iframe>
	<div class="flex h-full min-w-[33%] flex-col space-y-2">
		<div class="flex flex-row items-center justify-between rounded-sm bg-stone-700 p-2">
			<p class="text-md font-mono text-white">Steps</p>
			<button class="rounded-full p-2 hover:bg-stone-600">
				<BookPlus color="white" size="16" />
			</button>
		</div>
		<div class="flex-grow rounded-sm bg-stone-800 p-2"></div>
	</div>
</div>
