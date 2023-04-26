import React, { useEffect, useState } from 'react'
import Actions from '../components/actions/Actions'
import Table from '../components/table/Table'
import { schoolColumns } from '../data/TableColumns'
import { useLoaderData } from 'react-router-dom'

const Schools = () => {
  const schools = useLoaderData();

  return (
    <div>
      {schools !== undefined ?
        <React.Fragment>
          <Actions />
          <Table
            data={schools}
            columns={schoolColumns}
          />
        </React.Fragment>
        : null}
    </div>
  )
}

export default Schools