import React from 'react'
import './topbar.css'
import MenuIcon from '@mui/icons-material/Menu';
import ProfileIcon from '../icons/profileicon/ProfileIcon';


const Topbar = () => {
    const handleClick = (e) => {
        console.log(e.target)
    }


    return (
        <div className='topbar-container'>
            <MenuIcon onClick={handleClick} className='sidemenubtn' />
            <ul className='topbarmenu'>
                <li>
                    <ProfileIcon imgUrl={'http://127.0.0.1:8887/photos/defaultProfilePicture.png'} />
                </li>
            </ul>
        </div>
    )
}

export default Topbar