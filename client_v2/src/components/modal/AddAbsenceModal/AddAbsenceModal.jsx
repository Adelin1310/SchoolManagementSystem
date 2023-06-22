import React, { useState } from "react";
import "./AddAbsenceModal.css";
import { addAbsence } from "../../../api/Absence";
const AddAbsenceModal = ({ studentId, subjectId, classbookId, disableState }) => {
  const [absenceDate, setAbsenceDate] = useState("");
  const [warning, setWarning] = useState("");
  const [error, setError] = useState("")

  const handleGradeDateChange = (event) => {
    let date = new Date(event.target.value);
    if (date.getUTCDay() >= 1 && date.getUTCDay() <= 5) {
      setAbsenceDate(event.target.value);
      setWarning("");
    } else
      setWarning(
        <div className="warning">You can't add grades on weekend days!</div>
      );
  };

  const handleSubmit =async (event) => {
    event.preventDefault();
    const data = {
      studentId,
      subjectId,
      classbookId,
      date:absenceDate,
    };
    try{
      const res = await addAbsence(data)
      if (res.success)
        disableState(false)
    }
    catch(err){
      setError("An error occurred!")
    }
  };

  return (
    <div className="add-grade-modal">
      <h2>Add Absence</h2>
      <form onSubmit={handleSubmit}>
        <input readOnly hidden value={studentId} name="studentId" />
        <input readOnly hidden value={classbookId} name="classbookId" />
        <input readOnly hidden value={subjectId} name="subjectId" />
        <div>
          <label htmlFor="gradeDate">Absence Date:</label>
          <input
            name="date"
            type="date"
            id="gradeDate"
            value={absenceDate}
            onChange={handleGradeDateChange}
            required
          />
          {warning}
        </div>
        {error}
        <button type="submit">Add</button>
      </form>
    </div>
  );
};

export default AddAbsenceModal;
