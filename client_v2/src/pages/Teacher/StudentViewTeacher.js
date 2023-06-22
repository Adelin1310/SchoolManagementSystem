import React from 'react';
import { ProfilePageColumns, TeacherClassesSubjectsColumns } from '../../data/TableColumns';
import Table from '../../components/table/Table';
import '../Styles/studentviewteacher.css';
import { useLoaderData } from 'react-router-dom';

const StudentViewTeacher = () => {
  const dataColumns = TeacherClassesSubjectsColumns;
  const data = useLoaderData()
  return (
    <div className="student-view-teacher-profile-container">
      <div className="teacher-profile-header">
        <h2 className="teacher-profile-header-text">Teacher Profile</h2>
      </div>
      <div className="teacher-profile-details">
        <h2 className="teacher-profile-details-header">{data.data.fullName}</h2>
        <p className="teacher-profile-details-text">{data.data.address}</p>
      </div>
      <div className="teacher-profile-classes">
        <h2 className="teacher-profile-classes-header">Classes</h2>
        <Table columns={dataColumns} data={data.data.classes} />
      </div>
      <div className="teacher-profile-subjects">
        <h2 className="teacher-profile-subjects-header">Subjects</h2>
        <ul className="teacher-profile-subjects-list">
          {data.data.subjects.map((subject, index) => (
            <li key={index} className="teacher-profile-subjects-item">
              {subject}
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default StudentViewTeacher;
