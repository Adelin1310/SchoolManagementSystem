import axios from 'axios'
import { json } from 'react-router-dom';
import { host } from '.';
const controller = `${host}Situations/`;

export const endSituation = async (data) => {
    try {
        const res = await axios.post(controller + `EndSituation`, data , { withCredentials: true })
        return res.data.data
    } catch (err) {
        throw json(
            {
                status: parseInt(err.response.status)
            }
        )
    }
}