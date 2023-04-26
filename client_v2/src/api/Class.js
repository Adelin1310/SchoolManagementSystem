import axios from 'axios'
import { json } from 'react-router-dom';
const controller = 'http://localhost:7055/api/Class/';


export const getAllClasses = async () => {
    try {
        let response = await axios.get(controller + 'GetAllClasses');
        return response;
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