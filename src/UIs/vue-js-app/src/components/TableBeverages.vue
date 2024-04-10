<script>
import _ from "lodash";
import { api } from "../api";

export default {
  data: () => ({
    beverages: [],
    emptyBeverage: {
      title: "",
      price: 1,
      image: {
        url: "",
      },
      storage: {
        count: 0,
      },
    },
    selectedBeverage: null,
  }),

  watch: {
    beverages: {
      async handler() {
        if (!this.beverages.length) {
          this.beverages = await this.getBeverages();
        }
      },
      immediate: true,
    },
    selectedBeverage: {
      handler() {
        if (!this.selectedBeverage) {
          this.selectedBeverage = _.cloneDeep(this.emptyBeverage);
        }
      },
      immediate: true,
    },
  },

  methods: {
    async getBeverages() {
      return (await api.beverages.get())?.result || [];
    },
    async addBeverage() {
      const response = await api.beverages.post("", this.selectedBeverage);
      if (response.code === 200) {
        alert("The data has been saved successfully");
        location.reload();
      } else {
        alert(`An error occurred while saving the data ${response.message}`);
      }
    },
    async updateBeverage() {
      const response = await api.beverages.put("", this.selectedBeverage);
      if (response.code === 200) {
        alert("The data has been saved successfully");
        location.reload();
      } else {
        alert(`An error occurred while saving the data ${response.message}`);
      }
    },
    async deleteBeverage(beverageId) {
      const response = await api.beverages.delete(`${beverageId}`);
      if (response.code === 200) {
        alert("The data was successfully deleted");
        location.reload();
      } else {
        alert(`An error occurred while deleting the data ${response.message}`);
      }
    },
    onClickEditBeverage(beverage) {
      this.selectedBeverage = beverage;
    },
    async onClickDeleteBeverage(beverage) {
      await this.deleteBeverage(beverage.id);
    },
    async onClickSaveBeverage() {
      if (this.selectedBeverage.id) {
        await this.updateBeverage();
      } else {
        await this.addBeverage();
      }
    },
    onClickCancelSaveBeverage() {
      this.selectedBeverage = _.cloneDeep(this.emptyBeverage);
    },
  },
};
</script>

<template>
  <table class="table table-bordered border-primary">
    <thead>
      <tr class="align-middle">
        <th></th>
        <th>Image URL</th>
        <th>Title</th>
        <th>Price</th>
        <th>Count</th>
        <th>Actions</th>
      </tr>
    </thead>
    <tbody>
      <tr v-if="selectedBeverage" class="align-middle">
        <td>
          <img
            style="width: 100px; height: 100px; object-fit: contain"
            :src="selectedBeverage.image.url"
          />
        </td>
        <td>
          <input
            type="text"
            class="form-control"
            v-model="selectedBeverage.image.url"
          />
        </td>
        <td>
          <input
            type="text"
            class="form-control"
            v-model="selectedBeverage.title"
          />
        </td>
        <td>
          <input
            type="number"
            class="form-control"
            min="1"
            v-model="selectedBeverage.price"
          />
        </td>
        <td>
          <input
            type="number"
            class="form-control"
            min="0"
            v-model="selectedBeverage.storage.count"
          />
        </td>
        <td>
          <div class="d-flex gap-3">
            <a href="#" @click="onClickSaveBeverage">Save</a>
            <a href="#" @click="onClickCancelSaveBeverage">Cancel</a>
          </div>
        </td>
      </tr>
      <tr v-for="beverage in beverages" :key="beverage.id" class="align-middle">
        <td>
          <img
            style="width: 100px; height: 100px; object-fit: contain"
            :src="beverage.image.url"
          />
        </td>
        <td>
          <span v-text="beverage.image.url" />
        </td>
        <td>
          <span v-text="beverage.title" />
        </td>
        <td>
          <span v-text="beverage.price" />
        </td>
        <td>
          <span v-text="beverage.storage.count" />
        </td>
        <td>
          <div class="d-flex gap-3">
            <a href="#" @click="onClickEditBeverage(beverage)">Edit</a>
            <a href="#" @click="onClickDeleteBeverage(beverage)">Delete</a>
          </div>
        </td>
      </tr>
    </tbody>
  </table>
</template>
