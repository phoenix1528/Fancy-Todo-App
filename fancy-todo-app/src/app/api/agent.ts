import axios, { AxiosResponse } from 'axios';
import { ITodo } from '../models/ITodo';

const sleep = (delay: number) => {
    return new Promise((resolve) => {
        setTimeout(resolve, delay);
    })
}

axios.defaults.baseURL = 'https://localhost:44326/api';

axios.interceptors.response.use(async response => {
    try {
        await sleep(1000);
        return response;
    } catch (error) {
        console.log(error);
        return await Promise.reject(error);
    }
})

const responseBody = <T> (response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody),
    post: <T> (url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T> (url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    delete: <T> (url: string) => axios.delete<T>(url).then(responseBody),
}

const Todos = {
    list: () => requests.get<ITodo[]>('/todo/list'),
    details: (id: string) => requests.get<ITodo>(`/todo/${id}`),
    create: (todo: ITodo) => requests.post<void>('/todo', todo),
    update: (todo: ITodo) => requests.put<void>(`/todo`, todo),
    delete: (id: string) => requests.delete<void>(`/todo/${id}`)
}

const agent = {
    Todos
}

export default agent;

