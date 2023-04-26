import axios from 'axios'
import { json } from 'react-router-dom';
const controller = 'http://localhost:7055/api/School/';



export const getAllSchools = async () => {
    try {
        let response = await axios.get(controller + 'GetAllSchools', { withCredentials: true });
        return response;
    } catch (err) {
        throw json(
            {
                status:parseInt(err.response.status)
            }
        )
    }
}