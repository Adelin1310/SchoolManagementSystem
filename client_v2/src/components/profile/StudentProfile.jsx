import React, { useEffect, useState } from "react";
import { useStateContext } from "../../contexts/UserContext";
import { getProfile } from "../../api/Auth";
import "./studentprofile.css";

const StudentProfile = () => {
  const [currentUser, setCurrentUser] = useState(null);
  useEffect(() => {
    try {
      const getUserProfile = async () => {
        const res = await getProfile("Student");
        if (res.success) {
          setCurrentUser(res.data);
        } else setCurrentUser(null);
      };
      getUserProfile();
    } catch (err) {
      console.log(err);
    }
  }, []);
  return (
    <div>
      {currentUser !== null ? (
        <div className="profile-container flex-col">
          <h2 className="profile-container-header">Student Information</h2>
          <div className="profile-container-details">
            <div className="profile-details-group">
              <div className="profile-details-group-header">
                Personal Details
              </div>
              <div className="profile-details-group-content">
                <p>
                  <strong>Name:</strong>{" "}
                  {`${currentUser.firstName} ${currentUser.lastName}`}
                </p>
                <p>
                  <strong>Email:</strong> {currentUser.email}
                </p>
                <p>
                  <strong>Addresss:</strong> {currentUser.address}
                </p>
              </div>
            </div>
            <div className="profile-details-group">
              <div className="profile-details-group-header">School Details</div>
              <div className="profile-details-group-content">
                <p>
                  <strong>Class:</strong> {currentUser.class}
                </p>
                <p>
                  <strong>School:</strong> {currentUser.school}
                </p>
              </div>
            </div>
          </div>
          <div className="profile-container-details">
            <div className="profile-details-group fullw">
              <div className="profile-details-group-header">Situation</div>
              <div className="profile-details-group-content">
                <p>
                  <strong>Absences:</strong>{" "}
                  {currentUser.absences ? currentUser.absences : 0}
                </p>
                <p>
                  <strong>Latest Grades</strong>
                </p>
                <ul>
                  {currentUser.latestGrades?.map((grade, index) => (
                    <li key={index}>
                      <p>
                        <strong>Subject:</strong> {grade.subject}
                      </p>
                      <p>
                        <strong>Grade:</strong> {grade.grade}
                      </p>
                      <p>
                        <strong>Date:</strong> {grade.date}
                      </p>
                    </li>
                  ))}
                </ul>
              </div>
            </div>
          </div>
        </div>
      ) : (
        <p>Loading...</p>
      )}
    </div>
  );
};

export default StudentProfile;
