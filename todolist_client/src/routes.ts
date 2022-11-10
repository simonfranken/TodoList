import VueRouter from "vue-router";
import { mdi } from "vuetify/lib/iconsets/mdi";
import HomePage from "./pages/HomePage.vue";
import SettingsPage from "./pages/SettingsPage.vue";

export const routes = [
  {
    key: "home",
    path: "/",
    component: HomePage,
    displayTitle: "Home",
    icon: "mdi-home",
  },
  {
    key: "settings",
    path: "/settings",
    component: SettingsPage,
    displayTitle: "Settings",
    icon: "mdi-cog",
  },
];
