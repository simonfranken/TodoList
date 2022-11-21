import axios from "axios";

const protectedResources = {
  TodoListAPI: {
    endpoint: import.meta.env.VITE_API_ENDPOINT || "",
  },
};
export const axiosInstance = axios.create({
  baseURL: protectedResources.TodoListAPI.endpoint,
});
