<template>
  <v-layout>
    <NavigationDrawer v-bind:routes="routes" />
    <v-main>
      <RouterView></RouterView>
    </v-main>
  </v-layout>
</template>

<script lang="ts" setup>
import NavigationDrawer from "./components/NavigationDrawer.vue";
import { routes } from "./routes";
</script>
