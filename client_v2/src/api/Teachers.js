import axios from 'axios'
import { json } from 'react-router-dom';
import { host } from '.';
const controller = `${host}Teacher/`;



export const getAllTeachers = async () => {
    try {
        let response = await axios.get(controller + 'GetAllTeachers');
        return response;
    } catch (err) {
        throw json(
            {
                status: parseInt(err.response.status)
            }
        )
    }
}
export const getTeacherWClassesAndSubjects = async (id) => {
    try {
        let response = await axios.get(controller + `GetTeacherWClassesAndSubjects/${id}`, { withCredentials: true });
        return response.data;
    } catch (err) {
        throw json(
            {
                status: parseInt(err.response.status)
            }
        )
    }
}

export const getAllTeachersWSchoolsAndSubjects = async () => {
    try {
        let response = await axios.get(controller + 'GetAllTeachersWSchoolsAndSubjects');
        return response;
    } catch (err) {
        throw json(
            {
                status: parseInt(err.response.status)
            }
        )
    }
}
export const getTeachersByClassId = async () => {
    try {
        let response = await axios.get(controller + 'GetTeachersByClassId', { withCredentials: true });
        return response.data
    } catch (err) {
        throw json({
            status: parseInt(err.response.status)
        })
    }
}
export const deleteTeacherById = async (id) => {
    try {
        let response = await axios.delete(controller + 'DeleteTeacherById', {
            data: {
                teacherId: id
            }
        })
        return response
    } catch (err) {
        throw json(
            {
                status: parseInt(err.response.status)
            }
        )
    }
}