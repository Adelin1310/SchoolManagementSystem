import React from "react";
import Button from "../button/Button";
import './actions.css'

const Actions = () => {
  return (
    <div className="actions">
      <Button to="add" value={"ADD"} />
    </div>
  );
};

export default Actions;
