import React from 'react'
import { useState } from 'react'
import '../styles/form.scss'
import Select from 'react-select'
import { addStudent } from '../../api/Students'
import { useEffect } from 'react'
import { noPicture } from '../globals'
import { photosFolder } from '../../api/globals'



const ClassForm = ({ inputs }) => {
    const [formData, setFormData] = useState({
        name:'',
        schoolId: 0,
    })

    useEffect(() => {
        setSchools(inputs[inputs.length - 1].selects?.map(s => ({
            label: s.label,
            value: s.value
        })))
    }, [inputs[inputs.length - 1].selects])

    const [schools, setSchools] = useState(inputs[inputs.length - 1].selects)

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
                window.location = '/classes'
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
        setFormData({
            ...formData,
            schoolId: parseInt(e.value)
        })
    }

    return (
        <form className='form' onSubmit={handleSubmit}>
            <h1>
                Add New Class
            </h1>
            <div className='form-inside'>
                <div className='input-group'>

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

                    <input type='submit' value={'Submit'} />
                </div>
            </div>
        </form>
    )
}

export default ClassForm