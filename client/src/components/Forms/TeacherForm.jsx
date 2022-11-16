import React, { useEffect } from 'react'
import { useState } from 'react'
import '../styles/form.scss'
import { addTeacher } from '../../api/Teachers'



const TeacherForm = ({ inputs }) => {
    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
        address: '',
        schools: [],
        subjects: [],
    })
    const [inputsData, setInputsData] = useState(inputs.newInputsData)
    const [schools, setSchools] = useState()
    const [subjects, setSubjects] = useState()

    const customStyle = {
        container: base => ({
            ...base,
            width: '100%'
        })
    }

    useEffect(() => {
        console.log(inputsData)
        setSchools(inputsData[0].schools)
        setSubjects(inputsData[0].subjects)
    }, [])

    const handleSubmit = (e) => {
        e.preventDefault();
        addTeacher(formData).then(res => {
            if (res.success)
                window.location = '/teachers'
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
    const verifyArray = (arrName, valuesArray) => {
        let a = []

        for (let i = 0; i < a.length; i++) {
            if (valuesArray[i].checked)
                a.push(valuesArray[i].value)
        }

        return a;
    }

    const handleCheckboxChange = (e, checkbox) => {
        let array = formData[checkbox]
        let oldCheckboxState = undefined
        if (checkbox === 'subjects')
            oldCheckboxState = subjects
        else
            oldCheckboxState = schools

        console.log(oldCheckboxState)
        let newCheckboxState = oldCheckboxState.map((s, i) => ({
            name: s.name,
            value: s.value,
            checked: e === i ? !s.checked : s.checked
        }))

        setFormData({
            ...formData,
            [checkbox]: verifyArray(checkbox, newCheckboxState)
        })
        if (checkbox === 'schools') {
            setSchools(newCheckboxState)
        } else setSubjects(newCheckboxState)

    }
    return (
        schools !== undefined && subjects !== undefined && inputsData !== undefined &&
        <form className='form' onSubmit={handleSubmit}>
            <h1>
                Add New Teacher
            </h1>
            <div className='form-inside'>
                <div className='input-group'>

                    {
                        inputsData.map((input, idx) => (
                            input.type === 'text' && (
                                <div className='group' key={idx}>
                                    <input required onChange={handleChange} name={input.name} type={input.type} placeholder={input.placeholder} />
                                </div>
                            )))
                    }

                    <div key='21' className='group'>
                        <div className='list-container'>
                            <ul className='input-checkbox-group'>

                                {schools.map((school, idx) => (
                                    <li key={idx} className='input-checkbox'>
                                        <input type="checkbox" id={`school-checkbox-${idx}`} name="School" value={school.id} checked={school.checked} onChange={() => handleCheckboxChange(idx, 'schools')} />
                                        <label htmlFor={`school-checkbox-${idx}`}>{school.name}</label>
                                    </li>
                                ))}
                            </ul>
                        </div>
                    </div>
                    <div key='22' className='group'>
                        <div className='list-container'>
                            <ul className='input-checkbox-group'>

                                {subjects.map((subject, idx) => (

                                    <li key={idx} className='input-checkbox'>
                                        <input type="checkbox" id={`subject-checkbox-${idx}`} name="Subject" value={subject.id} checked={subject.checked} onChange={() => handleCheckboxChange(idx, 'subjects')} />
                                        <label htmlFor={`subject-checkbox-${idx}`}>{subject.name}</label>
                                    </li>
                                ))}
                            </ul>
                        </div>
                    </div>

                    <input type='submit' value={'Submit'} />
                </div>
            </div>
        </form >
    )
}

export default TeacherForm