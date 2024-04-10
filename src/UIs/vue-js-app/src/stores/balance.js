import { defineStore } from "pinia";

export const balance = defineStore({
  id: "balance",
  state: () => ({
    used: 0,
    value: 0,
    coins: {},
  }),
  getters: {
    spent: (state) => state.used,
    total: (state) => state.value,
    depositedCoins: (state) => state.coins,
  },
  actions: {
    increment(coin) {
      this.coins[coin.id] = this.coins[coin.id] ? this.coins[coin.id] + 1 : 1;
      this.value += coin.value;
    },
    spend(value) {
      this.used += value;
    },
    clear() {
      this.coins = {};
      this.value = 0;
      this.used = 0;
    },
  },
});
