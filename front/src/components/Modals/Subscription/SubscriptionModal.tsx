import React, { FC, useContext, useEffect } from "react";

import styles from "./SubscriptionModal.module.scss";

import { Context } from "../../..";
import { observer } from "mobx-react-lite";
import MyButton from "../../UI/button/MyButton";
import { useForm } from "react-hook-form";
import MyInput from "../../UI/input/MyInput";
import UserService from "../../../services/UserService";

export interface ISubscriptionData {
    name: string,
    price: number,
    count: number
}

const SubscriptionModal: FC = () => {
    const { store } = useContext(Context);
    const { register, handleSubmit, formState: { errors } } = useForm<ISubscriptionData>();

    const onSubmit = (data: ISubscriptionData) => {
        UserService.addSubscription(data.name, data.price, data.count).then((data) => {
            console.log(data);
        })
        store.setActiveSubscriptionModal(false)
    };

    return (
        <div className={`${styles.modal} ${store.activeSubscriptionModal ? styles.modal__active : ""} `} onClick={() => store.setActiveSubscriptionModal(false)}>
            <form onSubmit={handleSubmit(onSubmit)} className={`${styles.modal__body} ${store.activeSubscriptionModal ? styles.body__active : ""} `} onClick={e => e.stopPropagation()}>
                <div className={`_icon-exit ${styles.exit}`} onClick={() => store.setActiveSubscriptionModal(false)} ></div>

                <div className={styles.modal__inpts}>
                    <MyInput type="text" placeholder='Название' register={register("name")} />
                    <MyInput type="text" placeholder='Цена' register={register("price")} />
                    <MyInput type="text" placeholder='Кол-во дней' register={register("count")} />
                </div>
                <MyButton>Вход</MyButton>
            </form>
        </div>
    );
}

export default observer(SubscriptionModal);