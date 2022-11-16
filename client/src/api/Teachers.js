import { teacherHost } from "./globals";
import axios from "axios"
const host = teacherHost

export const getAllTeachers = async () => {
    const response = await axios.get('GetAllTeachers', {
        baseURL: host
    })
    return response.data;
}
export const getAllTeachersWSchoolsAndSubjects = async () => {
    const response = await axios.get('GetAllTeachersWSchoolsAndSubjects', {
        baseURL: host
    })
    return response.data;
}

export const deleteTeacherById = async (id) => {
    const response = await axios.delete('DeleteTeacherById', {
        baseURL: host,
        params: {
            id: id
        }
    })
    return response.data;
}

export const addTeacher = async (teacher) => {
    const response = await axios.post('AddTeacher', teacher, {
        baseURL: host,
    })
    return response.data;
}