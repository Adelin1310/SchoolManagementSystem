import { Link } from "react-router-dom";

export const schoolColumns = [
  { field: "id", headerName: "ID", width: 70 },
  {
    field: "name",
    headerName: "Name",
    width: 350
  },
];

export const studentColumns = [
  { field: 'id', headerName: "ID", width: 70 },
  {
    field: 'photo', headerName: '', width: 100,
    renderCell: (params) => (
      <img src={`${params.value}`} alt="" className="image" />
    )
  },
  {
    field: 'fullName', headerName: 'Full Name', width: 140,
  },
  { field: 'class', headerName: 'Class', width: 70 },
  {
    field: 'school', headerName: 'School', width: 350
  }
]
export const classColumns = [
  { field: 'id', headerName: "ID", width: 70 },
  { field: 'name', headerName: 'Name', width: 70 },
  {
    field: 'school', headerName: 'School', width: 350
  },
  {
    field: 'schoolId', headerName: 'School Actions', width: 200,
    renderCell: (params) => (
      <div className="cellAction">
        <Link to={`/schools/${params.value}`} style={{ textDecoration: "none" }}>
          <div className="viewButton">Access School</div>
        </Link>
      </div>
    )
  }
]
export const classbookColumns = [
  { field: 'id', headerName: "ID", width: 70 },
  { field: 'class', headerName: 'Class', width: 70 },
  {
    field: 'classId', headerName: 'Class Actions', width: 150,
    renderCell: (params) => (
      <div className="cellAction">
        <Link to={`/classes/${params.value}`} style={{ textDecoration: "none" }}>
          <div className="viewButton">Access Class</div>
        </Link>
      </div>
    )
  },
  { field: 'studentsCount', headerName: "Students Count", width: 150 },
  { field: 'school', headerName: "School", width: 300 }
]
export const teacherColumns = [
  { field: 'id', headerName: "ID", width: 70 },
  {
    field: 'fullName', headerName: 'Full Name', width: 140
  },
  {
    field: 'subjects', headerName: "Subjects", width: 300,
    renderCell: (params) => (
      params.value.map((subject, idx) => (
        <div key={idx} className="cellAction">
          <span key={idx} className="badge">{subject}</span>
        </div>
      )))
  },
  {
    field: 'schools', headerName: "Schools", width: 300,
    renderCell: (params) => (
      params.value.map((school, idx) => (
        <div key={idx} className="cellAction">
          <span key={idx} className="badge">{school}</span>
        </div>
      )))
  }
]
export const subjectColumns = [
  { field: 'id', headerName: 'ID', width: 70 },
  { field: 'name', headerName: 'Name', width: 150 },
]

/*
      "id": 0,
      "fullName": "string",
      "firstName": "string",
      "lastName": "string",
      "address": "string",
      "classId": 0,
      "schoolId": 0,
      "school": "string"
    }
*/