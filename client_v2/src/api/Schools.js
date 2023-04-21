import axios from 'axios'
const controller = 'http://localhost:7055/api/School/';



export const getAllSchools = async ()=>{
    try{
        let response = await axios.get(controller+'GetAllSchools');
        return response;
    }catch(err){
        console.error(err)
        return undefined
    }
}