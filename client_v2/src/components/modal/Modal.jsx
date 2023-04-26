import React, { useState } from "react";
import "./modal.css";

const Modal = ({ children, initial, isCloseable = true, component }) => {
  const [isOpened, setIsOpened] = useState(initial);
  const closeable = isCloseable;
  return (
    <div
      className={`background-frame${!isOpened ? " hidden" : ''}`}
      onClick={() => (closeable ? setIsOpened(!isOpened) : null)}
    >
      <div className="modal-frame">{component}</div>
    </div>
  );
};

export default Modal;
