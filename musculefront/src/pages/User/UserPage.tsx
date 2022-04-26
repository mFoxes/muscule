import { observer } from 'mobx-react-lite'
import React, { useContext } from 'react'
import { Routes, Route, Link, Router, NavLink } from 'react-router-dom'
import { Context } from '../..'
import UserDataPage from '../UserData/UserDataPage'
import UserEquipmentPage from '../UserEquipment/UserEquipmentPage'
import UserSubscriptionPage from '../UserSubscription/UserSubscriptionPage'
import UserWorkoutPage from '../UserWorkout/UserWorkoutPage'
import "./userPage.scss"

const UserPage = () => {
    const { store } = useContext(Context)

    if (!store.isAuth) {
        
        return (<>Залогиньтесь</>)
    }

    return (
        <div className='user-page__container'>
            <div className="user-page__tab">
                <NavLink to="/user/workout" className={({isActive}) => (isActive ? 'active' : '')}>Занятия</NavLink>
                <NavLink to="/user/subscription" className={({isActive}) => (isActive ? 'active' : '')}>Сертификаты</NavLink>
                <NavLink to="/user/data" className={({isActive}) => (isActive ? 'active' : '')}>Данные</NavLink>
                {store.User.role?.id == 3 && <NavLink to="/user/equipment" className={({isActive}) => (isActive ? 'active' : '')}>Спорт-инвентарь</NavLink>}
            </div>
            <Routes>
                <Route path="/workout" element={<UserWorkoutPage></UserWorkoutPage>} />
                <Route path="/subscription" element={<UserSubscriptionPage></UserSubscriptionPage>} />
                <Route path="/data" element={<UserDataPage></UserDataPage>} />
                {store.User.role?.id == 3 && <Route path="/user/equipment" element={<UserEquipmentPage></UserEquipmentPage>} />}
            </Routes>
        </div>
    )
}

export default observer(UserPage)