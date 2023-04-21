import axios from 'axios'
const controller = 'http://localhost:7055/api/Teacher/';



export const getAllTeachers = async ()=>{
    try{
        let response = await axios.get(controller+'GetAllTeachers');
        return response;
    }catch(err){
        console.error(err)
        return undefined
    }
}
export const getAllTeachersWSchoolsAndSubjects = async ()=>{
    try{
        let response = await axios.get(controller+'GetAllTeachersWSchoolsAndSubjects');
        return response;
    }catch(err){
        console.error(err)
        return undefined
    }
}

export const deleteTeacherById = async (id) => {
    try {
        let response = await axios.delete(controller + 'DeleteTeacherById', {
            data: {
                teacherId: id
            }
        })
        return response
    } catch (err) {
        console.error(err)
        return undefined
    }
}