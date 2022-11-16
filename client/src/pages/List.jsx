import "./styles/list.scss"
import Sidebar from "../components/Sidebar"
import Navbar from "../components/Navbar"
import Datatable from "../components/Datatable"
import React from "react";
import { useEffect } from "react";


const List = ({ getFunction, columns }) => {
  const [data, setData] = React.useState();
  const [dataColumns, setDataColumns] = React.useState(columns);

  const fetchData = async () => {
    const res = await getFunction();
    return res.data
  }
  useEffect(() => {
    setDataColumns(columns)
    fetchData().then((res) => setData(res)).catch(err => console.log(err))
  })
  

  return (

    data !== undefined ?
      (<div className="list" >
        <Sidebar />
        <div className="listContainer">
          <Navbar />
          <Datatable rowsData={data} columns={dataColumns} />
        </div>
      </div >) : (<></>)
  )
}

export default List