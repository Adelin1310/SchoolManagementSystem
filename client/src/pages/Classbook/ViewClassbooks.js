import "../styles/list.scss"
import Sidebar from "../../components/Sidebar"
import Navbar from "../../components/Navbar"
import Datatable from "../../components/Datatable"
import React from "react";
import { useEffect, useState } from "react";
import { GetAllClassbooks } from "../../api/Classbooks";
import { classbookColumns } from "../../datatablesource";


const ViewClassbooks
 = () => {
    const [data, setData] = useState();
    const [dataColumns, setDataColumns] = useState();

    const fetchData = async () => {
        const res = await GetAllClassbooks();
        return res.data
    }
    useEffect(() => {
        setDataColumns(classbookColumns)
        fetchData().then((res) => setData(res)).catch(err => console.log(err))
    },[])


    return (
        data !== undefined ?
            (<div className="list" >
                <Sidebar />
                <div className="listContainer">
                    <Navbar />
                    <Datatable rowsData={data} columns={dataColumns} viewPath='/classbooks/' hasView={true} />
                </div>
            </div >) : (<></>)
    )
}

export default ViewClassbooks
