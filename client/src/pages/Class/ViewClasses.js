import "../styles/list.scss"
import Sidebar from "../../components/Sidebar"
import Navbar from "../../components/Navbar"
import Datatable from "../../components/Datatable"
import React from "react";
import { useEffect, useState } from "react";
import { deleteClassById, getAllClasses } from "../../api/Classes";
import { classColumns } from "../../datatablesource";


const ViewClasses = () => {
    const [data, setData] = useState();
    const [dataColumns, setDataColumns] = useState();

    const fetchData = async () => {
        const res = await getAllClasses();
        return res.data
    }
    useEffect(() => {
        setDataColumns(classColumns)
        fetchData().then((res) => setData(res)).catch(err => console.log(err))
    },[])


    return (
        data !== undefined ?
            (<div className="list" >
                <Sidebar />
                <div className="listContainer">
                    <Navbar />
                    <Datatable rowsData={data} columns={dataColumns} viewPath='/classes/' addPath='/classes/new' editPath='/classes/edit' deleteFunction={deleteClassById}/>
                </div>
            </div >) : (<></>)
    )
}

export default ViewClasses