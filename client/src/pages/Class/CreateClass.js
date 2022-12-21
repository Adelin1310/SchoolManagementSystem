import "../styles/list.scss"
import Navbar from "../../components/Navbar";
import Sidebar from "../../components/Sidebar";
import {  classInputs} from "../../formInputs";
import { useEffect, useState } from "react";
import { getAllSchools } from "../../api/Schools";
import ClassForm from "../../components/Forms/ClassForm";



const CreateClass = () => {
    const [data, setData] = useState();
    const [inputsData, setInputsData] = useState(classInputs);

    const fetchData = async () => {
        const res = await getAllSchools();
        return res.data;
    }

    useEffect(() => {
        fetchData().then(res => {
            setData(res)
            console.log(res)
            let oldInputs = inputsData;
            oldInputs =
                [
                    ...oldInputs,
                    {
                        type: 'array',
                        selects: []
                    }
                ]

            res.forEach((x) => {
                oldInputs[oldInputs.length - 1].selects.push({
                    type: 'select',
                    name: 'school',
                    label: x.name,
                    value: x.id,
                });
            })

            setInputsData(oldInputs);

        }).catch(err => console.error(err));
    }, [])

    return (
        <div className="list" >
            <Sidebar />
            <div className="listContainer">
                <Navbar />
                <ClassForm inputs={inputsData} />
            </div>
        </div >
    )
}

export default CreateClass;