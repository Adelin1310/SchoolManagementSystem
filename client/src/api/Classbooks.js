import { classbookHost } from "./globals";

const host = classbookHost


export const GetAllClassbooks = async () => {
    const response = await fetch(host + 'GetAllClassbooks');
    const json = await response.json();
    return json;
}

export const deleteClassbookById = async (id) => {
    const response = await fetch(`${host}DeleteClassbookById/${id}`);
    const json = await response.json();
    return json;
}

export const addClassbook = async (data) => {
    const response = await fetch(`${host}AddClassbook`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });
    const json = await response.json();
    return json;
}