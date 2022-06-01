import { IBuilding } from "./IBuilding";
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

    buildingId?: number,
    building?: IBuilding,

    startTime: Date,
    endTime: Date,

    coachId?: number,
    coach?: IUser,

    subscriptionId?: number,
    subscription?: ISubscription
}