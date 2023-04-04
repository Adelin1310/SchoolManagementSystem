import React, { useState } from 'react'
import './topbar.css'
import MenuIcon from '@mui/icons-material/Menu';
import ProfileIcon from '../icons/profileicon/ProfileIcon';


const Topbar = ({setSideMenuState, sideMenuState}) => {
    const [internalSideMenuState, setInternalSideMenuState] = useState(sideMenuState)
    const handleClick = (e) => {
        setInternalSideMenuState(!internalSideMenuState)
        setSideMenuState(!sideMenuState)
    }


    return (
        <div className={internalSideMenuState ? 'topbar-container' : 'topbar-container fullbar'}>
            <MenuIcon onClick={handleClick} className='sidemenubtn' />
            <ul className='topbarmenu'>
                <li>
                    <ProfileIcon imgUrl={'http://localhost:8887/photos/IMG_20221021_233821_688.jpg'} />
                </li>
            </ul>
        </div>
    )
}

export default Topbar