import { IRole } from "./IRole";

export interface IUser {
    id: number,

    name: string,
    password?: string,

    dateOfBirth: Date,
    phone: string,

    roleId?: number,
    role?: IRole,

    description?: string,
    directionId?: number

    //TODO Разобраться с интерфейсами
    documents?: any,
    subscriptionUsers?: any,
}