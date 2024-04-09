<script>
import CoinsGridItem from "@/components/CoinsGridItem.vue";

export default {
  components: {
    CoinsGridItem,
  },

  props: {
    coins: {
      type: Array,
      required: true,
    },
  },
};
</script>

<template>
  <div class="coins-grid">
    <coins-grid-item v-for="coin in coins" :key="coin.id" :coin="coin" />
  </div>
</template>

<style scoped>
.coins-grid {
  gap: 5px;
  display: flex;
  flex-wrap: wrap;
  flex-direction: row;
  justify-content: center;
}
</style>
