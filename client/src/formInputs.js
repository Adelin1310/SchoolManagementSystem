import { getAllClassesBySchoolId } from "./api/Classes";
import { getAllSchools, getAllSchoolsWithClasses } from "./api/Schools";

export const studentInputs = [{
    type: 'text',
    name: 'firstName',
    label: 'First Name',
    placeholder: 'First Name',
},
{
    type: 'text',
    name: 'lastName',
    label: 'Last Name',
    placeholder: 'Last Name',
},
{
    type: 'text',
    name: 'address',
    label: 'Address',
    placeholder: 'Address',
},
]

export const teacherInputs = [{
    type: 'text',
    name: 'firstName',
    label: 'First Name',
    placeholder : 'First Name',
},
{
    type: 'text',
    name: 'lastName',
    label: 'Last Name',
    placeholder : 'Last Name'
},
{
    type: 'text',
    name: 'address',
    label: 'Address',
    placeholder: 'Address',
}
]

export const classInputs =[{
    type: 'text',
    name: 'name',
    label: 'Name',
    placeholder : 'Name',
}]