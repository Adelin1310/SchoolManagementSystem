import React, { useEffect, useState } from 'react'
import Actions from '../components/actions/Actions'
import Table from '../components/table/Table'
import { studentColumns } from '../data/TableColumns'
import { deleteStudentById, getAllStudents } from '../api/Students'

const Students = () => {
    const [students, setStudents] = useState(undefined)

    useEffect(() => {
        async function f() {
            let response = await getAllStudents()
            setStudents(response.data.data)
        }
        f()
    }, [])

    const onDelete = async (id) => {
        let res = await deleteStudentById(id)
        if (res.data.success)
            return res.data.message
        else
            console.error(res.data.message)
    }

    return (
        <div>
            <Actions/>
            {
                students !== undefined ?
                    <Table
                        data={students}
                        columns={studentColumns}
                        onDelete={onDelete} /> : null
            }
        </div>
    )
}

export default Students