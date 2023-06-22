import axios from 'axios'
import { json } from 'react-router-dom';
import { host } from '.';
const controller = `${host}Student/`;



export const getAllStudents = async () => {
    try {
        let response = await axios.get(controller + 'GetAllStudents', { withCredentials: true });
        return response;
    } catch (err) {
        throw json(
            {
                status: parseInt(err.response.status)
            }
        )
    }
}

export const getAllStudentsByClassId = async (id) => {
    try {
        let response = await axios.get(controller + `GetAllStudentsByClassId/${id}`, { withCredentials: true })
        return response
    } catch (err) {
        throw json({
            status: parseInt(err.response.status)
        })
    }
}

export const deleteStudentById = async (id) => {
    try {
        let response = await axios.delete(controller + 'DeleteStudentById', {
            data: {
                studentId: id
            },
            withCredentials: true
        },)
        return response
    } catch (err) {
        throw json(
            {
                status: parseInt(err.response.status)
            }
        )
    }
}