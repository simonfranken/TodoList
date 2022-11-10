<template>
  <v-navigation-drawer permanent>
    <v-list>
      <v-list-item title="Todo Liste" subtitle="$User" />
    </v-list>

    <v-divider></v-divider>

    <v-list density="compact" nav>
      <v-list-item
        v-for="route in props.routes"
        active-color="primary"
        :prepend-icon="route.icon"
        :title="route.displayTitle"
        :key="route.key"
        :value="route.key"
        :to="route.path"
      />
    </v-list>
  </v-navigation-drawer>
</template>
<script lang="ts" setup>
import { defineProps } from "vue";
const props = defineProps({
  routes: {
    type: Object as () => {
      key: string;
      displayTitle: string;
      icon: string;
      path: string;
    }[],
  },
});
</script>
