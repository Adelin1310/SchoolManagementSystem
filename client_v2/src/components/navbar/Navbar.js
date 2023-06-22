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
import { Link, useNavigate } from 'react-router-dom'
import { useStateContext } from '../../contexts/UserContext';
import { logout } from '../../api/Auth';

const Navbar = ({ sideMenuState, changeTheme, actualTheme }) => {
  const [internalSideMenuState, setInternalSideMenuState] = useState(sideMenuState)
  const [toggleState, setToggleState] = useState(actualTheme === 'dark')
  const { currentUser, setCurrentUser, activeTab, setActiveTab } = useStateContext()
  const iconClass = 'nv-icon'
  const iconTextClass = 'nv-icon-text'
  const toggle = () => {
    setToggleState(!toggleState)
    changeTheme();
  }
  const navigate = useNavigate()
  const menuItems = () => {
    const role = currentUser?.role;
    if (role === "Admin")
      return (
        <React.Fragment>
          <li><Link className={activeTab === 'schools' ? 'nv-active' : null} to={`schools`} onClick={() => { setActiveTab('schools') }}><SchoolIcon className={iconClass} />
            <div className={iconTextClass}>SCHOOLS</div></Link> </li>
          <li><Link className={activeTab === 'teachers' ? 'nv-active' : null} to={`teachers`} onClick={() => { setActiveTab('teachers') }}><LocalLibraryIcon className={iconClass} />
            <div className={iconTextClass}>TEACHERS</div></Link></li>
          <li><Link className={activeTab === 'classes' ? 'nv-active' : null} to={`classes`} onClick={() => { setActiveTab('classes') }}><ClassIcon className={iconClass} />
            <div className={iconTextClass}>CLASSES</div></Link></li>
          <li><Link className={activeTab === 'students' ? 'nv-active' : null} to={`students`} onClick={() => { setActiveTab('students') }}><FaceIcon className={iconClass} />
            <div className={iconTextClass}>STUDENTS</div></Link></li>
          <li><Link className={activeTab === 'subjects' ? 'nv-active' : null} to={`subjects`} onClick={() => { setActiveTab('subjects') }}><LibraryBooksIcon className={iconClass} />
            <div className={iconTextClass}>SUBJECTS</div></Link></li>
          <li><div onClick={() => logoutUser()}><LogoutIcon className={iconClass} />
            <div className={iconTextClass}>LOG OUT</div></div></li>
        </React.Fragment>
      )
    if (role === "Student")
      return (
        <React.Fragment>
          <li><Link className={activeTab === 'classbook' ? 'nv-active' : null} to={`student/classbook`} onClick={() => { setActiveTab('classbook') }}><LibraryBooksIcon className={iconClass} />
            <div className={iconTextClass}>CLASSBOOK</div>
          </Link></li>
          <li><Link className={activeTab === 'teachers' ? 'nv-active' : null} to={`myteachers`} onClick={() => { setActiveTab('teachers') }}><LocalLibraryIcon className={iconClass} />
            <div className={iconTextClass}>MY TEACHERS</div>
          </Link></li>
          <li><Link className={activeTab === 'classes' ? 'nv-active' : null} to={`myclass`} onClick={() => { setActiveTab('classes') }}><ClassIcon className={iconClass} />
            <div className={iconTextClass}>MY CLASS</div>
          </Link></li>
          <li><div onClick={() => logoutUser()}><LogoutIcon className={iconClass} />
            <div className={iconTextClass}>LOG OUT</div>
          </div></li>
        </React.Fragment>
      )
    if (role === "Teacher")
      return (
        <React.Fragment>
          <li><Link className={activeTab === 'classes' ? 'nv-active' : null} to={`teacher/classes`} onClick={() => { setActiveTab('classes') }}><ClassIcon className={iconClass} />
            <div className={iconTextClass}>MY CLASSES</div>
          </Link></li>
          <li><Link className={activeTab === 'students' ? 'nv-active' : null} to={`teacher/students`} onClick={() => { setActiveTab('students') }}><FaceIcon className={iconClass} />
            <div className={iconTextClass}>MY STUDENTS</div>
          </Link></li>
          <li><Link className={activeTab === 'subjects' ? 'nv-active' : null} to={`teacher/subjects`} onClick={() => { setActiveTab('subjects') }}><LibraryBooksIcon className={iconClass} />
            <div className={iconTextClass}>MY SUBJECTS</div>
          </Link></li>
          <li><div onClick={() => logoutUser()}><LogoutIcon className={iconClass} />
            <div className={iconTextClass}>LOG OUT</div>
          </div></li>
        </React.Fragment>
      )
    if (role === "Director")
      return (
        <React.Fragment>
          <li><Link className={activeTab === 'schools' ? 'nv-active' : null} to={`schools`} onClick={() => { setActiveTab('schools') }}><SchoolIcon className={iconClass} />
            <div className={iconTextClass}>SCHOOL</div>
          </Link> </li>
          <li><Link className={activeTab === 'teachers' ? 'nv-active' : null} to={`teachers`} onClick={() => { setActiveTab('teachers') }}><LocalLibraryIcon className={iconClass} />
            <div className={iconTextClass}>TEACHERS</div>
          </Link></li>
          <li><Link className={activeTab === 'classes' ? 'nv-active' : null} to={`classes`} onClick={() => { setActiveTab('classes') }}><ClassIcon className={iconClass} />
            <div className={iconTextClass}>CLASSES</div>
          </Link></li>
          <li><Link className={activeTab === 'students' ? 'nv-active' : null} to={`students`} onClick={() => { setActiveTab('students') }}><FaceIcon className={iconClass} />
            <div className={iconTextClass}>STUDENTS</div>
          </Link></li>
          <li><Link className={activeTab === 'subjects' ? 'nv-active' : null} to={`subjects`} onClick={() => { setActiveTab('subjects') }}><LibraryBooksIcon className={iconClass} />
            <div className={iconTextClass}>SUBJECTS</div>
          </Link></li>
          <li><div onClick={() => logoutUser()}><LogoutIcon className={iconClass} />
            <div className={iconTextClass}>LOG OUT</div>
          </div></li>

        </React.Fragment >
      )
  }
  const logoutUser = () => {
    try {
      const _ = async () => {
        await logout();
        setCurrentUser(null)
        navigate('/app/login')
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
    <div className={internalSideMenuState ? 'nv-container' : 'nv-container nv-hide'}>
      <div className='nv-logo-container'>
        <Link to={'/app'} onClick={() => { setActiveTab(undefined) }} className='nv-logo'>QUICKGRADE</Link>
        <Link to={'/app'} onClick={() => { setActiveTab(undefined) }} className='nv-mobilelogo'>QG</Link>
      </div>
      <ul className='nv-navmenu'>
        {
          menuItems()
        }

      </ul>
      <div className='nv-themeBtns'>
        <DarkModeIcon style={{ width: '35px', height: '35px' }} className='nv-icon' />
        {
          toggleState ?
            <ToggleOffIcon style={{ width: '35px', height: '35px' }} className='nv-icon' onClick={() => toggle()} />
            :
            <ToggleOnIcon style={{ width: '35px', height: '35px' }} className='nv-icon' onClick={() => toggle()} />}
        <LightModeIcon style={{ width: '35px', height: '35px' }} className='nv-icon' />
      </div>
      <div className='nv-mobileThemeBtns'>
        {
          actualTheme === 'dark' ?
            <DarkModeIcon style={{ width: '35px', height: '35px' }} onClick={() => toggle()} className='nv-icon' />
            :
            <LightModeIcon style={{ width: '35px', height: '35px' }} className='nv-icon' onClick={() => toggle()} />}
      </div>
    </div>
  )
}

export default Navbar