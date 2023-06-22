import React, { useEffect, useState } from "react";
import { getProfile } from "../../api/Auth";
import "./profile.css";
import LoadingSpinner from "../loading/LoadingSpinner";

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
  return currentUser !== null ? (
    <div className="profile-container flex-col">
      <h2 className="profile-container-header">Student Information</h2>
      <div className="profile-container-details">
        <div className="profile-details-group">
          <div className="profile-details-group-header">Personal Details</div>
          <div className="profile-details-group-content">
            <p>
              <strong>Name: </strong>
              {`${currentUser.firstName} ${currentUser.lastName}`}
            </p>
            <p>
              <strong>Date of Birth: </strong> {currentUser.dateOfBirth}
            </p>
            <p>
              <strong>Email: </strong> {currentUser.email}
            </p>
            <p>
              <strong>Addresss: </strong> {currentUser.address}
            </p>
          </div>
        </div>
        <div className="profile-details-group">
          <div className="profile-details-group-header">Class Details</div>
          <div className="profile-details-group-content">
            {Object.keys(currentUser.class).map((k) => (
              <p key={k}>
                <strong>
                  {k[0].toUpperCase()}
                  {k
                    .slice(1)
                    .split(/(?=[A-Z])/)
                    .map((p) => p + " ")}
                  :{" "}
                </strong>{" "}
                {currentUser.class[k]}
              </p>
            ))}
          </div>
        </div>
        <div className="profile-details-group">
          <div className="profile-details-group-header">Parents Details</div>
          <div className="profile-details-group-content">
            {Object.keys(currentUser.parentsInfo).map((k) => (
              <p key={k}>
                <strong>
                  {k[0].toUpperCase()}
                  {k
                    .slice(1)
                    .split(/(?=[A-Z])/)
                    .map((p) => p + " ")}
                  :{" "}
                </strong>{" "}
                {currentUser.parentsInfo[k]}
              </p>
            ))}
          </div>
        </div>
        <div className="profile-details-group">
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
    <LoadingSpinner />
  );
};

export default StudentProfile;
