import React, { FC, useContext } from 'react'
import "./largeCard.scss";
import { ISubscription } from '../../models/interface/ISubscription';
import MyButton from '../UI/button/MyButton';
import { observer } from 'mobx-react-lite';
import { Context } from '../..';
import UserService from '../../services/UserService';
import { ISubscriptionToUser } from '../../models/interface/ISubscriptionToUser';

const LargeCard: FC<{ all_data?: ISubscription, user_data?: ISubscriptionToUser, type: string }> = ({ ...props }) => {
    const { store } = useContext(Context)

    const BuySubscription = () => {
        if (props.all_data?.id != undefined) {
            const temp = UserService.buySubscription(props.all_data?.id, store.User.id)
            alert("вы подписались!")
            console.log(temp);
        }

    }

    return (
        <>
            {props.type === 'all' && props.all_data
                ? <div className='large-card'>
                    <div className="large-card__title">
                        {props.all_data.name}
                    </div>
                    <div className="large-card__bottom">
                        <div className="large-card__left">
                            <div>Занятий: {props.all_data.count}</div>
                            <div className='_icon-ruble'>{props.all_data.price}</div>
                        </div>
                        <div className="large-card__right">
                            {store.isAuth && <MyButton onClick={BuySubscription}>Записаться</MyButton>}
                        </div>
                    </div>
                </div>
                : props.user_data && <div className='large-card'>
                    <div className="large-card__title">
                        {props.user_data.subscription?.name}
                    </div>
                    {store.User.role?.id && store.User.role?.id === 1
                        ? <div className="large-card__bottom">
                            Осталось занятий: {props.user_data.visitCount}
                        </div>
                        : <MyButton onClick={() => {
                            store.setActiveWardsModal(true)
                            props.user_data?.subscription?.id != undefined && store.setWardsSubscribeId(props.user_data?.subscription.id)
                        }}>
                            Посмотреть подопечных
                        </MyButton>
                    }

                </div>}
        </>


    )
}


export default observer(LargeCard);