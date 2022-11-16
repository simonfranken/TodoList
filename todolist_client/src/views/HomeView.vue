<script setup lang="ts">
import TodoEntryComponent from "@/components/TodoEntryComponent.vue";
import type { TodoEntry } from "@/models";
import {
  deleteEntry,
  getAllEntries,
  saveEntry,
} from "@/Services/TodoListService";
import { reactive } from "vue";

const state = reactive<{ todoList: TodoEntry[]; newEntry?: TodoEntry }>({
  todoList: [],
});
getAllEntries().then((response) => {
  state.todoList = response;
});

const reloadTodoList = () => {
  getAllEntries().then((response) => {
    state.todoList = response;
    state.newEntry = undefined;
  });
};

const handleSave = (updatedEntry: TodoEntry) => {
  saveEntry(updatedEntry).then(() => {
    reloadTodoList();
  });
};

const handleAdd = () => {
  state.newEntry = {
    name: "",
    description: "",
    done: false,
  };
};

const handleSaveNew = (newEntry: TodoEntry) => {
  saveEntry(newEntry).then(() => {
    reloadTodoList();
  });
};

const handleDelete = (todoEntry: TodoEntry) => {
  deleteEntry(todoEntry.entryId!).then(() => {
    reloadTodoList();
  });
};
</script>
<template>
  <div class="d-flex justify-content-end">
    <input
      type="button"
      class="btn btn-primary"
      value="Add"
      @click="handleAdd"
    />
  </div>
  <hr />
  <div class="row row-cols-3 row-cols-auto">
    <TodoEntryComponent
      v-for="todoEntry in state.todoList"
      :key="todoEntry.entryId"
      :todo-entry="todoEntry"
      @on-save="handleSave"
      @on-delete="handleDelete"
    />
    <TodoEntryComponent
      v-if="state.newEntry != null"
      :todo-entry="state.newEntry!"
      :edit-mode-default="true"
      @on-save="handleSaveNew"
    />
  </div>
</template>
