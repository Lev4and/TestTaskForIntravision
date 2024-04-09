<script setup lang="ts">
import { ref, reactive, onMounted } from 'vue'
import axios from 'axios'

let coins: any[] = reactive([])
let beverages: any[] = reactive([])

onMounted(async () => {
  coins = await getCoins()
  beverages = await getBeverages()
  console.log(coins, beverages)
})

async function getCoins() {
  const response = await axios.get(`http://${window.location.hostname}/api/coins/v1/`)
  return response?.data?.result || []
}

async function getBeverages() {
  const response = await axios.get(`http://${window.location.hostname}/api/beverages/v1/`)
  return response?.data?.result || []
}

async function cancelPayment() {
  console.log('cancelPayment')
}

async function pay() {
  console.log('pay')
}
</script>

<template>
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
        <button class="w-100 btn btn-danger btn-lg" @click="cancelPayment">
          Cancel the payment
        </button>
        <button class="w-100 btn btn-primary btn-lg" @click="pay">To pay</button>
      </div>
      <hr class="d-xl-none" />
    </div>
    <div class="col-xl-8">
      <h1 class="mb-3">Beverages</h1>
      <hr />
    </div>
  </div>
</template>
