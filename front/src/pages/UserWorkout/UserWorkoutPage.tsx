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
import { IBuilding } from '../../models/interface/IBuilding'

const UserWorkoutPage = () => {
    const { store } = useContext(Context)

    const [weekWorkoutData, setWeekWorkoutData] = useState<IWorkout[]>([])
    const [tempWorkoutData, setTempWorkoutData] = useState<IWorkout[]>([])
    const [workoutData, setWorkoutData] = useState<IWorkout[]>([])
    const [filteredData, setFilteredData] = useState<IWorkout[]>([])

    const [nameValue, setNameValue] = useState<string>('')

    const [inputActive, setInputActive] = useState<boolean>(false)
    const [directionValue, setDirectionValue] = useState<string>('')

    const [dateRange, setDateRange] = useState<[Date | null, Date | null]>([null, null]);
    const [startDate, endDate] = dateRange;

    const [direction, setDirection] = useState<IDirection[]>([])

    const direction_filderedData = direction.filter(item => {
        return item.name.toLowerCase().includes(directionValue.toLowerCase())
    })
    
    const [weekActive, setWeekActive] = useState<boolean>(false)

    const [equipment, setEquipment] = useState<IBuilding[]>([])

    useEffect(() => {
        setFilteredData(workoutData.filter(item => {

            let temp_name = item.name != undefined ? item.name.toLowerCase().includes(nameValue.toLowerCase()) : true
            let temp_dirname = item.direction?.name != undefined ? item.direction?.name.toLowerCase().includes(directionValue.toLowerCase()) : true

            if (startDate != null && endDate != null) {
                let startTime = new Date(item.startTime)
                let endTime = new Date(item.endTime)

                return temp_name && temp_dirname && startTime >= startDate && endTime <= endDate
            }
            return temp_name && temp_dirname
        }))

    }, [nameValue, directionValue, startDate, endDate])

    useEffect(() => {
        UserService.getUserWorkout(store.User.id).then((data) => {
            setWorkoutData(data.data)
            setFilteredData(data.data)
            setTempWorkoutData(data.data)
        })

        UserService.getAllDirection().then((data) => {
            setDirection(data.data)
        })

        UserService.getAllEquipment().then((data) => {
            setEquipment(data.data)
        })

        UserService.getNumberOfUserWorkoutsPerWeek(store.User.id).then((data) => {
            setWeekWorkoutData(data.data)
        })
    }, [])

    useEffect(() => {
        if (weekActive) {
            setWorkoutData(weekWorkoutData)
            setFilteredData(weekWorkoutData)
        } else {
            setWorkoutData(tempWorkoutData)
            setFilteredData(tempWorkoutData)
        }
    }, [weekActive])

    return (
        <>
            <div className="user-workout__sort">
                <div className='user-workout__field'>
                    <MyInput
                        type='text'
                        placeholder='????????????????'
                        value={nameValue}
                        onChange={(e) => setNameValue(e.currentTarget.value)} />
                    <div className='user-workout__direction'>
                        <MyInput
                            type='text'
                            placeholder='??????????????????????'
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
                        placeholderText="??????????"
                    />
                </div>
                {store.User.role?.id != undefined && store.User.role?.id == 1
                    ? <MyButton
                        onClick={() => {
                            setWeekActive(!weekActive);
                        }}
                    >
                        ???????????????? ???????????????????? ?? ????????????
                    </MyButton>
                    : <MyButton
                        onClick={() => {
                            store.setActiveWorkoutModal(true)
                        }}
                    >
                        ???????????????? ????????????????????
                    </MyButton>
                }

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