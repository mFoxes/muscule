import { IBuilding } from "./IBuilding";
import { IHall } from "./IHall";

export interface IDirection {
    id: number,
    name: string,

    buildingId?: number,
    building?: IBuilding,

    halls?: IHall[],

    description: string
}