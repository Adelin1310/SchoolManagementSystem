import axios from 'axios'
import { json } from 'react-router-dom';
import { host } from '.';
const controller = `${host}Classbook/`;

export const getClassbook = async (classbookId) => {
    try {
        let response = await axios.get(controller + `GetClassbook/${classbookId}`, { withCredentials: true })
        return response.data.data
    } catch (err) {
        throw json({
            status: parseInt(err.response.status)
        })
    }
}
export const getStudentsSituation = async (subjectId, classbookId, classId) => {
    try {
        let response = await axios.get(controller + `GetStudentsSituation/${subjectId}/${classId}/${classbookId}`, { withCredentials: true })
        return response.data.data
    } catch (err) {
        throw json({
            status: parseInt(err.response.status)
        })
    }
}