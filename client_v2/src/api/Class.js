import axios from 'axios'
import { json } from 'react-router-dom';
import { host } from '.';
const controller = `${host}Class/`;


export const getAllClasses = async () => {
    try {
        let response = await axios.get(controller + 'GetAllClasses', { withCredentials: true });
        return response.data;
    } catch (err) {
        throw json(
            {
                status: parseInt(err.response.status)
            }
        )
    }
}

export const getAllTeacherClasses = async () => {
    try {
        let response = await axios.get(controller + 'GetAllTeacherClasses', { withCredentials: true })
        return response.data.data
    } catch (err) {
        throw json(
            {
                status: parseInt(err.response.status)
            }
        )
    }
}
export const getStudentClass = async () => {
    try {
        let response = await axios.get(controller + 'GetStudentClass', { withCredentials: true });
        return response.data;
    } catch (err) {
        throw json(
            {
                status: parseInt(err.response.status)
            }
        )
    }
}
export const deleteClassById = async (id) => {
    try {
        let response = await axios.delete(controller + 'DeleteClassById', {
            data: {
                classId: id
            },
            withCredentials: true,
        })
        return response.data
    } catch (err) {
        throw json(
            {
                status: parseInt(err.response.status)
            }
        )
    }
}