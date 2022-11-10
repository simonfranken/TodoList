<template>
  <v-navigation-drawer permanent>
    <v-list-item>
      <v-list-item-content>
        <v-list-item-title class="text-h6"> Todo </v-list-item-title>
        <v-list-item-subtitle> subtext</v-list-item-subtitle>
      </v-list-item-content>
    </v-list-item>

    <v-divider />

    <v-list dens nav>
      <v-list-item prepend-icon="mdi-home-outline" value="home">
        Home
      </v-list-item>
      <v-list-item prepend-icon="mdi-cog-outline" value="settings">
        Settings
      </v-list-item>
    </v-list>
  </v-navigation-drawer>
</template>
<script lang="ts" setup></script>
