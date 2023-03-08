import React from 'react'
import './profileicon.css'
const ProfileIcon = ({ imgUrl, profileLink }) => {
    return (
        <span className='profileicon'>
            <img src={imgUrl} alt=''></img>
        </span>
    )
}

export default ProfileIcon