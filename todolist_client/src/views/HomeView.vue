<script setup lang="ts">
import TodoEntryComponent from "@/components/TodoEntryComponent.vue";
import type { TodoEntry } from "@/models";
import { reactive } from "vue";

const todoList = reactive<TodoEntry[]>([
  {
    entryId: "1",
    name: "Lorem ipsum",
    description:
      "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
    done: false,
  },
  {
    entryId: "2",
    name: "Lorem ipsum",
    description:
      "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
    done: false,
  },
  {
    entryId: "3",
    name: "Lorem ipsum",
    description:
      "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
    done: false,
  },
]);
const handleChange = (updatedEntry: TodoEntry) => {
  console.log(updatedEntry);
};
</script>
<template>
  <div class="d-flex justify-content-end">
    <input type="button" class="btn btn-primary" value="Add" />
  </div>
  <hr />
  <div class="row row-cols-3">
    <TodoEntryComponent
      v-for="todoEntry in todoList"
      :key="todoEntry.entryId"
      :todo-entry="todoEntry"
      @on-change="handleChange"
    />
    <!-- <TodoEntryComponent :todo-entry="todoList[0]" /> -->
  </div>
</template>
