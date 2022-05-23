import { observer } from 'mobx-react-lite'
import React, { useContext, useEffect, useState } from 'react'
import { Context } from '../..'
import MyButton from '../../components/UI/button/MyButton'
import MyInput from '../../components/UI/input/MyInput'
import { IDirection } from '../../models/interface/IDirection'
import { IWorkout } from '../../models/interface/IWorkout'
import "./userSubscriptionPage.scss"
import DatePicker from "react-datepicker"
import "react-datepicker/dist/react-datepicker.css";
import { ISubscriptionToUser } from '../../models/interface/ISubscriptionToUser'
import LargeCard from '../../components/LargeCard/LargeCard'
import SubscriptionModal from '../../components/Modals/Subscription/SubscriptionModal'
import WardsModal from '../../components/Modals/Wards/WardsModal'
import UserService from '../../services/UserService'
import { ISubscription } from '../../models/interface/ISubscription'

const UserSubscriptionPage = () => {
    const { store } = useContext(Context)

    const [subscriprionData, setSubscriptionData] = useState<ISubscriptionToUser[]>([])

    const [nameValue, setNameValue] = useState<string>('')

    const [dateRange, setDateRange] = useState<[Date | null, Date | null]>([null, null]);
    const [startDate, endDate] = dateRange;

    const [filteredData, setFilteredData] = useState<ISubscriptionToUser[]>([])


    useEffect(() => {
        setFilteredData(subscriprionData.filter(item => {
            return item.subscription?.name.toLowerCase().includes(nameValue.toLowerCase()) /*&& item.direction?.name.toLowerCase().includes(directionValue.toLowerCase())*/
        }))

    }, [nameValue/*, directionValue*/])

    useEffect(() => {
        if (store.User.id === 3) {
            UserService.getAllSubscription().then((data) => {
                data.data.forEach((item) => {
                    let temp: ISubscriptionToUser = {
                        subscriptionId: item.id,
                        subscription: item,
                        userId: store.User.id,
                        user: store.User,
                        visitCount: 0
                    }

                    setSubscriptionData(oldArray => [...oldArray, temp])
                    setFilteredData(oldArray => [...oldArray, temp])
                })
            })
        } else {
            UserService.getUserSubscription(store.User.id).then((data) => {
                setSubscriptionData(data.data)
                setFilteredData(data.data)
            })
        }
    }, [])

    return (
        <>
            <div className="user-subscription__sort">
                <div className='user-subscription__field'>
                    <MyInput
                        type='text'
                        placeholder='Название'
                        value={nameValue}
                        onChange={(e) => setNameValue(e.currentTarget.value)} />
                </div>
                {store.User.role?.id != undefined && store.User.role?.id === 3 && <MyButton
                    onClick={() => {
                        store.setActiveSubscriptionModal(true)
                    }}
                >
                    Добавить сертификат
                </MyButton>}
            </div>
            <div className="user-subscription__data">
                {filteredData.map((data) => {
                    return data.subscription?.id && <LargeCard key={data.subscription?.id + data.subscription?.name} type="user" user_data={data} />
                })}
            </div>
            <SubscriptionModal />
            <WardsModal />
        </>
    )
}

export default observer(UserSubscriptionPage)