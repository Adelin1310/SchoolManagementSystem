import React from 'react'
import { Link } from 'react-router-dom'
import './button.css'

const Button = ({ to, value }) => {
  return (
    <div className='action-btn'>
      <Link to={to}>{value}</Link>
    </div>
  )
}

export default Button