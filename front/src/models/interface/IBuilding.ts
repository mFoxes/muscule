import { IHall } from "./IHall"

export interface IBuilding {
    id: number,
    name: string,

    directions?: string,

    halls: IHall[]
}