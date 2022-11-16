import "../styles/list.scss"
import Sidebar from "../../components/Sidebar"
import Navbar from "../../components/Navbar"
import Datatable from "../../components/Datatable"
import React from "react";
import { useEffect, useState } from "react";
import { getAllStudentsBySchoolId } from "../../api/Students";
import { studentColumns } from "../../datatablesource";
import { useParams } from "react-router-dom";


const ViewSchool = () => {
    const [data, setData] = useState();
    const [dataColumns, setDataColumns] = useState();
    let { schoolId } = useParams();

    const fetchData = async () => {
        const res = await getAllStudentsBySchoolId(schoolId);
        return res.data
    }
    useEffect(() => {
        setDataColumns(studentColumns)
        fetchData().then((res) => setData(res)).catch(err => console.log(err))
    }, [])


    return (
        data !== undefined ?
            (<div className="list" >
                <Sidebar />
                <div className="listContainer">
                    <Navbar />
                    <Datatable rowsData={data} columns={dataColumns} viewPath='/schools/' />
                </div>
            </div >) : (<></>)
    )
}

export default ViewSchool