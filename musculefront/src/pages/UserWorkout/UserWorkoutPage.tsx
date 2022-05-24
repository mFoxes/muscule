import { observer } from 'mobx-react-lite'
import React, { useContext, useEffect, useState } from 'react'
import { SmallCard } from '../../components/SmallCard/SmallCard'
import MyInput from '../../components/UI/input/MyInput'
import { IWorkout } from '../../models/interface/IWorkout'
import DatePicker from "react-datepicker"

import "./userWorkoutPage.scss"
import "react-datepicker/dist/react-datepicker.css";
import MyButton from '../../components/UI/button/MyButton'
import { Context } from '../..'
import WorkoutModal from '../../components/Modals/Workout/WorkoutModal'
import UserService from '../../services/UserService'
import { IDirection } from '../../models/interface/IDirection'

const UserWorkoutPage = () => {
    const { store } = useContext(Context)

    const [workoutData, setWorkoutData] = useState<IWorkout[]>([])

    const [nameValue, setNameValue] = useState<string>('')

    const [inputActive, setInputActive] = useState<boolean>(false)
    const [directionValue, setDirectionValue] = useState<string>('')

    const [dateRange, setDateRange] = useState<[Date | null, Date | null]>([null, null]);
    const [startDate, endDate] = dateRange;

    const [filteredData, setFilteredData] = useState<IWorkout[]>([])

    const [direction, setDirection] = useState<IDirection[]>([])

    const direction_filderedData = direction.filter(item => {
        return item.name.toLowerCase().includes(directionValue.toLowerCase())
    })

    useEffect(() => {
        UserService.getUserWorkout(store.User.id).then((data) => {
            setWorkoutData(data.data)
            setFilteredData(data.data)
        })

        UserService.getAllDirection().then((data) => {
            setDirection(data.data)
        })
    }, [])

    useEffect(() => {
        // Исправить хрень с Date() и допилить
        // setFilteredData(workoutData.filter(item => {
        //     if (startDate != null && endDate != null) {
        //         let temp_start = item.startTime.getFullYear() >= startDate.getFullYear() && item.startTime.getMonth() >= startDate.getMonth() + 1 && item.startTime.getDate() >= startDate.getDate()
        //         let temp_end = item.startTime.getFullYear() <= endDate.getFullYear() && item.startTime.getMonth() <= endDate.getMonth() + 1 && item.startTime.getDate() <= endDate.getDate()
        //         return item.name.toLowerCase().includes(nameValue.toLowerCase()) && item.direction?.name.toLowerCase().includes(directionValue.toLowerCase()) && temp_start && temp_end
        //     }
        //     return item.name.toLowerCase().includes(nameValue.toLowerCase()) && item.direction?.name.toLowerCase().includes(directionValue.toLowerCase())
        // }))

    }, [nameValue, directionValue, startDate, endDate])

    return (
        <>
            <div className="user-workout__sort">
                <div className='user-workout__field'>
                    <MyInput
                        type='text'
                        placeholder='Название'
                        value={nameValue}
                        onChange={(e) => setNameValue(e.currentTarget.value)} />
                    <div className='user-workout__direction'>
                        <MyInput
                            type='text'
                            placeholder='Направление'
                            value={directionValue}
                            onChange={(e) => setDirectionValue(e.currentTarget.value)}
                            onFocus={(e) => setInputActive(true)}
                            onBlur={(e) => setTimeout(() => setInputActive(false), 200)}
                        />

                        <ul className={`user-workout__list${inputActive ? ' _active' : ''}`}>
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
                    <DatePicker
                        selectsRange={true}
                        startDate={startDate}
                        endDate={endDate}
                        onChange={(update) => {
                            setDateRange(update);
                        }}
                        isClearable={true}
                        placeholderText="Время"
                    />
                </div>
                {store.User.role?.id != undefined && store.User.role?.id > 1 && <MyButton
                    onClick={() => {
                        store.setActiveWorkoutModal(true)
                    }}
                >
                    Добавить тренировку
                </MyButton>}
            </div>
            <div className="user-workout__data">
                {filteredData.map((data) => (
                    <SmallCard key={data.id + data.name} type="workout" workout_data={data} />
                ))}
            </div>
            <WorkoutModal />
        </>
    )
}

export default observer(UserWorkoutPage)