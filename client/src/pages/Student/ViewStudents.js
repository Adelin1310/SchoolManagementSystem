import "../styles/list.scss"
import Sidebar from "../../components/Sidebar"
import Navbar from "../../components/Navbar"
import Datatable from "../../components/Datatable"
import React from "react";
import { useEffect, useState } from "react";
import { deleteStudentById, getAllStudents } from "../../api/Students";
import { studentColumns } from "../../datatablesource";


const ViewStudents = () => {
    const [data, setData] = useState();
    const [dataColumns, setDataColumns] = useState();

    const fetchData = async () => {
        const res = await getAllStudents();
        return res.data
    }
    useEffect(() => {
        setDataColumns(studentColumns)
        fetchData().then((res) => setData(res)).catch(err => console.log(err))
    },[])


    return (
        data !== undefined ?
            (<div className="list" >
                <Sidebar />
                <div className="listContainer">
                    <Navbar />
                    <Datatable  rowsData={data} columns={dataColumns} deleteFunction={deleteStudentById} addPath='/students/new' viewPath='/students/' editPath='/students/edit/'/>
                </div>
            </div >) : (<></>)
    )
}

export default ViewStudents