<script>
	import Footer from '$lib/components/shell/Footer.svelte';
	import Navbar from '$lib/components/shell/Navbar.svelte';
	import Sidebar from '$lib/components/shell/Sidebar.svelte';
	import '../app.css';
</script>

<div class="flex h-screen w-screen flex-col bg-stone-950">
	<Navbar />
	<div class="flex h-full flex-row overflow-auto p-4">
		<slot />
	</div>
	<Footer />
</div>
