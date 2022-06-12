import { history } from '../..';
import isDev from '../../environment';
import { toast } from 'react-toastify';
import Axios, { AxiosResponse } from "axios";
import { routes } from '../Containers/Route/routeConstants';
import { transformUrl } from '../utils/routeHelper/routeHelper';

Axios.defaults.baseURL = 'https://localhost:5001/api';
Axios.interceptors.response.use(undefined, error => {
    if (error.message.toLowerCase() === 'Network Error'.toLowerCase() && !error.response) {
        toast.error('Network Error - start your API project');
    }
    if (error.response.status === 404) {
        history.push(routes.notFound);
    }
});

abstract class ServiceBase {
    public baseUrl: string;
    public endpoint: string;

    constructor() {
        this.endpoint = '';
        this.baseUrl = Axios.defaults.baseURL!;
    }

    responseBody = (response: AxiosResponse) => response.data;

    sleep = (ms: number) => (response: AxiosResponse) =>
        new Promise<AxiosResponse>(resolve =>
            isDev()
                ? setTimeout(() => resolve(response), ms)
                : resolve(response)
        );

    get = (stringReplacers?: object) => {
        if (stringReplacers) {
            this.endpoint = transformUrl(this.endpoint, stringReplacers);
        }
        return Axios.get(`${this.baseUrl}${this.endpoint}`)
            .then(this.sleep(1000))
            .then(this.responseBody);
    };
    delete = (stringReplacers?: object) => {
        if (stringReplacers) {
            this.endpoint = transformUrl(this.endpoint, stringReplacers);
        }
        return Axios.delete(`${this.baseUrl}${this.endpoint}`)
            .then(this.sleep(1000))
            .then(this.responseBody);
    };
    put = (stringReplacers?: object, body?: {}) => {
        if (stringReplacers) {
            this.endpoint = transformUrl(this.endpoint, stringReplacers);
        }
        return Axios.put(`${this.baseUrl}${this.endpoint}`, body)
            .then(this.sleep(1000))
            .then(this.responseBody);
    }

    post = (stringReplacers?: object, body?: {}) => {
        if (stringReplacers) {
            this.endpoint = transformUrl(this.endpoint, stringReplacers);
        }
        return Axios.post(`${this.baseUrl}${this.endpoint}`, body)
            .then(this.sleep(1000))
            .then(this.responseBody);
    }
}

export default ServiceBase;
