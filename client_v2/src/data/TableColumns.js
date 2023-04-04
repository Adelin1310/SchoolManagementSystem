
export const schoolColumns = [
    {
        Header: 'ID',
        accessor: 'id',

    },

    {
        Header: 'Name',
        accessor: 'name'
    }]

export const classColumns = [

    {
        Header: 'ID',
        accessor: "id",
    },

    {
        Header: 'Name',
        accessor: "name",
    },
    {
        Header: 'School',
        accessor: "school"
    },
    {
        Header: 'School ID',
        accessor: "schoolId",
    }
]

export const studentColumns = [
    {
        Header:'ID',
        accessor:'id'
    },
    {
        Header:'   ',
        accessor:'photo',
        Cell: ({value})=>(<img style={{width:'64px', borderRadius:'50%'}} alt='' src={`${value}`}/>),
        disableGroupBy: true

    },
    {
        Header:'Full Name',
        accessor:'fullName'
    },
    {
        Header:'First Name',
        accessor:'firstName'
    },
    {
        Header:'LastName',
        accessor:'lastName'
    },
    {
        Header:'Address',
        accessor:'address'
    },
    {
        Header:'Class',
        accessor:'class'
    },
    {
        Header:'School',
        accessor:'school'
    },
    
]

export const teachersColumns = [
    {
        Header:'ID',
        accessor:'id',
    },
    {
        Header:'Full Name',
        accessor:'fullName',
    },
    {
        Header:'First Name',
        accessor:'firstName',
    },
    {
        Header:'Last Name',
        accessor:'lastName',
    },
    {
        Header:'Address',
        accessor:'address',
    },
    {
        Header:'Age',
        accessor:'age',
    },
    {
        Header:'Schools',
        accessor:'schools',
        Cell: ({value})=>value.map(v=><p className="school">{v}</p>),
    },
    {
        Header:'Subjects',
        accessor:'subjects',
        Cell: ({value})=>value.map(v=><p className="subject">{v}</p>),
    },
]
export const subjectsColumns = [
    {
        Header:'ID',
        accessor:'id',
    },
    {
        Header:'Name',
        accessor:'name',
    },
]