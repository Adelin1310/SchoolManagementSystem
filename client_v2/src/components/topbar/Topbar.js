import React, { useState } from 'react'
import './topbar.css'
import MenuIcon from '@mui/icons-material/Menu';
import ProfileIcon from '../icons/profileicon/ProfileIcon';
import Dropdown from '../buttons/Dropdown';
import { useStateContext } from '../../contexts/UserContext';


const Topbar = ({setSideMenuState, sideMenuState}) => {
    const [internalSideMenuState, setInternalSideMenuState] = useState(sideMenuState)
    const handleClick = (e) => {
        setInternalSideMenuState(!internalSideMenuState)
        setSideMenuState(!sideMenuState)
    }
    const {currentUser} = useStateContext()

    return (
        <div className={internalSideMenuState ? 'topbar-container' : 'topbar-container fullbar'}>
            <MenuIcon onClick={handleClick} className='sidemenubtn' />
            <ul className='topbarmenu'>
                <li>
                    <ProfileIcon imgUrl={currentUser?.profileImg}/>
                </li>
            </ul>
        </div>
    )
}

export default Topbar