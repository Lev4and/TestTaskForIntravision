import { defineStore } from "pinia";

export const cart = defineStore({
  id: "cart",
  state: () => ({
    value: {},
  }),
  getters: {
    items: (state) => state.value,
  },
  actions: {
    add(item) {
      this.value[item.id] = !!this.value[item.id] ? this.value[item.id] + 1 : 1;
    },
    clear() {
      this.value = {};
    },
  },
});
