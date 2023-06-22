import React from 'react'
import { useStateContext } from '../contexts/UserContext';
import StudentProfile from '../components/profile/StudentProfile';
import TeacherProfile from '../components/profile/TeacherProfile';

const Profile = () => {
    const { currentUser } = useStateContext()
    return (
        currentUser !== null &&
        currentUser?.role === "Student" ? <StudentProfile /> :
            (currentUser?.role === "Teacher" || currentUser?.role === "Director") ? <TeacherProfile /> : ''
    );
}

export default Profile