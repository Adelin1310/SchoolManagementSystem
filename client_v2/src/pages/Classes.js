import React, { useEffect, useState } from 'react'
import { getAllClasses } from '../api/Class'
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
    return (
        classes !== undefined ?
            <Table
                options={{
                    width: '1000px',
                    sortedBy: 'Id',
                    pageSize: 10
                }}
                data={classes}
                columns={classColumns} /> : null
    )
}

export default Classes