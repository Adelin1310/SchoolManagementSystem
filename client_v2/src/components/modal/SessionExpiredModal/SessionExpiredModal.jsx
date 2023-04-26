import React from "react";

const SessionExpiredModal = () => {
  return (
    <div className="modal-content">
      <div className="modal-text-group">
        <div className="modal-text large">
          Current user session has expired.
        </div>
        <div className="modal-text small">You have to log in again.</div>
      </div>
      <button className="modal-btn medium">Log In</button>
    </div>
  );
};

export default SessionExpiredModal;
