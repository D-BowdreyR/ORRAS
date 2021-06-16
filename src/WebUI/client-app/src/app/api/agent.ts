import { message } from 'antd';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { history } from '../..';
import { UserFormValues } from '../models/user';
import { store } from '../stores/store';

const sleep = (delay: number) => {
    return new Promise((resolve) => {
        setTimeout(resolve, delay)
    })
}
axios.defaults.baseURL = process.env.REACT_APP_API_URL;

// send bearer token with every client request
axios.interceptors.request.use(config => {
    const token = store.commonStore.token;
    if (token) config.headers.Authorization = `Bearer ${token}`;
    return config;
})

// provides a delay to the response to support the indicating of loading
axios.interceptors.response.use(async response => {
        if(process.env.NODE_ENV === 'development') await sleep(1000);
        return response;
}, (error: AxiosError) => {
    const { data, status, config } = error.response!;
    switch (status) {
        case 400:
            if (typeof data === 'string'){
                message.error(data)
            }
            if (config.method === 'get' && data.errors.hasOwnProperty('id')) {
                history.push('/not-found')
            }
            if (data.errors) {
                const modelStateErrors = []
                for (const key in data.errors) {
                    if (data.errors[key]) {
                        modelStateErrors.push(data.errors[key])
                    }
                }
                throw modelStateErrors.flat();
            }
            break;
        case 401:
            message.error("unauthorised");
            break;
        case 404:
            history.push('/not-found');
            break;
        case 500:
            store.commonStore.setServerError(data)
            history.push('/server-error')
            break;
    }
    return Promise.reject(error);
})

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
    get: (url: string) => axios.get(url).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
    put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
    del: (url: string) => axios.delete(url).then(responseBody),
}

// http methods for each resource go here

const Studies = {
    list: () => requests.get('/studies'),
    details: (id: string) => requests.get(`/studies/${id}`)
}

// http methods for account endpoint
const Account = {
    current: () => requests.get('/account'),
    login: (user: UserFormValues) => requests.post('/account/login', user),
    register: (user: UserFormValues) => requests.post('/account/register', user)
}

// register methods with agent
const agent = {
    Studies,
    Account
}

export default agent;