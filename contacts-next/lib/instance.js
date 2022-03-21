import axios from "axios";

const instance = axios.create({
    baseURL: "http://localhost:5042/api/",
    browserBaseURL: "http://localhost:5042/api/",
    withCredentials: false
});

instance.defaults.headers.post['Content-Type'] = 'application/json';
instance.defaults.headers.put['Content-Type'] = 'application/json';
instance.defaults.headers.patch['Content-Type'] = 'application/json';

export default instance;