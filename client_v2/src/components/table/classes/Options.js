class Options {
    constructor({
        sortedBy= '',
        width= '',
        pageSize= 10,
        groupBy= undefined
    }) {
        this.sortedBy = sortedBy
        this.width = width
        this.pageSize = pageSize
        this.groupBy = groupBy
    }
}

export default Options
