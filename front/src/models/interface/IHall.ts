import { IBuilding } from "./IBuilding";
import { IEquipmentToHall } from "./IEquipmentToHall";

export interface IHall {
    id: number,
    name: string,
    buildingId?: number,
    building?: IBuilding,

    equipmentHalls?: IEquipmentToHall[],

    directions: string
}