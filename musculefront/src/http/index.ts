import axios from "axios";

const $api = axios.create({
    baseURL: "http://localhost:44323/api"
})

export default $api;