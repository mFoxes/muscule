import React, { FC } from 'react';
import style from './MyButton.module.scss';

interface IButtonProps {
    children?: React.ReactNode,
    onClick?: React.MouseEventHandler<HTMLButtonElement>,
    className?: string,
    style?: {}
}

const MyButton: FC<IButtonProps> = ({ children, ...props }) => {
    return (
        <button {...props} className={`${style.MyBtn} ${props.className}`}>
            <p>{children}</p>
        </button>
    );
};

export default MyButton;