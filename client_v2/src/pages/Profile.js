import React from 'react'
import { useStateContext } from '../contexts/UserContext';
import StudentProfile from '../components/profile/StudentProfile';

const Profile = () => {
    const { currentUser } = useStateContext()
    return (
        <div>
            {
                currentUser.role === "Student" ? <StudentProfile /> : ''
            }
        </div>
    );
}

export default Profile