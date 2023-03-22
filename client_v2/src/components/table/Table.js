import React, { useEffect, useRef, useState } from 'react'
import SortIcon from '@mui/icons-material/Sort';
import './table.css'
import TableColumn from './classes/TableColumns';
import Options from './classes/Options';

const Table = ({ data }) => {
    const [tableHeight, setTableHeight] = useState(0);
    const [sortedData, setSortedData] = useState(data);
    const [sortDirection, setSortDirection] = useState('asc');
    const tableRef = useRef();

    useEffect(() => {
        const windowHeight = window.innerHeight;
        const tableOffsetTop = tableRef.current.offsetTop;
        const tableHeight = windowHeight - tableOffsetTop;
        setTableHeight(tableHeight);
    }, []);

    const handleSort = (column) => {
        let direction = 'asc';
        if (sortDirection === 'asc') {
            direction = 'desc';
        }
        setSortDirection(direction);

        const sorted = [...sortedData].sort((a, b) => {
            if (direction === 'asc') {
                return a[column] > b[column] ? 1 : -1;
            } else {
                return a[column] < b[column] ? 1 : -1;
            }
        });

        setSortedData(sorted);
    };

    return (
        <table>
            <thead>
                <tr>
                    <th onClick={() => handleSort('column1')}>Header 1</th>
                    <th onClick={() => handleSort('column2')}>Header 2</th>
                    <th onClick={() => handleSort('column3')}>Header 3</th>
                </tr>
            </thead>
            <tbody style={{ maxHeight: `${tableHeight}px`, overflowY: 'auto' }} ref={tableRef}>
                {sortedData.map((item) => (
                    <tr key={item.id}>
                        <td>{item.column1}</td>
                        <td>{item.column2}</td>
                        <td>{item.column3}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
}

export default Table