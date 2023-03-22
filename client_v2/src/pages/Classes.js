import React, { useEffect, useState } from 'react'
import { getAllClasses } from '../api/Class'
import Button from '../components/button/Button'
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
    return (<div>
        <Button to='add' value={'ADD'}/>
        {
            classes !== undefined ?
                <Table
                    options={{
                        width: '70%',
                        sortedBy: 'Id',
                        pageSize: 10,
                        groupBy: 'School'
                    }}
                    data={classes}
                    columns={classColumns} /> : null
        }</div>
    )
}

export default Classes