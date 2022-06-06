import { AxiosResponse } from "axios";
import $api from "../http";
import { IUser } from "../models/interface/IUser";

export default class AuthService {
    static async login(name: string, password: string): Promise<AxiosResponse<IUser>> {
        return $api.post<IUser>('/User/LogIn', { name, password })
    }
}