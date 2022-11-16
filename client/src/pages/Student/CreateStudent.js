import "../styles/list.scss"
import Navbar from "../../components/Navbar";
import Sidebar from "../../components/Sidebar";
import Form from "../../components/Form";
import { studentInputs } from "../../formInputs";
import { useEffect, useState } from "react";
import { getAllSchoolsWithClasses } from "../../api/Schools";
import StudentForm from "../../components/Forms/StudentForm";



const CreateStudent = () => {
    const [data, setData] = useState();
    const [inputsData, setInputsData] = useState(studentInputs);

    const fetchData = async () => {
        const res = await getAllSchoolsWithClasses();
        return res.data;
    }

    useEffect(() => {
        fetchData().then(res => {
            setData(res)
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
                    label: x.school.name,
                    value: x.school.id,
                    classes: []
                });
                let selectsLength = oldInputs[oldInputs.length - 1].selects.length;
                if (x.classes.length > 0) {
                    x.classes.forEach((y) => {
                        oldInputs[oldInputs.length - 1].selects[selectsLength - 1].classes.push({
                            value: y.id,
                            name: y.name,
                        })
                    })
                }
            })

            setInputsData(oldInputs);

        }).catch(err => console.error(err));
    }, [])

    return (
        <div className="list" >
            <Sidebar />
            <div className="listContainer">
                <Navbar />
                <StudentForm inputs={inputsData} />
            </div>
        </div >
    )
}

export default CreateStudent;