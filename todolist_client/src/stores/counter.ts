import { ref, computed } from "vue";
import { defineStore } from "pinia";
import type { TodoEntry } from "@/models";

export const useCounterStore = defineStore("counter", () => {
  const count = ref(0);
  const doubleCount = computed(() => count.value * 2);
  function increment() {
    count.value++;
  }

  return { count, doubleCount, increment };
});

export const useTodoList = defineStore("todoList", () => {
  const todoList = ref<TodoEntry[]>();
  const loadTodoList = 
});
