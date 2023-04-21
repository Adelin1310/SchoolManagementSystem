import axios from 'axios'
const controller = 'http://localhost:7055/api/Auth/';


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
        console.log(err)
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