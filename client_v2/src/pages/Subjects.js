import React, { useEffect, useState } from 'react'
import Table from '../components/table/Table'
import { subjectsColumns } from '../data/TableColumns'
import { deleteSubjectById, getAllSubjects } from '../api/Subjects'

const Subjects = () => {
    const [subjects, setSubjects] = useState(undefined)

    useEffect(() => {
        async function f() {
            let response = await getAllSubjects()
            setSubjects(response.data.data)
            console.log(response)
        }
        f()
    }, [])

    const onDelete = async (id) => {
        let res = await deleteSubjectById(id)
        if (res.data.success)
            return res.data.message
        else
            console.error(res.data.message)
    }

    return (
        <div>
            {
                subjects !== undefined ?
                    <Table
                        data={subjects}
                        columns={subjectsColumns}
                        onDelete={onDelete} /> : null
            }
        </div>
    )
}

export default Subjects