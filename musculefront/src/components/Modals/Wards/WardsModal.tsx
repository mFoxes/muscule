import React, { FC, useContext, useEffect, useState } from "react";

import styles from "./WardsModal.module.scss";

import { Context } from "../../..";
import { observer } from "mobx-react-lite";
import MyButton from "../../UI/button/MyButton";
import { useForm } from "react-hook-form";
import MyInput from "../../UI/input/MyInput";
import UserService from "../../../services/UserService";
import { IUser } from "../../../models/interface/IUser";
import { ISubscriptionToUser } from "../../../models/interface/ISubscriptionToUser";


const WardsModal: FC = () => {
    const { store } = useContext(Context);

    const [wards, setWards] = useState<ISubscriptionToUser[]>([])

    useEffect(() => {
        UserService.getWards(store.wardsSubscribeId).then((data) => {
            setWards(data.data)
            console.log(data);
        })
    }, [store.wardsSubscribeId])


    return (
        <div className={`${styles.modal} ${store.activeWardsModal ? styles.modal__active : ""} `} onClick={() => store.setActiveWardsModal(false)}>
            <div className={`${styles.modal__body} ${store.activeWardsModal ? styles.body__active : ""} `} onClick={e => e.stopPropagation()}>
                <div className={`_icon-exit ${styles.exit}`} onClick={() => store.setActiveWardsModal(false)} ></div>

                <div className={styles.modal__table}>
                    <div className={styles.table__th}>
                        <div className={`${styles.table__td} ${styles.table__id}`}>
                            ID
                        </div>
                        <div className={`${styles.table__td} ${styles.table__fio}`}>
                            Ф.И.О.
                        </div>
                        <div className={`${styles.table__td} ${styles.table__dob}`}>
                            Дата рождения
                        </div>
                        <div className={`${styles.table__td} ${styles.table__phone}`}>
                            Телефон
                        </div>
                        <div className={`${styles.table__td} ${styles.table__count}`}>
                            Кол-во занятий
                        </div>
                    </div>
                    <div className={styles.table__body}>
                        {wards.map((item) => (
                            <div className={styles.table__tr}>
                                <div className={`${styles.table__td} ${styles.table__id}`}>
                                    {item.userId}
                                </div>
                                <div className={`${styles.table__td} ${styles.table__fio}`}>
                                    {item.user?.name}
                                </div>
                                <div className={`${styles.table__td} ${styles.table__dob}`}>
                                    {item.user?.dateOfBirth.getDate()}/{item.user?.dateOfBirth.getMonth()}/{item.user?.dateOfBirth.getFullYear()}
                                </div>
                                <div className={`${styles.table__td} ${styles.table__phone}`}>
                                    {item.user?.phone}
                                </div>
                                <div className={`${styles.table__td} ${styles.table__count}`}>
                                    {item.visitCount}
                                </div>
                            </div>
                        ))}
                    </div>
                </div>
            </div>
        </div>
    );
}

export default observer(WardsModal);