import { subjectHost } from "./globals";
import axios from "axios";
const host = subjectHost;

export const getAllSubjects = async () => {
    const response = await axios.get('GetAllSubjects', {
        baseURL: host
    })
    return response.data;
}

export const deleteSubjectById = async (id) => {
    const response = await axios.delete('DeleteSubjectById', {
        baseURL: host,
        params: { id: id }
    })
    return response.data;
}

export const addSubject = async (subject) => {
    const response = await axios.post('AddSubject', subject, {
        baseURL: host
    })
    return response.data;
}
