import React from 'react'
import { Link, useLoaderData } from 'react-router-dom'
import '../Styles/teacherviewclasses.css'


const TeacherViewClasses = () => {
    const data = useLoaderData()
    return (
        <div className='classbooks-container'>
            {data.map((classObj) => (
                <div key={classObj.id} className="class-card">
                    <p>Class: {classObj.name}</p>
                    <p>School: {classObj.school}</p>
                    <p>Specialization: {classObj.specialization}</p>
                    <p>Students Count: {classObj.studentsCount}</p>
                    <p>Homeroom Teacher: {classObj.homeroomTeacher}</p>
                    <Link to={`${classObj.id}/classbook/${classObj.classbookId}`} className="class-link">
                        Classbook
                    </Link>
                </div>
            ))}
        </div>
    )
}

export default TeacherViewClasses