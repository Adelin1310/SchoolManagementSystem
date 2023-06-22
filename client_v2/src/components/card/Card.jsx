import React from 'react';
import './Card.css';
import { Link } from 'react-router-dom';

const Card = ({ name, target }) => {
  return (
    <div className="card">
      <h2>{name}</h2>
      <Link to={target} className="card-button">Visit</Link>
    </div>
  );
};

export default Card;
