import axios from 'axios'
const controller = 'http://localhost:7055/api/Student/';



export const getAllStudents = async ()=>{
    try{
        let response = await axios.get(controller+'GetAllStudents');
        return response;
    }catch(err){
        console.error(err)
        return undefined
    }
}

export const deleteStudentById = async (id) => {
    try {
        let response = await axios.delete(controller + 'DeleteStudentById', {
            data: {
                studentId: id
            }
        })
        return response
    } catch (err) {
        console.error(err)
        return undefined
    }
}