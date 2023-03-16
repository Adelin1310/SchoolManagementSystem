import axios from 'axios'
const controller = 'https://localhost:7055/api/Class/';


export const getAllClasses = async ()=>{
    try{
        let response = await axios.get(controller+'GetAllClasses');
        return response;
    }catch(err){
        console.error(err)
        return undefined
    }
}