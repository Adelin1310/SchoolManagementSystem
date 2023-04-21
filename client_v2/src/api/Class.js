import axios from 'axios'
const controller = 'http://localhost:7055/api/Class/';


export const getAllClasses = async () => {
    try {
        let response = await axios.get(controller + 'GetAllClasses');
        return response;
    } catch (err) {
        console.error(err)
        return undefined
    }
}

export const deleteClassById = async (id) => {
    try {
        let response = await axios.delete(controller + 'DeleteClassById', {
            data: {
                classId: id
            }
        })
        return response
    } catch (err) {
        console.error(err)
        return undefined
    }
}