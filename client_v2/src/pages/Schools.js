import React, { useEffect, useState } from 'react'
import { getAllSchools } from '../api/Schools'
import Table from '../components/table/Table'
import { schoolColumns } from '../data/TableColumns'

const Schools = () => {
  const [schools, setSchools] = useState(undefined)

  useEffect(()=>{
    async function f(){
      let response =await getAllSchools()
      setSchools(response.data.data)
      console.log(response.data)
    }
    f()
  },[])
  return (
    <div>{schools !== undefined ? <Table data={schools} columns={schoolColumns}/> : null}</div>
  )
}

export default Schools