import React, { FC, useContext, useEffect, useState } from "react";

import styles from "./WorkoutModal.module.scss";
import "./workoutModal.scss";

import { Context } from "../../..";
import { observer } from "mobx-react-lite";
import MyButton from "../../UI/button/MyButton";
import { useForm } from "react-hook-form";
import MyInput from "../../UI/input/MyInput";

import DatePicker from "react-datepicker"
import "react-datepicker/dist/react-datepicker.css";
import UserService from "../../../services/UserService";
import { IDirection } from "../../../models/interface/IDirection";
import { ISubscription } from "../../../models/interface/ISubscription";
import { IEquipment } from "../../../models/interface/IEquipment";
import { IBuilding } from "../../../models/interface/IBuilding";
import { IHall } from "../../../models/interface/IHall";

export interface IWorkoutData {
    name: string,
    directionId: number,
    hallId: number,
    startTime: Date | undefined,
    endTime: Date | undefined,
    subscriptionId: number
}

const WorkoutModal: FC = () => {
    const { store } = useContext(Context);

    const [startDate, setStartDate] = useState(new Date());
    const [endDate, setEndDate] = useState(new Date());

    const { register, handleSubmit, formState: { errors } } = useForm<IWorkoutData>({
        defaultValues: {
            startTime: startDate,
            endTime: endDate
        }
    });

    // ----------------------------------

    const [directionInputActive, setDirectionInputActive] = useState<boolean>(false)
    const [directionValue, setDirectionValue] = useState<string>('')
    const [direction, setDirection] = useState<IDirection[]>([])

    const direction_filderedData = direction.filter(item => {
        return item.name.toLowerCase().includes(directionValue.toLowerCase())
    })

    // ----------------------------------

    const [subscriptionInputActive, setSubscriptionInputActive] = useState<boolean>(false)
    const [subscriptionValue, setSubscriptionValue] = useState<string>('')
    const [subscription, setSubscription] = useState<ISubscription[]>([])

    const subscription_filderedData = subscription.filter(item => {
        return item.name.toLowerCase().includes(subscriptionValue.toLowerCase())
    })

    // ----------------------------------

    const [hallInputActive, setHallInputActive] = useState<boolean>(false)
    const [hallValue, setHallValue] = useState<string>('')
    const [hall, setHall] = useState<IHall[]>([])

    const hall_filderedData = hall.filter(item => {
        return item.name.toLowerCase().includes(hallValue.toLowerCase())
    })

    // ----------------------------------

    useEffect(() => {
        UserService.getAllDirection().then((data) => {
            setDirection(data.data)
        })

        UserService.getAllSubscription().then((data) => {
            setSubscription(data.data)
        })

        UserService.getAllEquipment().then((data) => {
            data.data.forEach(items => {
                items.halls.forEach(item => {
                    setHall(oldArray => [...oldArray, {
                        id: item.id,
                        name: item.name,
                        directions: item.directions
                    }])
                });
            });
        })
    }, [])

    const onSubmit = (data: IWorkoutData) => {
        data.startTime = startDate
        data.endTime = endDate
        
        // direction
        direction.forEach((item) => {
            if (item.name == directionValue) {
                data.directionId = item.id
            }
        })
        // subscription
        subscription.forEach((item) => {
            if (item.name == subscriptionValue) {
                data.subscriptionId = item.id
            }
        })
        // hall
        hall.forEach((item) => {
            if (item.name == hallValue) {
                data.hallId = item.id
            }
        })

        UserService.addWorkout(data.name, store.User.id, data.directionId, data.hallId, data.startTime, data.endTime, data.subscriptionId).then((data) => {
            console.log(data);
        })

        console.log(data);
        
        store.setActiveWorkoutModal(false)
    };


    return (
        <div className={`${styles.modal} ${store.activeWorkoutModal ? styles.modal__active : ""} `} onClick={() => store.setActiveWorkoutModal(false)}>
            <form onSubmit={handleSubmit(onSubmit)} className={`${styles.modal__body} ${store.activeWorkoutModal ? styles.body__active : ""} `} onClick={e => e.stopPropagation()}>
                <div className={`_icon-exit ${styles.exit}`} onClick={() => store.setActiveWorkoutModal(false)} ></div>

                <div className={styles.modal__inpts}>
                    <MyInput type="text" placeholder='Название' register={register("name")} />
                    {/* Направление */}
                    <div className={styles.modal__inputlist}>
                        <MyInput
                            type='text'
                            placeholder='Направление'
                            value={directionValue}
                            onChange={(e) => setDirectionValue(e.currentTarget.value)}
                            onFocus={(e) => setDirectionInputActive(true)}
                            onBlur={(e) => setTimeout(() => setDirectionInputActive(false), 200)}
                            // register={register("direction")}
                        />

                        <ul className={`${styles.modal__list}${directionInputActive ? ' _active' : ''}`}>
                            {direction_filderedData.slice(0, 50).map((item, index) => (
                                <li
                                    key={item.id + item.name}
                                    onClick={(e) => {
                                        setDirectionValue(e.currentTarget.innerHTML)
                                    }}
                                >
                                    {item.name}
                                </li>
                            ))}
                        </ul>
                    </div>
                    {/*  */}
                    {/* Сертификат */}
                    <div className={styles.modal__inputlist}>
                        <MyInput
                            type='text'
                            placeholder='Зал'
                            value={hallValue}
                            onChange={(e) => setHallValue(e.currentTarget.value)}
                            onFocus={(e) => setHallInputActive(true)}
                            onBlur={(e) => setTimeout(() => setHallInputActive(false), 200)}
                            // register={register("hall")}
                        />

                        <ul className={`${styles.modal__list}${hallInputActive ? ' _active' : ''}`}>
                            {hall_filderedData.slice(0, 50).map((item, index) => (
                                <li
                                    key={item.id + item.name}
                                    onClick={(e) => {
                                        setHallValue(e.currentTarget.innerHTML)
                                    }}
                                >
                                    {item.name}
                                </li>
                            ))}
                        </ul>
                    </div>
                    {/*  */}
                    {/* Сертификат */}
                    <div className={styles.modal__inputlist}>
                        <MyInput
                            type='text'
                            placeholder='Сертификат'
                            value={subscriptionValue}
                            onChange={(e) => setSubscriptionValue(e.currentTarget.value)}
                            onFocus={(e) => setSubscriptionInputActive(true)}
                            onBlur={(e) => setTimeout(() => setSubscriptionInputActive(false), 200)}
                            // register={register("subscription")}
                        />

                        <ul className={`${styles.modal__list}${subscriptionInputActive ? ' _active' : ''}`}>
                            {subscription_filderedData.slice(0, 50).map((item, index) => (
                                <li
                                    key={item.id + item.name}
                                    onClick={(e) => {
                                        setSubscriptionValue(e.currentTarget.innerHTML)
                                    }}
                                >
                                    {item.name}
                                </li>
                            ))}
                        </ul>
                    </div>
                    {/*  */}
                    
                    <DatePicker
                        selected={startDate}
                        onChange={(date: Date) => setStartDate(date)}
                        timeInputLabel="Time:"
                        placeholderText="Время начала занятия"
                        dateFormat="MM/dd/yyyy h:mm aa"
                        showTimeInput
                    />
                    <DatePicker
                        selected={endDate}
                        onChange={(date: Date) => setEndDate(date)}
                        timeInputLabel="Time:"
                        placeholderText="Время конца занятия"
                        dateFormat="MM/dd/yyyy h:mm aa"
                        showTimeInput
                    />
                </div>
                <MyButton>Добавить</MyButton>
            </form>
        </div>
    );
}

export default observer(WorkoutModal);
