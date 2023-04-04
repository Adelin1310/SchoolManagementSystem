import React, { useEffect, useState } from 'react'
import { getAllSchools } from '../api/Schools'
import Actions from '../components/actions/Actions'
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
    <div>
      <Actions />
      {schools !== undefined ?
        <Table
          data={schools}
          columns={schoolColumns}
        /> : null}
    </div>
  )
}

export default Schools