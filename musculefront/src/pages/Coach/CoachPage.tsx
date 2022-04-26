import { observer } from 'mobx-react-lite';
import React, { useEffect, useState } from 'react'
import { SmallCard } from '../../components/SmallCard/SmallCard';
import { ISubscription } from '../../models/interface/ISubscription';
import { IUser } from '../../models/interface/IUser';
import UserService from '../../services/UserService';

import "./coachPage.scss";

const CoachPage = () => {
    const [coachData, setCoachData] = useState<IUser[]>([])

    useEffect(() => {
        UserService.getAllCoach().then((data) => {
            setCoachData(data.data)
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