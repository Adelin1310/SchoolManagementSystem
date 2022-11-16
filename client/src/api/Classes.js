import axios from "axios";
import { classHost } from "./globals";

const host = classHost


export const getAllClasses = async () => {
    const response = await axios.get('GetAllClasses', {
        baseURL: host
    })
    return response.data;
}

export const getAllClassesBySchoolId = async (id) => {
    const response = await axios.get('GetAllClassesBySchoolId', {
        baseURL: host,
        params: { schoolId: id }
    })
    return response.data;
}

export const getClassById = async (id) => {
    const response = await axios.get('GetClassById', {
        baseURL: host,
        params: { classId: id }
    })
    return response.data;
}

export const deleteClassById = async (id) => {
    const response = await axios.delete('DeleteClassById', {
        baseURL: host,
        params: { classId: id }
    })
    return response.data;
}

export const addClass = async (data) => {
    const response = await axios.post('AddClass', data, {
        baseURL: host
    })
    return response.data;
}