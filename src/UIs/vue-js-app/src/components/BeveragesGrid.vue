<script>
import BeveragesGridItem from "@/components/BeveragesGridItem.vue";

export default {
  components: {
    BeveragesGridItem,
  },

  props: {
    beverages: {
      type: Array,
      required: true,
    },
  },
};
</script>

<template>
  <div class="beverages__grid row mb-3 g-3">
    <beverages-grid-item
      v-for="beverage in beverages"
      :key="beverage.id"
      :beverage="beverage"
    />
  </div>
</template>
