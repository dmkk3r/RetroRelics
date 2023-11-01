<script lang="ts">
	import { Book, Home, LibraryBig, LogOut, Settings } from 'lucide-svelte';
</script>

<div class="flex h-28 flex-col bg-stone-900 font-mono">
	<div class="flex">
		<a
			href="/"
			class="flex items-start justify-center rounded-br-2xl bg-stone-800 hover:bg-stone-700"
		>
			<h1 class="px-6 py-3 text-lg font-bold text-white">RetroRelics</h1>
		</a>
		<div class="flex flex-grow items-center justify-end pr-6">
			<button class="rounded-full p-2 hover:bg-stone-700">
				<LogOut color="white" size="20" />
			</button>
		</div>
	</div>
	<div class="flex flex-grow flex-row items-center space-x-12 pl-6">
		<span class="flex flex-row items-center space-x-2">
			<Home color="#ffffff" size="18" />
			<p class="text-sm text-white">Home</p>
		</span>
		<span class="flex flex-row items-center space-x-2">
			<LibraryBig color="#ffffff" size="18" />
			<p class="text-sm text-white">Collections</p>
		</span>
		<span class="flex flex-row items-center space-x-2">
			<Book color="#ffffff" size="18" />
			<p class="text-sm text-white">Relics</p>
		</span>
		<span class="flex flex-row items-center space-x-2">
			<Settings color="#ffffff" size="18" />
			<p class="text-sm text-white">Settings</p>
		</span>
	</div>
</div>
