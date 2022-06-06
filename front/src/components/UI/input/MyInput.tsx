import React, { FC, forwardRef, InputHTMLAttributes } from "react";

import styles from "./MyInput.module.scss";

interface IInput extends InputHTMLAttributes<HTMLInputElement> {
    className?: string,
    register?: any
}

const MyInput: FC<IInput> = forwardRef(({register, ...props }, forwardedRef) => {
    return (
        <input {...props} {...register} className={`${styles.myInput} ${props.className}`} />
    )
});

export default MyInput;