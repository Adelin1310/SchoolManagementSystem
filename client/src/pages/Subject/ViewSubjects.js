import "../styles/list.scss"
import Sidebar from "../../components/Sidebar"
import Navbar from "../../components/Navbar"
import Datatable from "../../components/Datatable"
import React from "react";
import { useEffect, useState } from "react";
import { subjectColumns } from "../../datatablesource";
import { getAllSubjects } from "../../api/Subjects";


const ViewSubjects = () => {
    const [data, setData] = useState();
    const [dataColumns, setDataColumns] = useState();

    const fetchData = async () => {
        const res = await getAllSubjects();
        return res.data
    }
    useEffect(() => {
        setDataColumns(subjectColumns)
        fetchData().then((res) => setData(res)).catch(err => console.log(err))
    }, [])


    return (
        data !== undefined ?
            (<div className="list" >
                <Sidebar />
                <div className="listContainer">
                    <Navbar />
                    <Datatable rowsData={data} columns={dataColumns} hasView={false}/>
                </div>
            </div >) : (<></>)
    )
}

export default ViewSubjects