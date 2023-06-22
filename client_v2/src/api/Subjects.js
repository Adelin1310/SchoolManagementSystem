import axios from 'axios'
import { json } from 'react-router-dom';
import { host } from '.';
const controller = `${host}Subject/`;


export const getStudentClassbook = async () => {
    try {
        var res = await axios.get(controller + 'GetAllClassSubjects', { withCredentials: true })
        return res.data.data
    } catch (err) {
        throw json(
            {
                status: parseInt(err.response.status)
            }
        )
    }
}
export const getTeacherClassSubjects = async (classId) => {
    try {
        var res = await axios.get(controller + `GetTeacherClassSubjects/${classId}`, { withCredentials: true })
        return res.data.data

    } catch (err) {
        throw json(
            {
                status: parseInt(err.response.status)
            }
        )
    }
}
export const getStudentSituation = async () => {
    try {
        var res = await axios.get(controller + 'GetStudentSituation', { withCredentials: true })
        return res.data.data
    } catch (err) {
        throw json(
            {
                status: parseInt(err.response.status)
            }
        )
    }
}

export const getAllSubjects = async () => {
    try {
        let response = await axios.get(controller + 'GetAllSubjects');
        return response;
    } catch (err) {
        throw json(
            {
                status: parseInt(err.response.status)
            }
        )
    }
}

export const deleteSubjectById = async (id) => {
    try {
        let response = await axios.delete(controller + 'DeleteSubjectById', {
            data: {
                subjectId: id
            }
        })
        return response
    } catch (err) {
        console.error(err)
        return undefined
    }
}