import React from 'react'
import { useState } from 'react'
import './styles/form.scss'



const Form = ({ inputs }) => {
    const [inputsData, setInputsData] = useState(inputs)
    const [selectValues, setSelectValues] = useState([])




    const handleSubmit = () => {

    }

    const handleChange = (e) => {
        let values = selectValues
        values.filter((x) => x.name !== e.target.id)
        values.push({ name: e.target.id, value: e.target.value })
        setSelectValues(values)
    }

    return (
        <form className='form' onSubmit={handleSubmit}>

            <div className='form-inside'>
                {inputsData.map((input, idx) => (

                    input.type === 'text' ? (
                        <div className='group' key={idx}>
                            <label htmlFor={input.name}>{input.label}</label>
                            <input type={input.type} placeholder={input.placeholder} />
                        </div>
                    ) :
                        input.type === 'select' ? (
                            <div className='group' key={idx}>

                                <label htmlFor={input.name}>{input.label}</label>
                                <select id={input.name} onChange={handleChange}>
                                    {
                                        <option value={input.id}>{input.name}</option>
                                    }
                                </select>
                            </div>
                        )
                            : null
                )
                )
                }


            </div>
            <input type='submit' value={'Submit'} />
        </form>
    )
}

export default Form