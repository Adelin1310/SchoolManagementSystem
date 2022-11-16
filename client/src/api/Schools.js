import axios from "axios";
import { schoolHost } from "./globals";

const host = schoolHost


export const getAllSchools = async () => {
    const response = await axios.get('GetAllSchools', {
        baseURL: host
    })
    return response.data;
}
export const getAllSchoolsWithClasses = async () => {
    const response = await axios.get('GetAllSchoolsWithClasses', {
        baseURL: host,
    })
    return response.data;
}

export const deleteSchoolById = async (id) => {
    const response = await axios.delete('DeleteSchoolById', {
        baseURL: host,
        params: { schoolId: id },
    })
    return response.data;
}

export const addSchool = async (data) => {
    const response = await axios.post('AddSchool', data, {
        baseURL: host,
    })
    return response.data;
}