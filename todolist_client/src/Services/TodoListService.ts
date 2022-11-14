import { axiosInstance } from "@/axiosConfig";
import type { TodoEntry } from "@/models";

export const getAllEntries = async (): Promise<TodoEntry[]> => {
  try {
    return (await axiosInstance.get("Todo/GetAllEntries")).data;
  } catch (e) {
    console.error(e);
    throw e;
  }
};

export const saveEntry = async (todoEntry: TodoEntry): Promise<TodoEntry> => {
  try {
    return (await axiosInstance.post("Todo/SaveEntry", todoEntry)).data;
  } catch (e) {
    console.error(e);
    throw e;
  }
};

export const deleteEntry = async (entryId: string): Promise<TodoEntry> => {
  try {
    return await axiosInstance.delete("Todo/DeleteEntry", {
      params: {
        entryId: entryId,
      },
    });
  } catch (e) {
    console.error(e);
    throw e;
  }
};
