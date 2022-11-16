import { subjectHost } from "./globals";

const host = subjectHost;

export const getAllSubjects = async () => {
    const response = await fetch(`${host}GetAllSubjects`);
    const students = await response.json();
    return students;
}

export const deleteSubjectById = async (id) => {
    const response  = await fetch(`${host}DeleteSubjectById/${id}`);
    const students = await response.json();
    return students;
}

export const addSubject = async (subject) => {
    const response  = await fetch(`${host}AddSubject`, {
        method: "POST",
        body: JSON.stringify(subject),
        headers: {
            "Content-Type": "application/json"
        }
    });
    const result = await response.json();
    return result;
}
