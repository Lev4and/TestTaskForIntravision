<script>
import { cart } from "@/stores/cart.js";
import { balance } from "@/stores/balance.js";

export default {
  props: {
    beverage: {
      type: Object,
      required: true,
    },
  },

  computed: {
    freeBalance() {
      return balance().total - balance().spent;
    },
    canAddToCart() {
      return (
        this.beverage.storage.count &&
        this.freeBalance >= this.beverage.price &&
        (cart().items[this.beverage.id] || 0) < this.beverage.storage.count
      );
    },
  },

  methods: {
    addToCart() {
      cart().add(this.beverage)
      balance().spend(this.beverage.price)
    },
  },
};
</script>

<template>
  <div class="beverages__grid__item col-12 col-md-6 col-lg-4">
    <div class="card shadow-sm">
      <img
        class="beverages__grid__item__image bd-placeholder-img card-img-top"
        width="100%"
        height="150"
        ole="img"
        :src="beverage.image.url"
      />
      <div class="card-body">
        <p
          :id="`beverages__item__${beverage.id}__title`"
          class="beverages__grid__item__title card-text text-center"
          v-text="beverage.title"
        />
        <div class="row align-items-center">
          <div class="col-6 text-left">{{ beverage.price }} руб.</div>
          <div class="col-6">
            <button class="btn btn-primary" :disabled="!canAddToCart" @click="addToCart">
              Add to cart
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.beverages__grid__item .beverages__grid__item__image {
  margin: 5px;
  width: 100%;
  object-fit: contain;
}

.beverages__grid__item .beverages__grid__item__title {
  overflow: hidden;
  display: -webkit-box;
  -webkit-line-clamp: 2;
  text-overflow: ellipsis;
  line-clamp: 2;
  -webkit-box-orient: vertical;
}
</style>
