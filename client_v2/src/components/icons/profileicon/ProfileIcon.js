import React from 'react'
import './profileicon.css'
import { Link } from 'react-router-dom'
const ProfileIcon = ({ imgUrl }) => {
    return (
        <Link to={'profile'} className='profileicon'>
            <img src={imgUrl} alt=''></img>
        </Link>
    )
}

export default ProfileIcon