import "../styles/list.scss"
import Navbar from "../../components/Navbar";
import Sidebar from "../../components/Sidebar";
import { studentInputs } from "../../formInputs";
import { useEffect, useState } from "react";
import { getAllSchoolsWithClasses } from "../../api/Schools";
import { getStudentById } from "../../api/Students";
import { useParams } from "react-router-dom";
import StudentEditForm from "../../components/Forms/StudentEditForm";



const EditStudent = () => {
    const [data, setData] = useState();
    const [studentData, setStudentData] = useState();
    const [inputsData, setInputsData] = useState(studentInputs);
    let { studentId } = useParams();

    const fetchData = async () => {
        const res = await getAllSchoolsWithClasses();
        const res1 = await getStudentById(studentId);
        return { schools_classes: res.data, studentData: res1.data };
    }

    useEffect(() => {
        console.log(studentId);
        fetchData().then(({ schools_classes, studentData }) => {
            setData(schools_classes)
            let oldInputs = inputsData;
            oldInputs =
                [
                    ...oldInputs,
                    {
                        type: 'array',
                        selects: []
                    }
                ]

            schools_classes.forEach((x) => {
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
            setStudentData(studentData)
            setInputsData(oldInputs);

        }).catch(err => console.error(err));
    }, [])

    return (
        <div className="list" >
            <Sidebar />
            <div className="listContainer">
                <Navbar />
                {studentData !== undefined && inputsData[3]?.selects !== undefined &&
                    <StudentEditForm studentData={studentData} inputs={inputsData} />}
            </div>
        </div >
    )
}

export default EditStudent;