import { IUser } from "./IUser";

export interface ISubscription {
    id: number,
    name: string,
    price: string,
    count: number,
    subscriptionsUser?: IUser[]
}