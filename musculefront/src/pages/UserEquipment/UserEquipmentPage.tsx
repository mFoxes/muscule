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
            <ol>
                {equipment.map((build) => (
                    <li>
                        Здание №{build.id} - {build.name}
                        <ol>
                            {build?.halls.map((hall) => (
                                <li>
                                    Зал №{hall.id} - {hall.name}
                                    <ol>
                                        {hall.equipmentHalls?.map((equip) => (
                                            <li>
                                                Оборудование №{equip.equipmentId} - {equip.equipment?.name} {equip.quantity}шт.
                                            </li>
                                        ))}
                                    </ol>
                                </li>
                            ))}
                        </ol>
                    </li>
                ))}
            </ol>
        </div>
    )
}

export default observer(UserEquipmentPage)