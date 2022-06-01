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
    const [active, setActive] = useState<boolean>(false)

    useEffect(() => {
        setActive(false)
        UserService.getAllCoach().then((data_coach) => {
            setCoachData(data_coach.data)

            UserService.getCoachesWorkoutsCount().then((data) => {
            data.data.shift()
            let temp: IUser[] = []
            for (let i = 0; i < data.data.length; i++) {
                console.log(data.data[i].CountOfWorkouts)
                temp.push({
                    id: coachData[i].id,

                    name: coachData[i].name,

                    dateOfBirth: coachData[i].dateOfBirth,
                    phone: coachData[i].phone,

                    roleId: coachData[i].roleId,

                    description: coachData[i].description,
                    directionId: coachData[i].directionId,
                    CountOfWorkouts: data.data[i].CountOfWorkouts
                })
            }
            setCoachData(temp)
            setActive(true)
        })
        })

        
    }, [])

    return (
        <div className='coach-page__container'>
            {active && coachData.map((data) => (
                <SmallCard key={data.id + data.name} type="coach" coach_data={data} />
            ))}
        </div>
    )
}

export default observer(CoachPage);