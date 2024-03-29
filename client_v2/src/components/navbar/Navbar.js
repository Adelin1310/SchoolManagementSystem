import './navbar.css'
import React, { useEffect, useState } from 'react'
import SchoolIcon from '@mui/icons-material/School';
import ClassIcon from '@mui/icons-material/Class';
import FaceIcon from '@mui/icons-material/Face';
import LocalLibraryIcon from '@mui/icons-material/LocalLibrary';
import LibraryBooksIcon from '@mui/icons-material/LibraryBooks';
import DarkModeIcon from '@mui/icons-material/DarkMode';
import LightModeIcon from '@mui/icons-material/LightMode';
import ToggleOffIcon from '@mui/icons-material/ToggleOff';
import ToggleOnIcon from '@mui/icons-material/ToggleOn';
import LogoutIcon from '@mui/icons-material/Logout';
import { Link } from 'react-router-dom'

const Navbar = ({ sideMenuState, changeTheme }) => {
  const [internalSideMenuState, setInternalSideMenuState] = useState(sideMenuState)
  const [toggleState, setToggleState] = useState(false)
  const [active, setActive] = useState(undefined)

  const toggle = () => {
    setToggleState(!toggleState)
    changeTheme();
  }

  useEffect(() => {
    setInternalSideMenuState(sideMenuState)
    console.log(sideMenuState)
  }, [sideMenuState])
  return (
    <div className={internalSideMenuState ? 'container' : 'container hide'}>
      <Link to={'/'} onClick={()=>{setActive(undefined)}} className='logo'>LOGO</Link>
      <ul className='navmenu'>
        <li><Link className={active === 'schools' ? 'active' : null} to={`schools`} onClick={() => { setActive('schools') }}><SchoolIcon className='icon' />SCHOOLS</Link> </li>
        <li><Link className={active === 'classes' ? 'active' : null} to={`classes`} onClick={() => { setActive('classes') }}><ClassIcon className='icon' />CLASSES</Link></li>
        <li><Link className={active === 'students' ? 'active' : null} to={`students`} onClick={() => { setActive('students') }}><FaceIcon className='icon' />STUDENTS</Link></li>
        <li><Link className={active === 'teachers' ? 'active' : null} to={`teachers`} onClick={() => { setActive('teachers') }}><LocalLibraryIcon className='icon' />TEACHERS</Link></li>
        <li><Link className={active === 'subjects' ? 'active' : null} to={`subjects`} onClick={() => { setActive('subjects') }}><LibraryBooksIcon className='icon' />SUBJECTS</Link></li>
        <li><Link to={`schools`}><LogoutIcon className='icon' />LOG OUT</Link></li>

      </ul>
      <div className='themeBtns'>
        <DarkModeIcon style={{ width: '35px', height: '35px' }} className='icon' />
        {
          toggleState ?
            <ToggleOffIcon style={{ width: '35px', height: '35px' }} className='icon' onClick={()=>toggle()} />
            :
            <ToggleOnIcon style={{ width: '35px', height: '35px' }} className='icon'  onClick={()=>toggle()}/>}
        <LightModeIcon style={{ width: '35px', height: '35px' }} className='icon' />
      </div>
    </div>
  )
}

export default Navbar