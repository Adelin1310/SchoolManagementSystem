import React from 'react'
import Table from '../../components/table/Table'
import { StudentViewClassColumns } from '../../data/TableColumns'
import { useLoaderData } from 'react-router-dom'
import '../Styles/studentviewclass.css'

const StudentViewClass = () => {
    const dataColumns = StudentViewClassColumns
    const data = useLoaderData()

    return (
        <div className="class-container">
            <div className="class-details">
                <h2 className="class-details-header">Class {data.data.name} Details</h2>
                <div className="class-details-info">
                    <p><strong>Leader:</strong> {data.data.classLeader}</p>
                    <p><strong>Specialization:</strong> {data.data.specialization}</p>
                    <p><strong>Year:</strong> {data.data.year}</p>
                    <p><strong>Homeroom Teacher:</strong> {data.data.homeroomTeacher}</p>
                </div>
            </div>
            <Table columns={dataColumns} data={data.data.students} />
        </div>
    )
}

export default StudentViewClass
