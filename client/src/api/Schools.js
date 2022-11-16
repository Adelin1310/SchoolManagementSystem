import { schoolHost } from "./globals";

const host = schoolHost


export const getAllSchools = async () => {
    const response = await fetch(schoolHost + 'GetAllSchools');
    const json = await response.json();
    return json;
}
export const getAllSchoolsWithClasses = async () => {
    const response = await fetch(schoolHost + 'GetAllSchoolsWithClasses');
    const json = await response.json();
    return json;
}

export const deleteSchoolById = async (id) => {
    const response = await fetch(`${host}DeleteSchoolById/${id}`);
    const json = await response.json();
    return json;
}

export const addSchool = async (data) => {
    const response = await fetch(`${host}AddSchool`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    });
    const json = await response.json();
    return json;
}