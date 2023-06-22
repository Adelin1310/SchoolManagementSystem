import React, { useEffect, useState } from 'react';
import { useLoaderData } from 'react-router-dom';
import { getStudentsSituation } from '../../api/Classbook';
import '../Styles/teacherviewclassbook.css';
import Modal from '../../components/modal/Modal';
import AddGradeModal from '../../components/modal/AddGradeModal/AddGradeModal';
import { endSituation } from '../../api/Situations';
import AddAbsenceModal from '../../components/modal/AddAbsenceModal/AddAbsenceModal';
import EditAbsenceModal from '../../components/modal/EditAbsenceModal/EditAbsenceModal';

const TeacherViewClassbook = () => {
  const { subjects, data } = useLoaderData();
  const [selectedSubject, setSelectedSubject] = useState(subjects[0].id);
  const [students, setStudents] = useState(data);
  const [selectedStudent, setSelectedStudent] = useState('')
  const [situationEndedSwitch, setSituationEndedSwitch] = useState(false)
  const [addGradeModal, setAddGradeModal] = useState(false)
  const [addAbsenceModal, setAddAbsenceModal] = useState(false)
  const [editAbsenceModal, setEditAbsenceModal] = useState(false)
  const [absenceId, setAbsenceId] = useState('')
  useEffect(() => {
    const fetchData = async () => {
      const res = await getStudentsSituation(selectedSubject, data.id, data.classId);
      setStudents(res);
    };
    fetchData();
  }, [selectedSubject, addGradeModal, situationEndedSwitch, addAbsenceModal, editAbsenceModal]);

  const handleEndSituation = async (studentId) => {
    try {
      const res = await endSituation({
        studentId, classbookId: data.id, subjectId: selectedSubject,
      })
      if (res.success) {
        setSituationEndedSwitch(!situationEndedSwitch)
      }
    } catch (err) {
      alert("An internal error ocurred!");
    }
  }
  const handleSubjectChange = (event) => {
    setSelectedSubject(event.target.value);
  };

  return (
    <div className='main-container'>
      <div className='subject-select'>
        <select value={selectedSubject} onChange={handleSubjectChange}>
          {subjects.map((subject) => (
            <option key={subject.id} value={subject.id}>
              {subject.name}
            </option>
          ))}
        </select>
      </div>

      <div className='classbook-container'>
        <div className='student-container head-row'>
          <div className='student-name'>Name</div>
          <div className='student-grades'>Grades</div>
          <div className='student-absences'>Absences</div>
          <div className='student-situations'>Situation</div>
        </div>

        {students.students.map((s) => (
          <div className='student-container' key={s.id}>
            <div className='student-name'>{s.firstName} {s.lastName}</div>
            <div className='student-grades'>
              {s.grades.map((g, index) => (
                <div className='student-grade' key={index}>{g.value} | {g.date}</div>
              ))}
              {!s.isEnded && <button className='add-grade' onClick={() => {
                setSelectedStudent(s.id)
                setAddGradeModal(!addGradeModal)
              }}>+</button>}
              {!s.isEnded && <button className={`end-situation${s.canEnd ? ' active-btn' : ' inactive-btn'}`} onClick={async () => await handleEndSituation(s.id)}>✓</button>}
            </div>
            <div className='student-absences'>
              {s.absences.map((a, index) => (
                <div className={`student-absence${a.withLeave ? ' wLeave' : ''}${students.isHomeroomTeacher ? ' hteacher' : ''}`}
                  key={index}
                  onClick={() => {
                    if (students.isHomeroomTeacher) {
                      setAbsenceId(a.id)
                      setEditAbsenceModal(!editAbsenceModal)
                    }
                  }}>{a.date}</div>
              ))}
              {!s.isEnded && <button className={`add-absence`} onClick={() => {
                setSelectedStudent(s.id)
                setAddAbsenceModal(!addAbsenceModal)
              }}>+</button>}
            </div>
            <div className='student-situations'>
              {
                <div className={`student-situation`}>{s.isEnded ? s.situation : ''}</div>
              }
            </div>
          </div>
        ))}
        {
          addGradeModal &&
          <Modal
            initial={true}
            component={<AddGradeModal disableState={setAddGradeModal} classbookId={data.id} studentId={selectedStudent} subjectId={selectedSubject} />}
            disableState={setAddGradeModal} />}
        {
          addAbsenceModal &&
          <Modal
            initial={true}
            component={<AddAbsenceModal disableState={setAddAbsenceModal} classbookId={data.id} studentId={selectedStudent} subjectId={selectedSubject} />}
            disableState={setAddAbsenceModal} />
        }
        {
          editAbsenceModal &&
          <Modal
            initial={true}
            component={<EditAbsenceModal absenceId={absenceId} disableState={setEditAbsenceModal} />}
            disableState={setEditAbsenceModal} />
        }
      </div>
    </div>
  );
};

export default TeacherViewClassbook;
