import React, { useEffect, useState } from "react";
import { getProfile } from "../../api/Auth";
import "./profile.css";

const TeacherProfile = () => {
  const [currentUser, setCurrentUser] = useState(null);
  useEffect(() => {
    try {
      const getUserProfile = async () => {
        const res = await getProfile("Teacher");
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
          <h2 className="profile-container-header">Teacher Information</h2>
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
                  <strong>Address:</strong> {currentUser.address}
                </p>
                <p>
                  <strong>Subjects:</strong> {currentUser.subjects.join(", ")}
                </p>
              </div>
            </div>
            <div className="profile-details-group">
              <div className="profile-details-group-header">Schools Taught</div>
              <div className="profile-details-group-content">
                {currentUser.schoolsTaught.map((school, index) => (
                  <div className="profile-details-group fullw" key={index}>
                    <p>
                      <strong>School:</strong> {school.name}
                    </p>
                    <p>
                      <strong>Classes:</strong> {school.classes.join(", ")}
                    </p>
                  </div>
                ))}
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

export default TeacherProfile;
