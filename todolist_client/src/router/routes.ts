import type { route } from "@/models";
import HomeView from "@/views/HomeView.vue";

export const routes: route[] = [
  {
    path: "/",
    component: HomeView,
    key: "home",
    displayName: "Home",
    icon: "mdi-home",
  },
];
