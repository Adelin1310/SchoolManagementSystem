import React, { useEffect, useState } from 'react'
import './table.css'
const Table = ({ data, columns, options }) => {
    const [d, setD] = useState(data)
    const [c, setC] = useState(columns)

    useEffect(() => {
        setC(columns)
        setD(data)
    }, [data, columns])

    return (
        <div className='TblContainer'>
            <table className='tableMain' width={options?.width !== undefined ? options?.width : '100%'}>
                <thead>
                    <tr className='headRow'>
                        {c.map((col, idx) => (<td key={`col${idx}`} className='headCell'>{col.header}</td>))}
                    </tr>
                </thead>
                <tbody>
                    {d.map((d, idx) => (
                        <tr key={`row${idx}`}>
                            {c.map((col, cidx) => (
                                <td width={col.width !== undefined ? col.width : null} className='tableRowCell' key={`row${idx}col${cidx}`}>
                                    {d[col.name]}
                                </td>
                            ))}
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )
}

export default Table