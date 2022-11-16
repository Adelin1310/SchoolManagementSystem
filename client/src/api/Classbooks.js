import axios from "axios";
import { classbookHost } from "./globals";

const host = classbookHost


export const GetAllClassbooks = async () => {
    const response = await axios.get('GetAllClassbooks', {
        baseURL: host
    })
    return response.data;
}

export const deleteClassbookById = async (id) => {
    const response = await axios.delete('DeleteClassbookById', {
        baseURL: host,
        params: { classbookId: id }
    })
    return response.data;
}

export const addClassbook = async (data) => {
    const response = await axios.post('AddClassbook', data, {
        baseURL: host
    })
    return response.data;
}