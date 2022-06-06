import { IEquipment } from "./IEquipment";
import { IHall } from "./IHall";

export interface IEquipmentToHall {
    equipmentId: number,
    equipment?: IEquipment,

    hallId: number,
    hall?: IHall,

    quantity: number
}