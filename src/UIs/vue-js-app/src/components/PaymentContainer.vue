<script>
import { cart } from "@/stores/cart.js";
import { balance } from "@/stores/balance.js";
import DepositMoney from "@/components/DepositMoney.vue";

export default {
  components: {
    DepositMoney,
  },

  computed: {
    cart() {
      return cart().items;
    },
    totalBalance() {
      return balance().total;
    },
    spentBalance() {
      return balance().spent;
    },
  },

  methods: {
    cancelPayment() {
      cart().clear();
      balance().clear();
    },
    async pay() {
      cart().clear();
      balance().clear();
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
      <span> To be paid {{ spentBalance }} руб. </span>
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
        :disabled="!cart.length"
        @click="pay"
        v-text="'To pay'"
      />
    </div>
  </div>
</template>
