import axios from 'axios'
import { json } from 'react-router-dom';
import { host } from '.';
const controller = `${host}Absence/`;

export const addAbsence = async (data) => {
    try {
        const res = await axios.post(controller + `AddAbsence`, data, {withCredentials:true})
        return res.data.data
    } catch (err) {
        throw json(
            {
                status: parseInt(err.response.status)
            }
        )
    }
}

export const motivateAbsence = async(data)=>{
    try {
        const res = await axios.post(controller + `MotivateAbsence`, data, {withCredentials:true})
        return res.data.data
    } catch (err) {
        throw json(
            {
                status: parseInt(err.response.status)
            }
        )
    }
}