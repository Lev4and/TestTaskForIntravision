<script>
import { api } from "../api";

export default {
  data: () => ({
    coins: [],
    selectedCoin: null,
  }),

  watch: {
    coins: {
      async handler() {
        if (!this.coins.length) {
          this.coins = await this.getCoins();
        }
      },
      immediate: true,
    },
  },

  methods: {
    async getCoins() {
      return (await api.coins.get())?.result || [];
    },
    async saveCoin() {
      const response = await api.coins.put("", this.selectedCoin);
      if (response.code === 200) {
        alert("The data has been saved successfully");
        location.reload();
      } else {
        alert(`An error occurred while saving the data ${response.message}`);
      }
    },
    async onClickSaveCoin() {
      await this.saveCoin();
    },
    onClickCancelSaveCoin() {
      this.selectedCoin = null;
    },
    onClickEditCoin(coin) {
      this.selectedCoin = coin;
    },
  },
};
</script>

<template>
  <table class="table table-bordered border-primary">
    <thead>
      <tr class="align-middle">
        <th>Value</th>
        <th>Count</th>
        <th>Blocked for deposit</th>
        <th>Actions</th>
      </tr>
    </thead>
    <tbody>
      <tr v-if="selectedCoin" class="align-middle">
        <td>
          <span v-text="selectedCoin.value" />
        </td>
        <td>
          <input
            type="number"
            class="form-control"
            min="0"
            v-model="selectedCoin.storage.count"
          />
        </td>
        <td>
          <input
            type="checkbox"
            class="form-check-input"
            v-model="selectedCoin.storage.isBlockedForDeposit"
          />
        </td>
        <td>
          <div class="d-flex gap-3">
            <a v-if="selectedCoin" href="#" @click="onClickSaveCoin">Save</a>
            <a href="#" @click="onClickCancelSaveCoin">Cancel</a>
          </div>
        </td>
      </tr>
      <tr v-for="coin in coins" :key="coin.id" class="align-middle">
        <td>
          <span v-text="coin.value" />
        </td>
        <td>
          <span v-text="coin.storage.count" />
        </td>
        <td>
          <span v-text="coin.storage.isBlockedForDeposit" />
        </td>
        <td>
          <div class="d-flex gap-3">
            <a href="#" @click="onClickEditCoin(coin)">Edit</a>
          </div>
        </td>
      </tr>
    </tbody>
  </table>
</template>
