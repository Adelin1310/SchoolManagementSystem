import React, { useEffect, useState } from 'react'
import Actions from '../components/actions/Actions'
import Table from '../components/table/Table'
import { teachersColumns } from '../data/TableColumns'
import { deleteTeacherById, getAllTeachers, getAllTeachersWSchoolsAndSubjects } from '../api/Teachers'

const Teachers = () => {
    const [teachers, setTeachers] = useState(undefined)

    useEffect(() => {
        async function f() {
            let response = await getAllTeachersWSchoolsAndSubjects()
            setTeachers(response.data.data)
            console.log(response)
        }
        f()
    }, [])

    const onDelete = async (id) => {
        let res = await deleteTeacherById(id)
        if (res.data.success)
            return res.data.message
        else
            console.error(res.data.message)
    }

    return (
        <div>
            <Actions/>
            {
                teachers !== undefined ?
                    <Table
                        data={teachers}
                        columns={teachersColumns}
                        onDelete={onDelete} /> : null
            }
        </div>
    )
}

export default Teachers