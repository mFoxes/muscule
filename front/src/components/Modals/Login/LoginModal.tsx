import React, { FC, useContext, useEffect } from "react";

import styles from "./LoginModal.module.scss";

import { Context } from "../../..";
import { observer } from "mobx-react-lite";
import MyButton from "../../UI/button/MyButton";
import { useForm } from "react-hook-form";
import MyInput from "../../UI/input/MyInput";

export interface IData {
    name: string,
    password: string
}

const LoginModal: FC = () => {
    const { store } = useContext(Context);
    const { register, handleSubmit, formState: { errors } } = useForm<IData>();

    const onSubmit = (data: IData) => {
        console.log(data);
        store.login(data);
    };

    return (
        <div className={`${styles.modal} ${store.activeLoginModal ? styles.modal__active : ""} `} onClick={() => store.setActiveLoginModal(false)}>
            <form onSubmit={handleSubmit(onSubmit)} className={`${styles.modal__body} ${store.activeLoginModal ? styles.body__active : ""} `} onClick={e => e.stopPropagation()}>
                <div className={`_icon-exit ${styles.exit}`} onClick={() => store.setActiveLoginModal(false)} ></div>

                <div className={styles.modal__inpts}>
                    <MyInput type="text" placeholder='Логин' register={register("name")} />
                    <MyInput type="password" placeholder='Пароль' register={register("password")} />
                </div>
                <MyButton>Вход</MyButton>
            </form>
        </div>
    );
}

export default observer(LoginModal);