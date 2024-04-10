<script>
import TableCoins from "../components/TableCoins.vue";
import TableBeverages from "../components/TableBeverages.vue";

export default {
  components: {
    TableCoins,
    TableBeverages,
  },
};
</script>

<template>
  <div class="admin-view">
    <h1>Admin panel</h1>
    <hr />
    <h1>Coins</h1>
    <hr />
    <table-coins />
    <h1>Beverages</h1>
    <hr />
    <table-beverages />
  </div>
</template>
