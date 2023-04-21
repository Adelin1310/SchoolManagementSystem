import React, { useState } from 'react';
import './login.css'
import { login } from '../../../api/Auth';
import { useStateContext } from '../../../contexts/UserContext';

const Login = () => {
    const { setCurrentUser } = useStateContext();
    const [formData, setFormData] = useState({
        username: '',
        password: '',
    })
    const [errors, setErrors] = useState('')

    const handleChange = (name, value) => {
        setFormData({
            ...formData,
            [name]: value
        })
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        const res = await login(formData)
        if (!res.success) {
            setErrors(res.message)
        }
    }

    return (
        <div className="login">
            <div className='login-container'>
                <p>Welcome Back!</p>
                <form onSubmit={handleSubmit}>
                    <div className='form-errors'>{ }</div>
                    <div className='form-group'>
                        <input placeholder='Username' type="text" name='username' value={formData.username} onChange={(e) => handleChange(e.target.name, e.target.value)} required />
                    </div>
                    <div className='form-group'>
                        <input placeholder='Password' type="password" name='password' value={formData.password} onChange={(e) => handleChange(e.target.name, e.target.value)} required />
                    </div>

                    <button type="submit">Login</button>
                </form>
            </div>
        </div>
    );
}

export default Login;
