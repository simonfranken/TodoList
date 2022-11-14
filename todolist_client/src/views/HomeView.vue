<script setup lang="ts">
import TodoEntryComponent from "@/components/TodoEntryComponent.vue";
import type { TodoEntry } from "@/models";
import { getAllEntries, saveEntry } from "@/Services/TodoListService";
import { reactive } from "vue";

const state = reactive<{ todoList: TodoEntry[] }>({ todoList: [] });
getAllEntries().then((response) => {
  state.todoList = response;
});
const handleChange = (updatedEntry: TodoEntry) => {
  saveEntry(updatedEntry).then((response) => {
    state.todoList.map((x) => (x.entryId == response.entryId ? response : x));
  });
};
</script>
<template>
  <div class="d-flex justify-content-end">
    <input type="button" class="btn btn-primary" value="Add" />
  </div>
  <hr />
  <div class="row row-cols-3">
    <TodoEntryComponent
      v-for="todoEntry in state.todoList"
      :key="todoEntry.entryId"
      :todo-entry="todoEntry"
      @on-change="handleChange"
    />
    <!-- <TodoEntryComponent :todo-entry="todoList[0]" /> -->
  </div>
</template>
