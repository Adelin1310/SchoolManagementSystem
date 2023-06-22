import React, { useState } from "react";
import "./AddGradeModal.css";
import { addGrade } from "../../../api/Grade";
const AddGradeModal = ({ studentId, subjectId, classbookId, disableState }) => {
  const [gradeValue, setGradeValue] = useState("");
  const [gradeDate, setGradeDate] = useState("");
  const [warning, setWarning] = useState("");
  const [error, setError] = useState("")
  const handleGradeValueChange = (event) => {
    const value = event.target.value;

    if (value >= 10) setGradeValue(10);
    else if (value < 1) setGradeValue("");
    else if (isNaN(parseInt(value))) setGradeValue("");
    else setGradeValue(parseInt(event.target.value));
  };

  const handleGradeDateChange = (event) => {
    let date = new Date(event.target.value);
    if (date.getUTCDay() >= 1 && date.getUTCDay() <= 5) {
      setGradeDate(event.target.value);
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
      date:gradeDate,
      value:gradeValue
    };
    try{
      const res = await addGrade(data)
      if (res.success)
        disableState(false)
    }
    catch(err){
      setError("An error occurred!")
    }
  };

  return (
    <div className="add-grade-modal">
      <h2>Add Grade</h2>
      <form onSubmit={handleSubmit}>
        <input readOnly hidden value={studentId} name="studentId" />
        <input readOnly hidden value={classbookId} name="classbookId" />
        <input readOnly hidden value={subjectId} name="subjectId" />
        <div>
          <label htmlFor="gradeValue">Grade Value:</label>
          <input
            type="number"
            id="gradeValue"
            name="value"
            value={gradeValue}
            onChange={handleGradeValueChange}
            min="1"
            max="10"
            required
          />
        </div>
        <div>
          <label htmlFor="gradeDate">Grade Date:</label>
          <input
            name="date"
            type="date"
            id="gradeDate"
            value={gradeDate}
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

export default AddGradeModal;
