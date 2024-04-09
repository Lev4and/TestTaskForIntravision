<script>
import { api } from "../api";
import BeveragesGrid from "@/components/BeveragesGrid.vue";

export default {
  components: {
    BeveragesGrid,
  },

  data: () => ({
    beverages: [],
  }),

  watch: {
    beverages: {
      async handler() {
        if (!this.beverages.length) {
          this.beverages = await this.getBeverages();
        }
      },
      immediate: true,
    },
  },

  methods: {
    async getBeverages() {
      return (await api.beverages.get())?.result || [];
    },
  },
};
</script>

<template>
  <div class="beverages">
    <h1 class="mb-3">Beverages</h1>
    <hr />
    <beverages-grid :beverages="beverages" />
  </div>
</template>
