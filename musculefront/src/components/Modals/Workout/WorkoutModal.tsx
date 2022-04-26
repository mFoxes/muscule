import React, { FC, useContext, useEffect, useState } from "react";

import styles from "./WorkoutModal.module.scss";

import { Context } from "../../..";
import { observer } from "mobx-react-lite";
import MyButton from "../../UI/button/MyButton";
import { useForm } from "react-hook-form";
import MyInput from "../../UI/input/MyInput";

import DatePicker from "react-datepicker"
import "react-datepicker/dist/react-datepicker.css";
import UserService from "../../../services/UserService";

export interface IWorkoutData {
    name: string,
    directionId: number,
    hallId: number,
    startTime: Date | undefined,
    endTime: Date | undefined
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

    const onSubmit = (data: IWorkoutData) => {
        data.startTime = startDate
        data.endTime = endDate
        
        UserService.addWorkout(data.name, store.User.id, data.directionId, data.hallId, data.startTime, data.endTime).then((data) => {
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
                    <MyInput type="text" placeholder='Id направления' register={register("directionId")} />
                    <MyInput type="text" placeholder='Id зала' register={register("hallId")} />
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
