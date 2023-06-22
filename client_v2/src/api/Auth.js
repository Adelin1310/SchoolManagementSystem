import axios from 'axios'
import { json } from 'react-router-dom';
import { host } from '.';
const controller = `${host}Auth/`;


export const login = async (credentials) => {
    try {
        const res = await axios.post(controller + 'login', credentials, { withCredentials: true })
        return res.data
    } catch (err) {
        console.error(err);
    }
}

export const register = async (newUserData) => {
    try {
        const res = await axios.post(controller + 'register', newUserData, { withCredentials: true })
        return res.data
    } catch (err) {
        console.log(err)
    }
}

export const validateToken = async () => {
    try {
        const res = await axios.post(controller + 'validate', null, { withCredentials: true })
        return res.data
    } catch (err) {
        throw err;
    }
}

export const logout = async () => {
    try {
        const res = await axios.post(controller + 'logout', null, { withCredentials: true })
        return res.data
    } catch (err) {
        console.log(err)
    }
}

export const getProfile = async (role) => {
    try {
        const res = await axios.get(controller + `get${role}Profile`, { withCredentials: true })
        return res.data;
    } catch (err) {
        throw json(
            {
                status: parseInt(err.response.status)
            }
        )
    }
}