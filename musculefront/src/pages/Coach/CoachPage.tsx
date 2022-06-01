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
            setCoachWorkoutsCountData(data.data)
        })
    }, [])

    return (
        <div className='coach-page__container'>
            {coachData.map((data) => (
                <SmallCard key={data.id + data.name} type="coach" coach_data={data} workout_count={coachWorkoutsCountData.filter(item => item.CoachId == data.id)[0].CountOfWorkouts}/>
            ))}
        </div>
    )
}

export default observer(CoachPage);