import { studentHost } from "./globals";

const host = studentHost;

export const getAllStudents = async () => {
    const response = await fetch(`${host}GetAllStudents`);
    const students = await response.json();
    return students;
}

export const getAllStudentsBySchoolId = async (id) => {
    const response = await fetch(`${host}GetAllStudentsBySchoolId/${id}`);
    const students = await response.json();
    return students;
}

export const getAllStudentsByClassId = async (id) => {
    const response = await fetch(`${host}GetAllStudentsByClassId/${id}`);
    const students = await response.json();
    return students;
}

export const getStudentById = async (id) =>{
    const response = await fetch(`${host}GetStudentById/${id}`);
    const students = await response.json();
    return students;
}

export const deleteStudentById = async (id) => {
    const response = await fetch(`${host}DeleteStudentById/${id}`,{
        method: 'DELETE',
        headers:{
            'Content-Type': 'application/json',
        }
    });
    console.log(response)
    const result = await response.json();
    return result;
}

export const addStudent = async (student) => {
    console.log(JSON.stringify(student))
    const response = await fetch(`${host}AddStudent`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(student)
    });
    const result = await response.json();
    return result;
}

export const updateStudent = async (student, studentId) => {
    const response = await fetch(`${host}UpdateStudentById/${studentId}`,{
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(student)
    });
    const result = await response.json();
    return result;
}