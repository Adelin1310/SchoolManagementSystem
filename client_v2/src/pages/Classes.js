import React, { useEffect, useState } from 'react'
import { deleteClassById, getAllClasses } from '../api/Class'
import Actions from '../components/actions/Actions'
import Table from '../components/table/Table'
import { classColumns } from '../data/TableColumns'

const Classes = () => {
    const [classes, setClasses] = useState(undefined)

    useEffect(() => {
        async function f() {
            let response = await getAllClasses()
            setClasses(response.data.data)
        }
        f()
    }, [])

    const onDelete = async (id) => {
        let res = await deleteClassById(id)
        if (res.data.success)
            return res.data.message
        else
            console.error(res.data.message)
    }

    return (
        <div>
            <Actions/>
            {
                classes !== undefined ?
                    <Table
                        data={classes}
                        columns={classColumns}
                        onDelete={onDelete} /> : null
            }
        </div>
    )
}

export default Classes