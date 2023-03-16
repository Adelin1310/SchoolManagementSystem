import React, { useEffect, useState } from 'react'
import SortIcon from '@mui/icons-material/Sort';
import './table.css'
const Table = ({
    data,
    columns,
    options = {
        sortedBy: '',
        width: '',
        pageSize: 10
    }
}) => {
    const [d, setD] = useState(undefined)
    const [c, setC] = useState(columns)
    const [p, setP] = useState(0)
    useEffect(() => {
        setC(columns)
        if (options.sortedBy !== 'undefined') {
            let col = options.sortedBy.toLowerCase()
            let arr = data.sort((a, b) => a[col] - b[col])
            setD(arr)
        }

        let pagedarr = []
        let n = 0
        let j = 0
        for (let i = 0; i < Math.ceil(data.length / options.pageSize); i++) {
            pagedarr[i] = []
            n += (n + options.pageSize <= data.length ? options.pageSize : data.length - n)
            for (j; j < n; j++)
                pagedarr[i].push(data[j])
        }
        setD(pagedarr)
    }, [])

    const handlePageChange = (e) => {
        setP(e.target.value - 1)
    }
    return (
        <div className='TblContainer'>
            <table className='tableMain' width={options?.width !== undefined ? options?.width : '100%'}>
                <thead>
                    <tr className='headRow'>
                        {c?.map((col, idx) => (<td key={`col${idx}`} className='headCell'>{col.sortable === true ? <SortIcon style={{ margin: 'auto', verticalAlign: 'middle' }}>{col.header}</SortIcon> : <p>{col.header}</p>}</td>))}
                    </tr>
                </thead>
                <tbody>
                    {d !== undefined ? d[p]?.map((dt, idx) => (
                        <tr key={`row${idx}`}>
                            {c?.map((col, cidx) => (
                                <td width={col.width !== undefined ? col.width : null} className='tableRowCell' key={`row${idx}col${cidx}`}>
                                    {dt[col.name]}
                                </td>
                            ))}
                        </tr>
                    )) : null}
                </tbody>
            </table>
            {d !== undefined ?
                d.map((e, idx) => (<button key={`pgbtn${idx}`} className={p === idx ? 'pg-btn active' : 'pg-btn'} value={idx + 1} onClick={handlePageChange}>{idx + 1}</button>))
                : null}
        </div>
    )
}

export default Table