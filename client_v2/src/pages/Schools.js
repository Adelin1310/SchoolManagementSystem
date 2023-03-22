import React, { useEffect, useState } from 'react'
import { getAllSchools } from '../api/Schools'
import Table from '../components/table/Table'
import { schoolColumns } from '../data/TableColumns'

const Schools = () => {
  const [schools, setSchools] = useState(undefined)

  useEffect(() => {
    async function f() {
      let response = await getAllSchools()
      setSchools(response.data.data)
    }
    f()
  }, [])
  return (
    schools !== undefined ?
      <Table
        data={schools}
        columns={schoolColumns}
        options={{
          width: '100%',
          sortedBy: 'Id',
          pageSize: 10,
        }} /> : null
  )
}

export default Schools