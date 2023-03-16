import './navbar.css'
import React from 'react'
import SchoolIcon from '@mui/icons-material/School';
import ClassIcon from '@mui/icons-material/Class';
import FaceIcon from '@mui/icons-material/Face';
import LocalLibraryIcon from '@mui/icons-material/LocalLibrary';
import LibraryBooksIcon from '@mui/icons-material/LibraryBooks';
import LogoutIcon from '@mui/icons-material/Logout';
import { Link } from 'react-router-dom'

const Navbar = () => {
  return (
    <div className='container'>
      <p className='logo'>LOGO</p>
      <hr />
      <ul className='navmenu'>
        <li><Link to={`schools`}><SchoolIcon className='icon' />SCHOOLS</Link> </li>
        <li><Link to={`classes`}><ClassIcon className='icon' />CLASSES</Link></li>
        <li><Link to={`schools`}><FaceIcon className='icon' />STUDENTS</Link></li>
        <li><Link to={`schools`}><LocalLibraryIcon className='icon' />TEACHERS</Link></li>
        <li><Link to={`schools`}><LibraryBooksIcon className='icon' />SUBJECTS</Link></li>
        <li><Link to={`schools`}><LogoutIcon className='icon' />LOG OUT</Link></li>
      </ul>
    </div>
  )
}

export default Navbar