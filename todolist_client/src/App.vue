<script setup lang="ts">
import NavigationComponent from "./components/NavigationComponent.vue";
import { routes } from "./router/routes";
</script>

<template>
  <NavigationComponent :routes="routes" />
  <div class="container"></div>
</template>
