import TableColumn from "../components/table/classes/TableColumns"

export const schoolColumns = [
    new TableColumn({
        header: 'ID',
        name: 'id',
        width: '30px !important',
    }),
    new TableColumn(
        {
            header: 'Name',
            name: 'name'
        })]

export const classColumns = [
    new TableColumn(
        {
            header: 'ID',
            name: "id",
            width: '30px !important',
        }),
    new TableColumn(
        {
            header: 'Name',
            name: "name",
            width: '200px'
        }),
    new TableColumn({
        header: 'School',
        name: "school"
    }),
    new TableColumn({
        header: 'School ID',
        name: "schoolId",
        width: '100px',
        hidden: true,
    })
]