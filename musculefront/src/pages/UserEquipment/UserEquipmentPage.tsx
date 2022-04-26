import { observer } from 'mobx-react-lite'
import React, { useContext, useEffect, useState } from 'react'
import "./userEquipmentPage.scss"
import "react-datepicker/dist/react-datepicker.css";
import { Context } from '../..'
import UserService from '../../services/UserService';
import { IEquipmentToHall } from '../../models/interface/IEquipmentToHall';
import { IBuilding } from '../../models/interface/IBuilding';

const UserEquipmentPage = () => {
    const { store } = useContext(Context)

    const [equipment, setEquipment] = useState<IBuilding[]>([])

    useEffect(() => {
        UserService.getAllEquipment().then((data) => {
            setEquipment(data.data)
            console.log(data);
        })
    }, [])
    

    return (
        <div className='user-equipment__body'>
        111
            <ul>
            </ul>
        </div>
    )
}

export default observer(UserEquipmentPage)