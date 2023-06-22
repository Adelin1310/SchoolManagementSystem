import React from 'react';
import './notfound.css';

const NotFound = () => {
  return (
    <div className="not-found">
      <h1 className='error-title'>404 Error</h1>
      <p className="message">Sorry, the page you are looking for could not be found.</p>
    </div>
  );
}

export default NotFound;
