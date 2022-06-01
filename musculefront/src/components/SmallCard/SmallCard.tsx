import React, { FC, ReactElement, useContext, useState } from 'react'
import "./smallCard.scss"
import { IUser } from '../../models/interface/IUser'
import { IWorkout } from '../../models/interface/IWorkout'
import { Context } from '../..'
import { ICoachesWorkouts } from '../../models/interface/ICoachesWorkouts'

export const SmallCard: FC<{ coach_data?: IUser, workout_data?: IWorkout, type: string, workout_count?: number }> = ({ ...props }) => {
    const { store } = useContext(Context);

    return (
        <>
            {props.type == "coach" && props.coach_data
                ? <div className='small-card'>
                    <div className="small-card__title">
                        {props.coach_data.name}
                    </div>
                    <div className="small-card__description">
                        <div>Описание: </div>
                        <div>{props.coach_data.description}</div>
                    </div>
                    {store.User.id === 3 && <div className="small-card__">
                        <div>Кол-во занятий: {props.workout_count}</div>
                    </div>}
                </div>
                : props.workout_data && 
                <div className='small-card'>
                    <div className="small-card__title">
                        {props.workout_data.name}
                    </div>
                    <div className="small-card__hall">
                        {/* <div>Здание: {props.workout_data.buildingId}</div> */}
                        <div>Зал: {props.workout_data.hallId}</div>
                    </div>
                    <div className="small-card__coach">
                        {/* <div>Тренер:</div> */}
                        {/* <div>{props.workout_data.coach?.name}</div> */}
                    </div>
                    <div className="small-card__data">
                        <div>{props.workout_data.startTime.toString().split("T")[0]}</div>
                        <div>{props.workout_data.startTime.toString().split("T")[1].replace("Z","").split(".")[0]} - {props.workout_data.endTime.toString().split("T")[1].replace("Z","").split(".")[0]}</div>
                        {/* TODO: Исправить */}
                        {/* <div>{props.workout_data.startTime.getDate() < 10 ? "0" : ""}{props.workout_data.startTime.getDate()}/{props.workout_data.startTime.getMonth() < 10 ? "0" : ""}{props.workout_data.startTime.getMonth()}/{props.workout_data.startTime.getFullYear()}</div> */}
                        {/* <div>{props.workout_data.startTime.getHours()}:{props.workout_data.startTime.getMinutes() < 10 ? "0" : ""}{props.workout_data.startTime.getMinutes()}-{props.workout_data.endTime.getHours()}:{props.workout_data.endTime.getMinutes() < 10 ? "0" : ""}{props.workout_data.endTime.getMinutes()}</div> */}
                    </div>
                </div>}
        </>
    )
}
