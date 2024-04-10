<script>
import { api } from "../api";
import { cart } from "@/stores/cart.js";
import { balance } from "@/stores/balance.js";
import DepositMoney from "@/components/DepositMoney.vue";

export default {
  components: {
    DepositMoney,
  },

  computed: {
    depositedCoins() {
      return balance().depositedCoins;
    },
    selectedBeverages() {
      return cart().items;
    },
    totalBalance() {
      return balance().total;
    },
    notSpentBalance() {
      return balance().total - balance().spent;
    },
  },

  methods: {
    cancelPayment() {
      cart().clear();
      balance().clear();
    },
    async pay() {
      const response = await api.beverages.buy(this.depositedCoins, this.selectedBeverages);
      if (response.code === 200) {
        alert(`The purchase was successful. The change: ${JSON.stringify(response.result)}`);
        location.reload();
      } else {
        alert(`An error occurred while making a purchase: ${response.message}`);
      }
    },
  },
};
</script>

<template>
  <div class="payment">
    <h1 class="mb-3">Payment</h1>
    <hr />
    <deposit-money />
    <hr class="my-4" />
    <div class="d-flex flex-column gap-3">
      <span> Total balance {{ totalBalance }} руб. </span>
      <span> Not spent {{ notSpentBalance }} руб. </span>
    </div>
    <hr class="my-4" />
    <div class="d-grid gap-2">
      <button
        class="w-100 btn btn-danger btn-lg"
        :disabled="!totalBalance"
        @click="cancelPayment"
        v-text="'Cancel the payment'"
      />
      <button
        class="w-100 btn btn-primary btn-lg"
        :disabled="!Object.keys(selectedBeverages).length"
        @click="pay"
        v-text="'To pay'"
      />
    </div>
  </div>
</template>
