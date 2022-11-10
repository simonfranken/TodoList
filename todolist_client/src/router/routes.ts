import type { route } from "@/models"
import HomeView from "src/views/HomeView.vue"

export const routes: route[] = [
  {
    path: "/test",
    component: HomeView,
    key: "home",
    displayName: "Home",
    icon: "mdi-home",
  },
]
