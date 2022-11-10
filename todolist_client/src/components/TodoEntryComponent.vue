<script lang="ts" setup>
import { TodoEntry } from "@/models";
import { defineEmits, defineProps, reactive, ref, watch } from "vue";
const props = defineProps({
  todoEntry: {
    type: Object as () => TodoEntry,
    required: true,
  },
  overlineText: {
    type: String,
    default: "TODO",
  },
});

const emit = defineEmits(["entryChanged"]);

const todoEntryState = reactive<TodoEntry>(props.todoEntry);

watch(todoEntryState, () => emit("entryChanged", todoEntryState));

const handleToggleDone = () => {
  todoEntryState.Done = todoEntryState.Done ? false : true;
};
</script>
<template>
  <v-card
    class="mx-auto"
    max-width="344"
    :variant="todoEntryState.Done ? 'outlined' : 'elevated'"
  >
    <v-card-item>
      <div>
        <div
          class="text-overline mb-1"
          :class="todoEntryState.Done ? 'text-decoration-line-through' : ''"
        >
          {{ props.overlineText }}
        </div>
        <div
          class="text-h6 mb-1"
          :class="todoEntryState.Done ? 'text-decoration-line-through' : ''"
        >
          {{ todoEntryState.Name }}
        </div>
        <div
          class="text-caption"
          :class="todoEntryState.Done ? 'text-decoration-line-through' : ''"
        >
          {{ todoEntryState.Desciption }}
        </div>
      </div>
    </v-card-item>

    <v-card-actions>
      <v-btn
        v-if="todoEntryState.Done"
        variant="elevated"
        @click="handleToggleDone"
      >
        Undo
      </v-btn>
      <v-btn v-else variant="outlined" @click="handleToggleDone" color="green">
        Done
      </v-btn>
    </v-card-actions>
  </v-card>
</template>
