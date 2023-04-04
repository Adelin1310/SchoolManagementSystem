import axios from 'axios'
const controller = 'https://localhost:7055/api/Subject/';



export const getAllSubjects = async ()=>{
    try{
        let response = await axios.get(controller+'GetAllSubjects');
        return response;
    }catch(err){
        console.error(err)
        return undefined
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