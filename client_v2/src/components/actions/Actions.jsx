import React from "react";
import './actions.css'
import Button from "../buttons/Button";

const Actions = () => {
  return (
    <div className="actions">
      <Button to="add" value={"ADD"} />
    </div>
  );
};

export default Actions;
