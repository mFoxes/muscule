import { observer } from 'mobx-react-lite'
import React, { useContext, useEffect, useState } from 'react'
import "./userDataPage.scss"
import "react-datepicker/dist/react-datepicker.css";
import { Context } from '../..'

const UserDataPage = () => {
    const { store } = useContext(Context)

    return (
        <div className='user-data__body'>
            <div className="user-data__item">
                <div className='user-data__title'>ФИО</div>
                <div className='user-data__line'>{store.User.name}</div>
            </div>
            <div className="user-data__item">
                <div className='user-data__title'>Дата рождения</div>
                <div className='user-data__line'>{store.User.dateOfBirth.toString().split("T")[0]}</div>
                {/* TODO: Исправить */}
                {/* <div className='user-data__line'>{store.User.dateOfBirth.getDate()}.{store.User.dateOfBirth.getMonth()}.{store.User.dateOfBirth.getFullYear()}</div> */}
            </div>
            <div className="user-data__item">
                <div className='user-data__title'>Телефон</div>
                <div className='user-data__line'>{store.User.phone}</div>
            </div>
            <div className="user-data__item">
                <div className='user-data__title'>Роль</div>
                <div className='user-data__line'>{store.User.role?.name}</div>
            </div>
        </div>
    )
}

export default observer(UserDataPage)