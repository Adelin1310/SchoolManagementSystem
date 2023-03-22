import React, { useEffect, useState } from 'react'
import SortIcon from '@mui/icons-material/Sort';
import './table.css'
import TableColumn from './classes/TableColumns';
import Options from './classes/Options';

const Table = ({
    data,
    columns = [new TableColumn()],
    options = new Options()
}) => {
    const [d, setD] = useState(undefined)
    const [grD, setGrD] = useState(undefined)
    const [c, setC] = useState(columns)
    useEffect(() => {
        setC(columns)

        if (options.sortedBy !== '') {
            let col = options.sortedBy.toLowerCase()
            let arr = data.sort((a, b) => a[col] - b[col])
            setD(arr)
        }

        if (options.groupBy !== undefined) {
            let groups = []
            for (let i = 0; i < data.length; i++)
                groups.push(data[i][options.groupBy.toLowerCase()])
            groups = [...new Set(groups)]
            groups = groups.sort()
            let newArr = []
            groups.forEach(g =>
                newArr.push({
                    group: g,
                    items: [],
                }))
            for (let j = 0; j < data.length; j++)
                newArr.find(e => e.group === data[j][options.groupBy.toLowerCase()]).items.push(data[j])
            setGrD(newArr)
        }

    }, [columns, data, options])

    
    return (
        <div className='TblContainer'>
            <table className='tableMain' width={options?.width !== undefined ? options?.width : '100%'}>
                <thead>
                    <tr className='headRow'>
                        {c?.map((col, idx) => options.groupBy !== undefined ? (
                            col.header.toLowerCase() !== options.groupBy.toLowerCase() ?
                                (<td
                                    key={`col${idx}`}
                                    width={col.width !== undefined ? col.width : null}
                                    className={
                                        col.hidden ? 'headCell hidden' :
                                            col.primary ? 'headCell primary' : 'headCell'}>
                                    {col.sortable === true ?
                                        <SortIcon style={{ margin: 'auto', verticalAlign: 'middle' }}>
                                            {col.header}
                                        </SortIcon>
                                        :
                                        <p>{col.header}</p>}
                                </td>) : null) : (
                            <td key={`col${idx}`}
                                width={col.width !== undefined ? col.width : null}
                                className={
                                    col.hidden ? 'headCell hidden' :
                                        col.primary ? 'headCell primary' : 'headCell'}>
                                {col.sortable === true ?
                                    <SortIcon style={{ margin: 'auto', verticalAlign: 'middle' }}>
                                        {col.header}
                                    </SortIcon>
                                    :
                                    <p>{col.header}</p>}
                            </td>
                        ))}
                    </tr>
                </thead>
                <tbody>
                    {d !== undefined ? grD === undefined ? d?.map((dt, idx) => (
                        <tr key={`row${idx}`}>
                            {c?.map((col, cidx) => (
                                <td
                                    width={col.width !== undefined ? col.width : null}
                                    className={
                                        col.hidden || col.header?.toLowerCase() === options.groupBy?.toLowerCase() ? 'tableRowCell hidden'
                                            : col.primary ? 'tableRowCell primary' : 'tableRowCell'}
                                    key={`row${idx}col${cidx}`}>
                                    {dt[col.name]}
                                </td>
                            ))}
                        </tr>
                    )) :
                        grD?.map((g, gidx) => (
                            <>
                                <tr className='groupRow' key={`row${gidx}`}>
                                    <td
                                        className='tableRowCell'
                                        colSpan="100%">{g.group}</td>
                                </tr>
                                {g.items.map((it, itidx) => (
                                    <tr key={`row${itidx}`}>
                                        {c?.map((col, cidx) => (
                                            <td
                                                width={col.width !== undefined ? col.width : null}
                                                className={
                                                    col.hidden || col.header?.toLowerCase() === options.groupBy.toLowerCase() ? 'tableRowCell hidden'
                                                        : col.primary ? 'tableRowCell primary' : 'tableRowCell'
                                                }
                                                key={`row${itidx}col${cidx}`}>
                                                {it[col.name]}
                                            </td>
                                        ))}
                                    </tr>
                                ))}
                            </>
                        ))
                        : null}
                </tbody>
            </table>
        </div>
    )
}

export default Table