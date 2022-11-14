<script setup lang="ts">
import type { TodoEntry } from "@/models";
import { reactive, ref } from "vue";

const props = defineProps({
  todoEntry: {
    type: Object as () => TodoEntry,
    required: true,
  },
  editModeDefault: {
    type: Boolean,
    default: false,
  },
});

const events = defineEmits<{
  (e: "onChange", todoEntry: TodoEntry): void;
  (e: "onDelete", todoEntry: TodoEntry): void;
}>();

const todoEntryState = reactive<TodoEntry>(props.todoEntry);

const editMode = ref<boolean>(props.editModeDefault);

const handleDone = () => {
  todoEntryState.done = todoEntryState.done ? false : true;
  events("onChange", todoEntryState);
};

const handleSave = () => {
  events("onChange", todoEntryState);
  editMode.value = false;
};

const handleDelete = () => {
  events("onDelete", todoEntryState);
};
</script>
<template>
  <div class="mb-3">
    <div class="" v-if="!editMode">
      <div class="card">
        <div class="card-body">
          <div class="card-title row">
            <h5 class="col">
              <div v-if="todoEntryState.done">
                <del>{{ todoEntryState.name }}</del>
              </div>
              <div v-else>
                {{ todoEntryState.name }}
              </div>
            </h5>
            <div class="col-md-auto dropdown-center">
              <button
                class="btn btn-sm dropdown-toggle"
                type="button"
                data-bs-toggle="dropdown"
                aria-expanded="false"
              />
              <ul class="dropdown-menu">
                <li>
                  <button
                    class="dropdown-item"
                    @click="() => (editMode = true)"
                  >
                    Edit
                  </button>
                </li>
                <li>
                  <button class="dropdown-item" @click="handleDelete">
                    Delete
                  </button>
                </li>
              </ul>
            </div>
          </div>
          <p class="card-text"></p>
          <div v-if="todoEntryState.done">
            <del>
              {{ todoEntryState.description }}
            </del>
          </div>
          <div v-else>
            {{ todoEntryState.description }}
          </div>
          <div class="d-flex justify-content-end">
            <button
              class="btn"
              :class="
                todoEntryState.done ? 'btn-outline-danger' : 'btn-success'
              "
              @click="handleDone"
            >
              {{ todoEntryState.done ? "Undo" : "Done" }}
            </button>
          </div>
        </div>
      </div>
    </div>
    <div v-if="editMode">
      <div class="card">
        <div class="card-body">
          <h5 class="card-title">
            <input
              type="text"
              class="form-control"
              v-model="todoEntryState.name"
              v-mode.lazy="todoEntryState.name"
              placeholder="Titel"
            />
          </h5>
          <div class="card-text mb-2">
            <textarea
              v-model="todoEntryState.description"
              v-mode.lazy="todoEntryState.description"
              class="form-control"
              style="resize: none"
              rows="4"
              placeholder="Beschreibung"
            />
          </div>
          <div class="d-flex justify-content-end">
            <input
              type="button"
              class="btn btn-success"
              value="Save"
              @click="handleSave"
            />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
