import { defineStore } from "pinia";

export const cart = defineStore({
  id: "cart",
  state: () => ({
    value: [],
  }),
  getters: {
    items: (state) => state.value,
  },
  actions: {
    add(item) {
      this.value.push(item);
    },
    clear() {
      this.value = [];
    },
  },
});
