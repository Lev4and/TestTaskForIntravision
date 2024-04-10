<script>
import { balance } from "@/stores/balance.js";

export default {
  props: {
    coin: {
      type: Object,
      required: true,
    },
  },

  methods: {
    incrementBalance() {
      balance().increment(this.coin);
    },
  },
};
</script>

<template>
  <button
    :disabled="coin.storage.isBlockedForDeposit"
    class="coins-grid__item"
    @click="incrementBalance"
  >
    <strong v-text="coin.value" />
  </button>
</template>

<style scoped>
.coins-grid__item {
  width: 50px;
  height: 50px;
  border-radius: 50%;
  border: 1px solid black;
}
</style>
