import { ISubscription } from "./ISubscription"
import { IUser } from "./IUser"

export interface ISubscriptionToUser {
    subscriptionId: number,
    subscription?: ISubscription,
    userId: number,
    user?: IUser,
    visitCount: number
}