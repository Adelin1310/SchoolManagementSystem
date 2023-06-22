import React, { useEffect } from 'react';
import './unauthorized.css'

const Unauthorized = () => {

  useEffect(() => {
    const redirectTimeout = setTimeout(() => {
      window.location.href = '/app/login';
    }, 2000);

    return () => {
      clearTimeout(redirectTimeout);
    };
  }, [])
  return (
    <div className="unauthorized">
      <h2>Error 401: Unauthorized</h2>
      <p>You do not have permission to access this page.</p>
    </div>
  );
}

export default Unauthorized;
