
import React, { useMemo } from "react";
import { Link, json } from "react-router-dom";
import { useTable, useSortBy, useGroupBy, useExpanded } from "react-table";
import './table.css'
import FilterListIcon from '@mui/icons-material/FilterList';
import FilterListOffIcon from '@mui/icons-material/FilterListOff';

function Table({ columns, data, allowedActions = [] }) {
  const memoizedColumns = useMemo(() => columns, [columns]);
  const memoizedData = useMemo(() => data, [data]);
  const tableMaxHeight = window.screen.availHeight * .65;

  const tableInstance = useTable(
    { columns: memoizedColumns, data: memoizedData },
    useGroupBy,
    useSortBy,
    useExpanded
  );
  const { getTableProps, getTableBodyProps, headerGroups, rows, prepareRow } = tableInstance;

  const handleActionType = (action, row) => action.type === "View" ? (<Link className="view-link" to={`${row.cells[0].value}`}>View</Link>) :
    action.type === "Delete" ? (<button onClick={() => action.event(row.original)}>Delete</button>) : null

  return (
    <table className="tableMain" {...getTableProps()}>
      <thead>
        {headerGroups.map((headerGroup) => (
          <tr className="headRow" {...headerGroup.getHeaderGroupProps()}>
            {headerGroup.headers.map((column) => (
              <th className="headCell" {...column.getHeaderProps(column.getSortByToggleProps())}>
                <div className="flexHeader">
                  {column.render("Header")}
                  <span>{column.isSorted ? (column.isSortedDesc ? " 🔽" : " 🔼") : ""}</span>
                  {column.canGroupBy ? (
                    <span {...column.getGroupByToggleProps()}>
                      {column.isGrouped ? <FilterListOffIcon className="filterIcon" /> : <FilterListIcon className="filterIcon" />}
                    </span>
                  ) : null}
                </div>
              </th>
            ))}
            {allowedActions.length !== 0 && <th className="headCell">Actions</th>}
          </tr>
        ))}
      </thead>
      <tbody style={{ maxHeight: `${tableMaxHeight}px` }} {...getTableBodyProps()}>
        {rows.map((row) => {
          prepareRow(row);
          return (
            <tr className={row.subRows.length > 0 ? "groupRow" : null} {...row.getRowProps()}>
              {row.cells.map((cell) => (
                <td className={"tableRowCell"} {...cell.getCellProps()}>
                  {cell.isGrouped ? (
                    <>
                      <span {...row.getToggleRowExpandedProps()}>
                        {row.isExpanded ? '👇' : '👉'}
                      </span>{' '}
                      {cell.render('Cell')} ({row.subRows.length})
                    </>
                  ) : cell.isAggregated ? (
                    cell.render('Aggregated')
                  ) : cell.isPlaceholder ? null : (
                    cell.render('Cell')
                  )}
                </td>
              ))}
              {
                allowedActions.length > 0 ?
                  (
                    <td className="tableRowCell">
                      {row.subRows.length > 0 ?
                        null
                        :
                        (
                          allowedActions.map((act =>
                            <React.Fragment>
                              {handleActionType(act, row)}
                            </React.Fragment>))
                        )
                      }
                    </td>
                  ) : null
              }
            </tr>
          );
        })}
      </tbody>
    </table>
  );
}

export default Table;
