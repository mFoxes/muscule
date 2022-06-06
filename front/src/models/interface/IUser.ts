import { IRole } from "./IRole";

export interface IUser {
    id: number,

    name: string,
    password?: string,

    // TODO: Найти способ и исправить на new Date()
    // dateOfBirth: Date,
    dateOfBirth: string,
    phone: string,

    roleId?: number,
    role?: IRole,

    description?: string,
    directionId?: number

    //TODO: Разобраться с интерфейсами
    documents?: any,
    subscriptionUsers?: any,
    
    //TODO: Костыли
    CountOfWorkouts?: number 
}