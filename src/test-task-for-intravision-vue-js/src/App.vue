<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import Header from './components/Header.vue'
import Footer from './components/Footer.vue'
</script>

<template>
  <div class="container position-sticky top-0" style="z-index: 100">
    <Header />
  </div>
  <main class="container">
    <RouterView />
  </main>
  <Footer />
</template>

<style scoped></style>
