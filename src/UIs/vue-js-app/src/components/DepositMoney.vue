<script>
import { api } from "../api";
import CoinsGrid from "@/components/CoinsGrid.vue";

export default {
  components: {
    CoinsGrid,
  },

  data: () => ({
    coins: [],
  }),

  watch: {
    coins: {
      async handler() {
        if (!this.coins.length) {
          this.coins = await this.getCoins();
        }
      },
      immediate: true,
    },
  },

  methods: {
    async getCoins() {
      return (await api.coins.get())?.result || [];
    },
  },
};
</script>

<template>
  <div class="deposit-money">
    <h4 class="mb-3">Deposit money</h4>
    <coins-grid :coins="coins" />
  </div>
</template>

<style scoped></style>
