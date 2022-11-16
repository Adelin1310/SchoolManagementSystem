import { classHost } from "./globals";

const host = classHost


export const getAllClasses = async () => {
    const response = await fetch(host + 'GetAllClasses');
    const json = await response.json();
    return json;
}

export const getAllClassesBySchoolId = async (id) => {
    const response = await fetch(host + 'GetAllClassesBySchoolId/' + id);
    const json = await response.json();
    return json;
}

export const getClassById = async (id) => {
    const response = await fetch(host + 'GetClassById/' + id);
    const json = await response.json();
    return json;
}

export const deleteClassById = async (id) => {
    const response = await fetch(host + 'DeleteClassById/' + id);
    const json = await response.json();
    return json;
}

export const addClass = async (data) => {
    const response = await fetch(host + 'AddClass', {
        method: 'POST',
        body: JSON.stringify(data),
        headers: {
            'Content-Type': 'application/json'
        }
    });
    const json = await response.json();
    return json;
}