import axios, { AxiosResponse } from "axios";
import { ITodo } from "../models/ITodo";

axios.defaults.baseURL = "https://localhost:44326/api";

const responseBody = <T> (response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody),
    post: <T> (url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T> (url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    delete: <T> (url: string) => axios.delete<T>(url).then(responseBody),
}

const Todos = {
    list: () => requests.get<ITodo[]>("/todo/list"),
    details: (id: string) => requests.get<ITodo>(`/todo/${id}`),
    create: (todo: ITodo) => requests.post<ITodo>("/todo", todo),
    update: (todo: ITodo) => requests.put<ITodo>("/todo", todo),
    delete: (id: string) => requests.delete<ITodo>(`/todo/${id}`)
}

const agent = {
    Todos
}

export default agent;

