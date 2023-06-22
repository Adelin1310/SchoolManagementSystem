import React, { useState } from "react";
import "./EditAbsenceModal.css";
import { motivateAbsence } from "../../../api/Absence";
const EditAbsenceModal = ({ absenceId, disableState }) => {
  const [error, setError] = useState("");

  const handleSubmit = async (event) => {
    event.preventDefault();
    const data = {
      id: absenceId,
    };
    try {
      const res = await motivateAbsence(data);
      if (res.success) disableState(false);
    } catch (err) {
      setError("An error occurred!");
    }
  };

  return (
    <div className="edit-absence-modal">
      <h2>Motivate absence</h2>
      <form onSubmit={handleSubmit}>
        {error}
        <button type="submit">Confirm</button>
      </form>
    </div>
  );
};

export default EditAbsenceModal;
