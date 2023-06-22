import React from 'react'
import { useLoaderData } from 'react-router-dom'

const StudentViewClassbook = () => {
    const data = useLoaderData();
    console.log(data)
    return (
        <div className='main-container'>
            
            <div className='classbook-container'>
                <div className='student-container head-row'>
                    <div className='student-name'>Subject</div>
                    <div className='student-grades'>Grades</div>
                    <div className='student-absences'>Absences</div>
                    <div className='student-situations'>Situation</div>
                </div>

                {data.map((s) => (
                    <div className='student-container' key={s.subject}>
                        <div className='student-name'>{s.subject}</div>
                        <div className='student-grades'>
                            {s.grades.map((g, index) => (
                                <div className='student-grade' key={index}>{g.value} | {g.date}</div>
                            ))}</div>
                        <div className='student-absences'>
                            {s.absences.map((a, index) => (
                                <div className={`student-absence${a.withLeave ? ' wLeave' : ''}`}
                                    key={index}>{a.date}</div>
                            ))}

                        </div>
                        <div className='student-situations'>
                            {
                                <div className={`student-situation`}>{s.situation}</div>
                            }
                        </div>
                    </div>
                ))}

            </div>
        </div>
    )
}

export default StudentViewClassbook