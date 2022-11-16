import "../styles/list.scss"
import Sidebar from "../../components/Sidebar"
import Navbar from "../../components/Navbar"
import Datatable from "../../components/Datatable"
import React from "react";
import { useEffect, useState } from "react";
import { getAllSchools } from "../../api/Schools";
import { schoolColumns } from "../../datatablesource";


const ViewSchools = () => {
    const [data, setData] = useState();
    const [dataColumns, setDataColumns] = useState();

    const fetchData = async () => {
        const res = await getAllSchools();
        return res.data
    }
    useEffect(() => {
        setDataColumns(schoolColumns)
        fetchData().then((res) => setData(res)).catch(err => console.log(err))
    },[])


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

export default ViewSchools