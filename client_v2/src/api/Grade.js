import axios from 'axios'
import { json } from 'react-router-dom';
import { host } from '.';
const controller = `${host}Grade/`;

export const addGrade = async (data) => {
    try {
        let response = await axios.post(controller + `AddGrade`, data, { withCredentials: true })
        return response.data.data
    } catch (err) {
        throw json({
            status: parseInt(err.response.status)
        })
    }
}