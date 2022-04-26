import { makeAutoObservable } from "mobx";
import AuthService from "../services/AuthService";
import axios from 'axios';
import { IUser } from "../models/interface/IUser";
import { IData } from "../components/Modals/Login/LoginModal";
import UserService from "../services/UserService";

export default class Store {
    isAuth: boolean = false;
    isLoading: boolean = false;
    User = <IUser>{};

    activeLoginModal: boolean = false;
    activeWorkoutModal: boolean = false;
    activeSubscriptionModal: boolean = false;
    activeWardsModal: boolean = false;

    wardsSubscribeId: number = 0;

    constructor() {
        makeAutoObservable(this);
    }

    setAuth(bool: boolean) {
        this.isAuth = bool;
    }

    setLoading(bool: boolean) {
        this.isLoading = bool;
    }

    setUser(user: IUser) {
        this.User = user;
    }

    setActiveLoginModal(bool: boolean) {
        this.activeLoginModal = bool;
    }

    setActiveWorkoutModal(bool: boolean) {
        this.activeWorkoutModal = bool;
    }

    setActiveSubscriptionModal(bool: boolean) {
        this.activeSubscriptionModal = bool;
    }

    setActiveWardsModal(bool: boolean) {
        this.activeWardsModal = bool;
    }

    setWardsSubscribeId(num: number) {
        this.wardsSubscribeId = num;
    }

    async login({ name, password }: IData) {
        try {
            // const response = await AuthService.login( name, password );
            // this.setUser(response.data)
            this.setUser({
                id: 1,
                name: "dsa",
                dateOfBirth: new Date(),
                phone: "dsa",
                role: {
                    id: 3,
                    name: "Админ",
                    description: "dsa"
                }
            })
            // console.log(response)
            this.setAuth(true);
            this.setActiveLoginModal(false)
        } catch (e: any) {
            console.log(e.response?.data?.message);
        }
    }

    async logout() {
        try {
            this.setAuth(false);
        } catch (e: any) {
            console.log(e.response?.data?.message);
        }
    }

}