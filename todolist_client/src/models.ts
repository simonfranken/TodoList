import type { RouteRecordRaw } from "vue-router";

export interface route {
  path: string;
  component: any;
  key: string;
  icon: string;
  displayName: string;
}
