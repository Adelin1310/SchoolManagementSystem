import React from 'react';
import './unauthorized.css'

const Unauthorized = () => {
  return (
    <div className="unauthorized">
      <h2>Error 401: Unauthorized</h2>
      <p>You do not have permission to access this page.</p>
    </div>
  );
}

export default Unauthorized;
