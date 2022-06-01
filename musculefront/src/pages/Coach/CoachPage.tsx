import { observer } from 'mobx-react-lite';
import React, { useEffect, useState } from 'react'
import { SmallCard } from '../../components/SmallCard/SmallCard';
import { ICoachesWorkouts } from '../../models/interface/ICoachesWorkouts';
import { ISubscription } from '../../models/interface/ISubscription';
import { IUser } from '../../models/interface/IUser';
import UserService from '../../services/UserService';

import "./coachPage.scss";

const CoachPage = () => {
    const [coachData, setCoachData] = useState<IUser[]>([])
    const [coachWorkoutsCountData, setCoachWorkoutsCountData] = useState<ICoachesWorkouts[]>([])

    useEffect(() => {
        UserService.getAllCoach().then((data) => {
            setCoachData(data.data)
        })

        UserService.getCoachesWorkoutsCount().then((data) => {
            data.data.shift()
            let temp: IUser[] = [] 
            if (coachData.length === data.data.length) {
                for (let i = 0; i < data.data.length; i++) {
                    if (coachData[i].id == data.data[i].CoachId) {
                        temp.push(coachData[i])
                        temp[i].CountOfWorkouts = data.data[i].CountOfWorkouts
                    }
                }
                setCoachData(temp)
            }
        })
    }, [])

    return (
        <div className='coach-page__container'>
            {coachData.map((data) => (
                <SmallCard key={data.id + data.name} type="coach" coach_data={data} />
            ))}
        </div>
    )
}

export default observer(CoachPage);