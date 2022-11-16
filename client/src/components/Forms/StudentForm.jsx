import React from 'react'
import { useState } from 'react'
import '../styles/form.scss'
import Select from 'react-select'
import { addStudent } from '../../api/Students'
import { useEffect } from 'react'
import { noPicture } from '../globals'
import { photosFolder } from '../../api/globals'



const StudentForm = ({ inputs }) => {
    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
        address: '',
        schoolId: 0,
        classId: 0,
        photo:''
    })

    useEffect(() => {
        setSchools(inputs[inputs.length - 1].selects?.map(s => ({
            label: s.label,
            value: s.value
        })))
    }, [inputs[inputs.length - 1].selects])

    const [schools, setSchools] = useState(inputs[inputs.length - 1].selects)
    const [classes, setClasses] = useState({})
    const [photo, setPhoto] = useState(noPicture)

    const customStyle = {
        container: base => ({
            ...base,
            width: '100%'
        })
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        addStudent(formData).then(res => {
            if (res.success)
                window.location = '/students'
            else
                window.location = '/servererror'
        }).catch(err => console.error(err))

    }

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        })
    }
    const handleSchoolChange = (e) => {
        let classes = inputs[inputs.length - 1].selects.filter((x) => x.value === parseInt(e.value))[0].classes
        let mappedClasses = classes.map(cls => ({
            value: parseInt(cls.value),
            label: cls.name
        }))
        setClasses(mappedClasses)
        setFormData({
            ...formData,
            schoolId: parseInt(e.value)
        })
    }
    const handleClassChange = (e) => {
        setFormData({
            ...formData,
            classId: parseInt(e.value)
        })
    }

    const handlePhotoChange = (e) =>{
        console.log(e.target.files[0])
        setFormData({
            ...formData,
            photo: `${photosFolder}${e.target.files[0].name}`
        })
        setPhoto(URL.createObjectURL(e.target.files[0]));

    }

    return (
        <form className='form' onSubmit={handleSubmit}>
            <h1>
                Add New Student
            </h1>
            <div className='form-inside'>
                <div className='input-group noML w20'>
                    <div className="profile-pic">
                        <label className="-label" htmlFor="file">
                            <span className="glyphicon glyphicon-camera"></span>
                            <span>Change Image</span>
                        </label>
                        <input id="file" name='photo' type='file' accept='image/*' onChange={handlePhotoChange} />
                        <img src={`${photo}`} id="output" width="200" />
                    </div>

                </div>
                <div className='input-group noMR w80'>

                    {
                        inputs.map((input, idx) => (

                            input.type === 'text' && (
                                <div className='group' key={idx}>
                                    <input required onChange={handleChange} name={input.name} type={input.type} placeholder={input.placeholder} />
                                </div>
                            )))
                    }

                    <div key='21' className='group'>
                        <Select required styles={customStyle} name='schoolId' options={schools} onChange={handleSchoolChange} />

                    </div>
                    <div key='22' className='group'>

                        <Select required styles={customStyle} name='classId' options={classes} onChange={handleClassChange} />
                    </div>

                    <input type='submit' value={'Submit'} />
                </div>
            </div>
        </form>
    )
}

export default StudentForm