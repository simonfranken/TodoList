<script setup lang="ts">
import NavigationComponent from "./components/NavigationComponent.vue";
import { routes } from "./router/routes";
</script>

<template>
  <NavigationComponent class="mb-3" :routes="routes" />
  <div class="container">
    <RouterView />
  </div>
</template>
