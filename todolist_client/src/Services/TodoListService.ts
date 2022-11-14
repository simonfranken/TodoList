import { axiosInstance } from "@/axiosConfig";
import type { TodoEntry } from "@/models";

export const getAllEntries = async (): Promise<TodoEntry[]> => {
  try {
    return (await axiosInstance.get("Todo")).data;
  } catch (e) {
    console.error(e);
    throw e;
  }
};

export const saveEntry = async (todoEntry: TodoEntry): Promise<TodoEntry> => {
  try {
    return (await axiosInstance.post("Todo", todoEntry)).data;
  } catch (e) {
    console.error(e);
    throw e;
  }
};

export const deleteEntry = async (entryId: string): Promise<TodoEntry> => {
  try {
    return await axiosInstance.delete("Todo", {
      params: {
        entryId: entryId,
      },
    });
  } catch (e) {
    console.error(e);
    throw e;
  }
};
