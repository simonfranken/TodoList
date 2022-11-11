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

const events = defineEmits<{
  (e: "onChange", todoEntry: TodoEntry): void;
}>();

const todoEntryState = reactive<TodoEntry>(props.todoEntry);

const editMode = ref<boolean>(props.editModeDefault);

const onDone = () => {
  todoEntryState.done = todoEntryState.done ? false : true;
};

watch(todoEntryState, () => {
  events("onChange", todoEntryState);
});
</script>
<template>
  <div class="container">
    <div class="" v-if="!editMode">
      <div class="card">
        <div class="card-body">
          <h5 class="card-title">
            <div v-if="todoEntryState.done">
              <del>{{ todoEntryState.name }}</del>
            </div>
            <div v-else>
              {{ todoEntryState.name }}
            </div>
          </h5>
          <p class="card-text"></p>
          <div v-if="todoEntryState.done">
            <del>
              {{ todoEntryState.description }}
            </del>
          </div>
          <div v-else>
            {{ todoEntryState.description }}
          </div>
          <div />
        </div>
        <div class="card-footer d-flex justify-content-between">
          <button class="btn btn-warning" @click="() => (editMode = true)">
            Edit
          </button>
          <button
            class="btn"
            :class="todoEntryState.done ? 'btn-outline-danger' : 'btn-success'"
            @click="onDone"
          >
            {{ todoEntryState.done ? "Undo" : "Done" }}
          </button>
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
            />
          </h5>
          <div class="card-text">
            <textarea
              v-model="todoEntryState.description"
              v-mode.lazy="todoEntryState.description"
              class="form-control"
              style="resize: none"
              rows="4"
            />
          </div>
          <div />
        </div>
        <div class="card-footer d-flex justify-content-end">
          <input
            type="button"
            class="btn btn-success"
            value="Save"
            @click="() => (editMode = false)"
          />
        </div>
      </div>
    </div>
  </div>
</template>
