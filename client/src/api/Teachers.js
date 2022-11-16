import { teacherHost } from "./globals";

const host = teacherHost


export const getAllTeachers = async () =>{
    const response = await fetch(host + 'GetAllTeachers');
    const json = await response.json();
    return json;
}
export const getAllTeachersWSchoolsAndSubjects = async () =>{
    const response = await fetch(host + 'GetAllTeachersWSchoolsAndSubjects');
    const json = await response.json();
    return json;
}

export const deleteTeacherById = async (id) =>{
    const response = await fetch(`${host}DeleteTeacherById/${id}`);
    const json = await response.json();
    return json;
}

export const addTeacher = async (teacher) =>{
    const response = await fetch(`${host}AddTeacher`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(teacher)
    });
    const json = await response.json();
    return json;
}