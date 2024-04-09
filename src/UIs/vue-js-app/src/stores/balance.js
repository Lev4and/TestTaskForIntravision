import { defineStore } from "pinia";

export const balance = defineStore({
  id: "balance",
  state: () => ({
    used: 0,
    value: 0,
  }),
  getters: {
    spent: (state) => state.used,
    total: (state) => state.value,
  },
  actions: {
    increment(value) {
      this.value += value;
    },
    spend(value) {
      this.used += value;
    },
    clear() {
      this.value = 0;
      this.used = 0;
    },
  },
});
