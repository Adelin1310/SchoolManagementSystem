import React from 'react'
import { useState } from 'react'
import '../styles/form.scss'
import Select from 'react-select'
import { updateStudent } from '../../api/Students'
import { useEffect } from 'react'
import { photosFolder } from '../../api/globals'



const StudentEditForm = ({ inputs, studentData }) => {
    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
        address: '',
        schoolId: 0,
        classId: 0,
        photo: ''
    })
    const [student, setStudent] = useState(studentData)
    const [schools, setSchools] = useState()
    const [classes, setClasses] = useState()
    const [photo, setPhoto] = useState()



    //Setting initial form data to be the received student data from the api
    useEffect(() => {
        setFormData({
            firstName: student.firstName,
            lastName: student.lastName,
            address: student.address,
            schoolId: parseInt(student.schoolId),
            classId: parseInt(student.classId),
            photo: student.photo
        })
        let mappedSchools = inputs[inputs.length - 1].selects.map(s => {
            return ({
                label: s.label,
                value: s.value
            })
        })
        mappedSchools = mappedSchools.sort()
        setSchools(mappedSchools)
        let classes = inputs[inputs.length - 1].selects.filter((x) => x.value === parseInt(student.schoolId))[0].classes
        let mappedClasses = classes.map(cls => ({
            value: parseInt(cls.value),
            label: cls.name
        }))
        setClasses(mappedClasses.sort())
    }, [])

    const customStyle = {
        container: base => ({
            ...base,
            width: '100%'
        })
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log(formData)
        updateStudent(formData,student.id).then(res => {
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
        console.log(e.value)
        setFormData({
            ...formData,
            classId: parseInt(e.value)
        })
    }

    const handlePhotoChange = (e) => {
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
                Edit Student
            </h1>
            <div className='form-inside'>
                <div className='input-group noML w20'>
                    <div className="profile-pic">
                        <label className="-label" htmlFor="file">
                            <span className="glyphicon glyphicon-camera"></span>
                            <span>Change Image</span>
                        </label>
                        <input id="file" name='photo' type='file' accept='image/*' onChange={handlePhotoChange} />
                        <img src={`${studentData?.photo}`} id="output" width="200" />
                    </div>

                </div>
                <div className='input-group noMR w80'>

                    {
                        inputs.map((input, idx) => (

                            input.type === 'text' && (
                                <div className='group' key={idx}>
                                    <input required onChange={handleChange} name={input.name} type={input.type} defaultValue={formData[`${input.name}`]} placeholder={input.placeholder} />
                                </div>
                            )))
                    }
                    {
                        schools && classes &&
                        <div key='21' className='group'>

                            <Select required styles={customStyle} name='schoolId' defaultValue={schools.find((x)=>x.value === student.schoolId)} options={schools} onChange={handleSchoolChange} />

                        </div>}
                    {
                        schools && classes &&
                        <div key='22' className='group'>

                            <Select required styles={customStyle} name='classId' defaultValue={classes.find(x=>x.value===student.classId)} options={classes} onChange={handleClassChange} />
                        </div>}

                    <input type='submit' value={'Submit'} />
                </div>
            </div>
        </form>
    )
}

export default StudentEditForm