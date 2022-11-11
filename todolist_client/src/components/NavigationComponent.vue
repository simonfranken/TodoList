<script lang="ts" setup>
import type { route } from "@/models";

const props = defineProps({
  routes: {
    type: Object as () => route[],
    required: true,
  },
});
</script>
<template>
  <nav class="navbar navbar-expand-lg bg-light">
    <div class="container">
      <RouterLink class="navbar-brand" to="/">Todo</RouterLink>
      <button
        class="navbar-toggler"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
          <li class="nav-item" v-for="route in props.routes" :key="route.key">
            <RouterLink class="nav-link active" :to="route.path">{{
              route.displayName
            }}</RouterLink>
          </li>
        </ul>
      </div>
    </div>
  </nav>
</template>
