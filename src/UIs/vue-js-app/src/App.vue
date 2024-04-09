<script>
import DefaultFooter from "@/components/DefaultFooter.vue";
import DefaultHeader from "@/components/DefaultHeader.vue";

export default {
  components: {
    DefaultFooter,
    DefaultHeader,
  },
};
</script>

<template>
  <div>
    <div class="container position-sticky top-0" style="z-index: 100">
      <default-header />
    </div>
    <main class="container">
      <router-view />
    </main>
    <default-footer />
  </div>
</template>

<style scoped></style>
