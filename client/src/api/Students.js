import axios from "axios";
import { studentHost } from "./globals";
const host = studentHost;

export const getAllStudents = async () => {
    const response = await axios.get('GetAllStudents', {
        baseURL: host
    });
    return response.data;
}

export const getAllStudentsBySchoolId = async (id) => {
    const response = await axios.get('GetAllStudentsBySchoolId', {
        baseURL: host,
        params: { schoolId: id }
    });
    return response.data;
}

export const getAllStudentsByClassId = async (id) => {
    const response = await axios.get('GetAllStudentsByClassId', {
        baseURL: host,
        params: { classId: id }
    });
    return response.data;
}

export const getStudentById = async (id) => {
    const response = await axios.get('GetStudentById', {
        baseURL: host,
        params: { studentId: id }
    });
    return response.data;
}

export const deleteStudentById = async (id) => {
    const response = await axios.delete('DeleteStudentById', {
        baseURL: host,
        params: { studentId: id }
    })
    return response.data;
}

export const addStudent = async (student) => {
    const response = await axios.post('AddStudent', student, {
        baseURL: host,
    })
    return response.data;
}

export const updateStudent = async (student, studentId) => {
    const response = await axios.put('UpdateStudentById', student, {
        baseURL: host,
        params: { studentId: studentId }
    })
    return response.data;
}