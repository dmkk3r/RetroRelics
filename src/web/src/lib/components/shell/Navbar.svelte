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
		<div class="flex flex-grow items-center justify-center">
			<input
				class="flex h-10 w-2/5 items-center justify-center rounded-sm
             border-none bg-stone-800 px-3 pr-12 text-white focus:border-none focus:outline-none focus:ring-1 focus:ring-stone-700"
				placeholder="Search..."
			/>
		</div>
		<div class="flex items-center justify-end pr-6">
			<button class="rounded-full p-2 hover:bg-stone-700">
				<LogOut color="white" size="20" />
			</button>
		</div>
	</div>
	<div class="flex flex-grow flex-row items-center space-x-12 pl-6">
		<a href="/" class="flex flex-row items-center space-x-2">
			<Home color="#ffffff" size="18" />
			<p class="text-sm text-white">Home</p>
		</a>
		<a href="/collections" class="flex flex-row items-center space-x-2">
			<LibraryBig color="#ffffff" size="18" />
			<p class="text-sm text-white">Collections</p>
		</a>
		<a href="/relics" class="flex flex-row items-center space-x-2">
			<Book color="#ffffff" size="18" />
			<p class="text-sm text-white">Relics</p>
		</a>
		<a href="/settings" class="flex flex-row items-center space-x-2">
			<Settings color="#ffffff" size="18" />
			<p class="text-sm text-white">Settings</p>
		</a>
	</div>
</div>
