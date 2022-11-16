import "../styles/list.scss"
import Sidebar from "../../components/Sidebar"
import Navbar from "../../components/Navbar"
import Datatable from "../../components/Datatable"
import React from "react";
import { useEffect, useState } from "react";
import { deleteTeacherById, getAllTeachersWSchoolsAndSubjects } from "../../api/Teachers";
import { teacherColumns } from "../../datatablesource";

const ViewTeachers = () => {
    const [data, setData] = useState();
    const [dataColumns, setDataColumns] = useState();

    const fetchData = async () => {
        const res = await getAllTeachersWSchoolsAndSubjects();
        return res.data
    }
    useEffect(() => {
        setDataColumns(teacherColumns)
        fetchData().then((res) => setData(res)).catch(err => console.log(err))
    }, [])


    return (
        data !== undefined ?
            (<div className="list" >
                <Sidebar />
                <div className="listContainer">
                    <Navbar />
                    <Datatable rowsData={data} columns={dataColumns} deleteFunction={deleteTeacherById} addPath='/teachers/new' viewPath='/teachers/' editPath='/teachers/edit/' />
                </div>
            </div >) : (<></>)
    )
}

export default ViewTeachers