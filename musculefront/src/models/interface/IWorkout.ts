import { IDirection } from "./IDirection";
import { IHall } from "./IHall";
import { ISubscription } from "./ISubscription";
import { IUser } from "./IUser";

export interface IWorkout {
    id: number,
    name: string,
    directionId?: number,
    direction?: IDirection,
    hallId?: number,
    hall?: IHall,
    // TODO: Найти способ и исправить на new Date()
    // startTime: Date,
    // endTime: Date,
    startTime: string,
    endTime: string,
    coachId?: number,
    coach?: IUser,
    subscriptionId?: number,
    subscription?: ISubscription
}