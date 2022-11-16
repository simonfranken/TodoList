<script setup lang="ts">
import type { TodoEntry } from "@/models";
import { reactive, ref, watch } from "vue";

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

const state = reactive<{
  todoEntry: TodoEntry;
  editMode: {
    title: boolean;
    description: boolean;
  };
}>({
  todoEntry: props.todoEntry,
  editMode: {
    title: props.editModeDefault,
    description: props.editModeDefault,
  },
});

const inputTitle = ref<any>(null);
const inputDescription = ref<any>(null);

const events = defineEmits<{
  (e: "onSave", todoEntry: TodoEntry): void;
  (e: "onDelete", todoEntry: TodoEntry): void;
}>();

const handleDone = () => {
  state.todoEntry.done = state.todoEntry.done ? false : true;
  events("onSave", state.todoEntry);
};

const handleSave = () => {
  events("onSave", state.todoEntry);
};

const handleDelete = () => {
  events("onDelete", state.todoEntry);
};

const handleEditMode = (e: any) => {
  switch (e.target.id) {
    case "title":
      state.editMode.title = true;
      break;
    case "description":
      state.editMode.description = true;
      break;
    default:
      state.editMode = { title: true, description: true };
      break;
  }
};

watch(inputTitle, () => {
  if (state.editMode.title) {
    inputTitle.value.focus();
  }
});

watch(inputDescription, () => {
  if (state.editMode.description && !state.editMode.title) {
    inputDescription.value.focus();
  }
});
</script>
<template>
  <div class="mb-3">
    <div>
      <div class="card">
        <div class="card-body">
          <div>
            <div v-if="!state.editMode.title" class="card-title row">
              <h5 class="col">
                <div
                  id="title"
                  :class="
                    state.todoEntry.done ? 'text-decoration-line-through' : ''
                  "
                  @click="handleEditMode"
                >
                  {{ state.todoEntry.name }}
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
                    <button class="dropdown-item" @click="handleEditMode">
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
            <div v-else>
              <h5 class="card-title">
                <input
                  ref="inputTitle"
                  type="text"
                  class="form-control"
                  v-model="state.todoEntry.name"
                  placeholder="Titel"
                />
              </h5>
            </div>
          </div>
          <div class="mb-3">
            <div
              id="description"
              v-if="!state.editMode.description"
              :class="
                state.todoEntry.done ? 'text-decoration-line-through' : ''
              "
              @click="handleEditMode"
            >
              {{ state.todoEntry.description }}
            </div>
            <div v-else>
              <textarea
                ref="inputDescription"
                class="form-control"
                style="resize: none"
                placeholder="Beschreibung"
                v-model="state.todoEntry.description"
              />
            </div>
          </div>
          <div class="d-flex justify-content-end">
            <button
              v-if="!state.editMode.title && !state.editMode.description"
              class="btn"
              :class="
                state.todoEntry.done ? 'btn-outline-danger' : 'btn-success'
              "
              @click="handleDone"
            >
              {{ state.todoEntry.done ? "Undo" : "Done" }}
            </button>
            <button
              v-else
              class="btn btn-success"
              @click="
                () => {
                  state.editMode = {
                    title: false,
                    description: false,
                  };
                  handleSave();
                }
              "
            >
              Save
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
