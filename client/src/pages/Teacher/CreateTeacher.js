import "../styles/list.scss"
import Navbar from "../../components/Navbar";
import Sidebar from "../../components/Sidebar";
import Form from "../../components/Form";
import { teacherInputs } from "../../formInputs";
import { useEffect, useState } from "react";
import { getAllSchools } from "../../api/Schools";
import { getAllSubjects } from "../../api/Subjects";
import StudentForm from "../../components/Forms/StudentForm";
import TeacherForm from "../../components/Forms/TeacherForm";



const CreateTeacher = () => {
    const [data, setData] = useState();
    const [inputsData, setInputsData] = useState();

    const fetchData = async () => {
        const schools = await getAllSchools();
        const subjects = await getAllSubjects();
        return { schools: schools.data, subjects: subjects.data };
    }

    useEffect(() => {
        fetchData().then(res => {
            let schools = res.schools;
            let subjects = res.subjects;
            let mappedSchools = schools.map(s => ({
                name: s.name,
                value: s.id,
                checked: false
            }))
            let mappedSubjects = subjects.map(s => ({
                name: s.name,
                value: s.id,
                checked: false
            }))
            let newInputsData = [];
            newInputsData.push({
                schools: mappedSchools,
                subjects: mappedSubjects
            })
            newInputsData.push(...teacherInputs)
            setInputsData(
                {
                    newInputsData
                })

        }).catch(err => console.error(err));
    }, [])

    return (
        inputsData !== undefined ? 
        <div className="list" >
            <Sidebar />
            <div className="listContainer">
                <Navbar />
                <TeacherForm inputs={inputsData} />
            </div>
        </div > : null
    )
}

export default CreateTeacher;