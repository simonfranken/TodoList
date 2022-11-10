<template>
  <v-layout>
    <NavigationDrawer />
    <v-main />
  </v-layout>
</template>

<script lang="ts" setup>
import { defineComponent } from "vue";
import NavigationDrawer from "./components/NavigationDrawer.vue";
</script>
