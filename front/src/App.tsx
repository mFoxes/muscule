import { observer } from 'mobx-react-lite';
import React, { useContext, useEffect, useRef, useState } from 'react';
import { BrowserRouter, Link, Route, Routes } from 'react-router-dom';
import { Context } from '.';
import LoginModal from './components/Modals/Login/LoginModal';
import MyButton from './components/UI/button/MyButton';
import CoachPage from './pages/Coach/CoachPage';
import SubscriptionPage from './pages/Subscription/SubscriptionPage';
import UserPage from './pages/User/UserPage';

import "./styles/App.scss";
import "./styles/reset.scss";
import "./styles/variables.scss";

function App() {
    const { store } = useContext(Context)
    const app = useRef()

    if (store.isLoading) {
        return <div>Loading...</div>
    }

    return (
        <div className={`app${store.activeLoginModal ? " loginmodule" : ""}`}>
            <BrowserRouter>
                <div className="app__header header-app">
                    <div className="header-app__container">
                        <ul className="header-app__menu">
                            <li className="header-app__item">
                                <Link to="/">Главная</Link>
                            </li>
                            <li className="header-app__item">
                                <Link to="/sertificates">Сертификаты</Link>
                            </li>
                            <li className="header-app__item">
                                <Link to="/coaches">Тренера</Link>
                            </li>
                        </ul>
                        <div className="header-app__userbtn">
                            {!store.isAuth
                                ? <MyButton
                                    onClick={() => {
                                        store.setActiveLoginModal(true)
                                    }}
                                >
                                    Вход
                                </MyButton>
                                : <>
                                    <MyButton
                                        onClick={() => store.logout()}
                                    >
                                        Выход
                                    </MyButton>
                                    <Link to="/user"><MyButton className='_icon-account user-icon'>

                                    </MyButton> </Link>
                                </>}
                        </div>
                    </div>
                </div>
                <div className="app__body">
                    <Routes>
                        <Route path="/" element={<></>} />
                        <Route path="/sertificates" element={<SubscriptionPage />} />
                        <Route path="/coaches" element={<CoachPage />} />
                        <Route path="/user/*" element={<UserPage />}/>
                    </Routes>
                </div>

                <LoginModal />
            </BrowserRouter>
        </div>
    );
}

export default observer(App);
