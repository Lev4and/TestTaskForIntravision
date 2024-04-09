<script>
import PaymentContainer from "@/components/PaymentContainer.vue";
import BeveragesContainer from "@/components/BeveragesContainer.vue";

export default {
  components: {
    PaymentContainer,
    BeveragesContainer,
  },
};
</script>

<template>
  <div class="home-view">
    <h1>Vending machine</h1>
    <hr />
    <div class="row">
      <div class="col-xl-4">
        <payment-container />
        <hr class="d-xl-none" />
      </div>
      <div class="col-xl-8">
        <beverages-container />
      </div>
    </div>
  </div>
</template>

<style scoped></style>
