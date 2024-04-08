<script setup lang="ts"></script>

<template>
  <header class="border-bottom lh-1 py-3">
    <div class="row flex-nowrap justify-content-between align-items-center">
      <div class="col-4 pt-1"></div>
      <div class="col-4 text-center">
        <router-link class="blog-header-logo text-body-emphasis text-decoration-none" to="/">
          Vending machine
        </router-link>
      </div>
      <div class="col-4 d-flex justify-content-end align-items-center">
        <router-link class="btn btn-sm btn-outline-secondary" to="/admin"> Admin </router-link>
      </div>
    </div>
  </header>
</template>
