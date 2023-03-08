import React from 'react'

const Table = ({ data, columns }) => {
    return (
        <div className='TblContainer'>
            <table className='tableMain'>
                <thead>
                    <tr className='headRow'>
                        {columns.map((col, idx) => (<td key={`col${idx}`} className='headCell'>{col}</td>))}
                    </tr>
                </thead>
                <tbody>
                    {data.map((d, idx) => (
                        <tr key={`row${idx}`}>
                            {columns.map((col, cidx) => (
                                <td key={`row${idx}col${cidx}`}>
                                    {d[col]}
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