<script lang="ts" setup>
import TodoEntryComponent from "@/components/TodoEntryComponent.vue";
import { TodoEntry } from "@/models";
import { ref } from "vue";
const todoEntry = ref<TodoEntry>({
  Name: "Lorem ipsum",
  Desciption:
    "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et",
  Done: false,
});

const handleEntryChanged = (todoEntry: TodoEntry) => {
  console.log(todoEntry);
};
</script>
<template>
  <TodoEntryComponent
    :todo-entry="todoEntry"
    @entry-changed="handleEntryChanged"
  >
  </TodoEntryComponent>
</template>
