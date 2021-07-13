import axios, { AxiosResponse } from 'axios';
import { ITodo } from '../models/ITodo';

axios.defaults.baseURL = 'https://localhost:44326/api';

axios.interceptors.response.use(async response => {
    try {
        return response;
    } catch (error) {
        console.log(error);
        return await Promise.reject(error);
    }
})

const responseBody = <T> (response: AxiosResponse<T>) => response.data;

function parseDateStringsToDate(todos: ITodo[]) {
    let result : ITodo[] = todos.map((todo:ITodo) => {
        return {
            ...todo,
            startDate: new Date(todo.startDate),
            endDate: new Date(todo.endDate)
        }
    });
    return result;
};

function parseDateStringToDate(todo: ITodo) {
        return {
            ...todo,
            startDate: new Date(todo.startDate),
            endDate: new Date(todo.endDate)
        }
};

const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody),
    post: <T> (url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T> (url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    delete: <T> (url: string) => axios.delete<T>(url).then(responseBody),
}

const Todos = {
    list: () => requests.get<ITodo[]>('/todo/list').then(parseDateStringsToDate),
    details: (id: string) => requests.get<ITodo>(`/todo/${id}`).then(parseDateStringToDate),
    create: (todo: ITodo) => requests.post<void>('/todo', todo),
    update: (todo: ITodo) => requests.put<void>(`/todo`, todo),
    delete: (id: string) => requests.delete<void>(`/todo/${id}`)
}

const agent = {
    Todos
}

export default agent;

