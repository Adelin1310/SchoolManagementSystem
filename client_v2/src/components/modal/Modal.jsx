import React, { useState } from "react";
import "./modal.css";

const Modal = ({ initial, isCloseable = true, component, disableState }) => {
  const [isOpened, setIsOpened] = useState(initial);
  const handleOutsideClick = () => {
    disableState(false);
    setIsOpened(false);
  };
  return (
    <div
      className={`background-frame${!isOpened ? " hidden" : ""}`}
    >
      <div className="modal-frame">
        {component}
        <div className="modal-close-btn" onClick={()=>handleOutsideClick()}>X</div>
        </div>
    </div>
  );
};

export default Modal;
