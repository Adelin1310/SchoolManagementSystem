import React, { useState } from 'react';

function Register() {
  const [formValues, setFormValues] = useState({
    School: '',
    Principal: '',
    TotalStudentsNumber: '',
    ContactEmail: '',
    ContactPhone: ''
  });

  const handleSubmit = (event) => {
    event.preventDefault();
    console.log(formValues);
  };

  const handleChange = (event) => {
    setFormValues({ ...formValues, [event.target.name]: event.target.value });
  };

  return (
    <div className="register-page">
      <h2 className="register-title">Register</h2>
      <form onSubmit={handleSubmit} className="register-form">
        <div className="form-group">
          <label htmlFor="school-input">School</label>
          <input
            type="text"
            id="school-input"
            name="School"
            value={formValues.School}
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label htmlFor="principal-input">Principal</label>
          <input
            type="text"
            id="principal-input"
            name="Principal"
            value={formValues.Principal}
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label htmlFor="total-students-input">Total Students Number</label>
          <input
            type="number"
            id="total-students-input"
            name="TotalStudentsNumber"
            value={formValues.TotalStudentsNumber}
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label htmlFor="email-input">Contact Email</label>
          <input
            type="email"
            id="email-input"
            name="ContactEmail"
            value={formValues.ContactEmail}
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label htmlFor="phone-input">Contact Phone</label>
          <input
            type="tel"
            id="phone-input"
            name="ContactPhone"
            value={formValues.ContactPhone}
            onChange={handleChange}
          />
        </div>
        <button type="submit" className="register-button">
          Register
        </button>
      </form>
    </div>
  );
}

export default Register;
