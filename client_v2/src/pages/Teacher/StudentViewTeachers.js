import React from 'react'
import { useLoaderData } from 'react-router-dom'
import LoadingSpinner from '../../components/loading/LoadingSpinner'
import Table from '../../components/table/Table'
import { StudentViewTeachersColumns } from '../../data/TableColumns'

const StudentViewTeachers = () => {
    const data = useLoaderData()

  return (
    data !== undefined ? 
    <Table columns={StudentViewTeachersColumns} data={data.data} allowedActions={[{type:"View"}]}/>
    :
    <LoadingSpinner/>
  )
}

export default StudentViewTeachers