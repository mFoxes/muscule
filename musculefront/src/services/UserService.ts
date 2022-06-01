import { Axios, AxiosResponse } from "axios";
import $api from "../http";
import { IBuilding } from "../models/interface/IBuilding";
import { IDirection } from "../models/interface/IDirection";
import { IEquipmentToHall } from "../models/interface/IEquipmentToHall";
import { ISubscription } from "../models/interface/ISubscription";
import { ISubscriptionToUser } from "../models/interface/ISubscriptionToUser";
import { IUser } from "../models/interface/IUser";
import { IWorkout } from "../models/interface/IWorkout";

export default class UserService {
    static async getAllSubscription(): Promise<AxiosResponse<ISubscription[]>> {
        return $api.get<ISubscription[]>('/Subscription/GetAllSubscriptions')
    }

    static async buySubscription(subscriptionId: number, userId: number): Promise<AxiosResponse<any>> {
        return $api.post<any>('/SubscriptionUser/AddSubscriptionUser', { subscriptionId, userId })
    }

    static async getAllCoach(): Promise<AxiosResponse<IUser[]>> {
        return $api.get<IUser[]>('/Coach/GetAllCoaches')
    }

    static async getUserWorkout(userId: number): Promise<AxiosResponse<IWorkout[]>> {
        return $api.get<IWorkout[]>('/User/GetUsersWorkouts?userId=' + userId)
    }

    static async addWorkout(name: string, coachId: number, directionId: number, hallId: number, startTime: Date, endTime: Date): Promise<AxiosResponse<any>> {
        return $api.post<any>('/Workout', { name, coachId, directionId, hallId, startTime, endTime })
    }

    static async getUserSubscription(userId: number): Promise<AxiosResponse<ISubscriptionToUser[]>> {
        return $api.get<ISubscriptionToUser[]>('/User/GetUsersSubscriptions?userId=' + userId)
    }

    static async addSubscription(name: string, price: number, count: number): Promise<AxiosResponse<any>> {
        return $api.post<any>('/Subscription/AddSubscription', { name, price, count })
    }

    static async getWards(subscriptionId: number): Promise<AxiosResponse<ISubscriptionToUser[]>> {
        return $api.get<ISubscriptionToUser[]>('/Subscription/GetSubscriptions\'s users?id=' + subscriptionId)
    }

    static async getAllEquipment(): Promise<AxiosResponse<IBuilding[]>> {
        return $api.get<IBuilding[]>('/Building/GetAllBuildingsWithHallAndEquipments')
    }

    static async getAllDirection(): Promise<AxiosResponse<IDirection[]>> {
        return $api.get<IDirection[]>('/Direction/GetAllDirections')
    }
}