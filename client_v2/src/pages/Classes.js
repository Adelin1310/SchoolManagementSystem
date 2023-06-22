import React, { useEffect, useState } from 'react'
import { deleteClassById, getAllClasses } from '../api/Class'
import Actions from '../components/actions/Actions'
import Table from '../components/table/Table'
import { StudentViewClassColumns, classColumns, studentColumns } from '../data/TableColumns'
import { useLoaderData } from 'react-router-dom'
import { useStateContext } from '../contexts/UserContext'
import LoadingSpinner from '../components/loading/LoadingSpinner'
import { deleteStudentById } from '../api/Students'

const Classes = () => {
    const { currentUser } = useStateContext()
    let data = useLoaderData()
    const dataColumns = currentUser?.role === "Student" ? StudentViewClassColumns : studentColumns

    const getReturn = () => {
        return (<LoadingSpinner />)
    }

    return (
        getReturn()
    )
}

export default Classes