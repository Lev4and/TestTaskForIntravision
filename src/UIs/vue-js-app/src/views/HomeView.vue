<script>
export default {
  data: () => ({
    coins: [],
  }),

  watch: {
    coins: {
      async handler() {
        this.coins = await this.getCoins();
      },
    },
  },

  methods: {
    async getCoins() {},
  },
};
</script>

<template>
  <div class="home-view">
    <h1>Vending machine</h1>
    <hr />
    <div class="row">
      <div class="col-xl-4">
        <h1 class="mb-3">Payment</h1>
        <hr />
        <h4 class="mb-3">Deposit money</h4>
        <button v-for="coin in coins" :key="coin.id" v-text="coin.value" />
        <hr class="my-4" />
        <div class="d-grid gap-2">
          <button class="w-100 btn btn-danger btn-lg">
            Cancel the payment
          </button>
          <button class="w-100 btn btn-primary btn-lg">
            To pay
          </button>
        </div>
        <hr class="d-xl-none" />
      </div>
      <div class="col-xl-8">
        <h1 class="mb-3">Beverages</h1>
        <hr />
      </div>
    </div>
  </div>
</template>
