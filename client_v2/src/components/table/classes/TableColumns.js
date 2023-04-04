class TableColumn {

    constructor(
        { header = '',
            name = '',
            width = '',
            sortable = false,
            hidden = false,
            primary = false }
    ) {
        this.header = header
        this.name = name
        this.width = width
        this.sortable = sortable
        this.hidden = hidden
        this.primary = primary
    }
}

export default TableColumn;