import axios from 'axios'
import { json } from 'react-router-dom';
const controller = 'http://localhost:7055/api/Subject/';



export const getAllSubjects = async ()=>{
    try{
        let response = await axios.get(controller+'GetAllSubjects');
        return response;
    }catch(err){
        throw json(
            {
                status:parseInt(err.response.status)
            }
        )
    }
}

export const deleteSubjectById = async (id) => {
    try {
        let response = await axios.delete(controller + 'DeleteSubjectById', {
            data: {
                subjectId: id
            }
        })
        return response
    } catch (err) {
        console.error(err)
        return undefined
    }
}