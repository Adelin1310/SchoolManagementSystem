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
import { useStateContext } from '../../contexts/UserContext';
import { logout } from '../../api/Auth';

const Navbar = ({ sideMenuState, changeTheme }) => {
  const [internalSideMenuState, setInternalSideMenuState] = useState(sideMenuState)
  const [toggleState, setToggleState] = useState(false)
  const [active, setActive] = useState(undefined)
  const { currentUser, setCurrentUser } = useStateContext()
  const toggle = () => {
    setToggleState(!toggleState)
    changeTheme();
  }
  const logoutUser = () => {
    try {
      const _ = async () => {
        const res = await logout();
        if (res.success) {
          setCurrentUser(null)
        }
      }
      _();
    } catch (err) {
      console.log(err)
    }
  }
  useEffect(() => {
    setInternalSideMenuState(sideMenuState)
  }, [sideMenuState])
  return (
    <div className={internalSideMenuState ? 'container' : 'container hide'}>
      <Link to={'profile'} onClick={() => { setActive(undefined) }} className='logo'>LOGO</Link>
      <ul className='navmenu'>
        {
          currentUser?.role !== "Student" ? (
            <React.Fragment>
              <li><Link className={active === 'schools' ? 'active' : null} to={`schools`} onClick={() => { setActive('schools') }}><SchoolIcon className='icon' />SCHOOLS</Link> </li>
              <li><Link className={active === 'classes' ? 'active' : null} to={`classes`} onClick={() => { setActive('classes') }}><ClassIcon className='icon' />CLASSES</Link></li>
              <li><Link className={active === 'students' ? 'active' : null} to={`students`} onClick={() => { setActive('students') }}><FaceIcon className='icon' />STUDENTS</Link></li>
              <li><Link className={active === 'teachers' ? 'active' : null} to={`teachers`} onClick={() => { setActive('teachers') }}><LocalLibraryIcon className='icon' />TEACHERS</Link></li>
            </React.Fragment>
          ) : null
        }
        <li><Link className={active === 'subjects' ? 'active' : null} to={`subjects`} onClick={() => { setActive('subjects') }}><LibraryBooksIcon className='icon' />SUBJECTS</Link></li>
        <li><div onClick={() => logoutUser()}><LogoutIcon className='icon' />LOG OUT</div></li>

      </ul>
      <div className='themeBtns'>
        <DarkModeIcon style={{ width: '35px', height: '35px' }} className='icon' />
        {
          toggleState ?
            <ToggleOffIcon style={{ width: '35px', height: '35px' }} className='icon' onClick={() => toggle()} />
            :
            <ToggleOnIcon style={{ width: '35px', height: '35px' }} className='icon' onClick={() => toggle()} />}
        <LightModeIcon style={{ width: '35px', height: '35px' }} className='icon' />
      </div>
    </div>
  )
}

export default Navbar