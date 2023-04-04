
import React, { useMemo } from "react";
import { Link } from "react-router-dom";
import { useTable, useSortBy, useGroupBy, useExpanded } from "react-table";
import './table.css'
import FilterListIcon from '@mui/icons-material/FilterList';
import FilterListOffIcon from '@mui/icons-material/FilterListOff';

function Table({ columns, data, onDelete }) {
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
                      {column.isGrouped ? <FilterListOffIcon /> : <FilterListIcon />}
                    </span>
                  ) : null}
                </div>
              </th>
            ))}
            <th className="headCell">Actions</th>
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
              <td className="tableRowCell">
                {row.subRows.length > 0 ?
                  null
                  :
                  (<React.Fragment>
                    <button onClick={() => onDelete(row.original)}>Delete</button>
                    <Link to={`${row.cells[0].value}`}>View</Link>
                  </React.Fragment>
                  )}
              </td>
            </tr>
          );
        })}
      </tbody>
    </table>
  );
}

export default Table;
