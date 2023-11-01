<script>
	import Footer from '$lib/components/shell/Footer.svelte';
	import Navbar from '$lib/components/shell/Navbar.svelte';
	import Sidebar from '$lib/components/shell/Sidebar.svelte';
	import '../app.css';
</script>

<div class="w-screen h-screen flex flex-col bg-stone-950">
	<Navbar />
	<div class="flex flex-row h-full">
		<div class="flex h-full">

			<Sidebar />
		</div>
		<div class="flex flex-grow">
			<slot />
		</div>
	</div>
	<Footer />
</div>
