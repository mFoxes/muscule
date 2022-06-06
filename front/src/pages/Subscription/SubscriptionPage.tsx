import { observer } from 'mobx-react-lite'
import React, { useEffect, useState } from 'react'
import LargeCard from '../../components/LargeCard/LargeCard'
import { ISubscription } from '../../models/interface/ISubscription'
import UserService from '../../services/UserService'

import "./subscriptionPage.scss"

const SubscriptionPage = () => {
    const [subsciptionData, setSubsciptionData] = useState<ISubscription[]>([])

    useEffect(() => {
        UserService.getAllSubscription().then((data) => {
            setSubsciptionData(data.data)
        })
    }, [])


    return (
        <div className="page-subscription__container">
            {subsciptionData.map((data) => (
                <LargeCard key={data.id + data.name} type="all" all_data={data} />
            ))}
        </div>
    )
}

export default observer(SubscriptionPage)