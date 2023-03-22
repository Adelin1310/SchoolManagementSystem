import React from 'react'
import { Link } from 'react-router-dom'
import './button.css'

const Button = ({to, value}) => {
  return (
    <Link className='btn' to={to}>{value}</Link>
    )
}

export default Button