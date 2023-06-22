import React from 'react';
import ReactDOM from 'react-dom/client';
import {
  createBrowserRouter,
  RouterProvider,
} from 'react-router-dom'

import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import Schools from './pages/Schools';
import Classes from './pages/Classes';
import AddSchool from './pages/School/AddSchool';
import AddClass from './pages/Class/AddClass';
import Students from './pages/Students';
import Subjects from './pages/Subjects';
import RootBoundary from './components/codes/RootBoundary';
import { getAllSchools } from './api/Schools';
import Profile from './pages/Profile';
import Homepage from './pages/Homepage';
import Login from './pages/Login';
import Register from './pages/Register';
import { getAllClasses, getAllTeacherClasses, getStudentClass } from './api/Class';
import StudentViewClass from './pages/Class/StudentViewClass';
import StudentViewTeachers from './pages/Teacher/StudentViewTeachers';
import DirectorViewTeachers from './pages/Teacher/DirectorViewTeachers';
import { getTeachersByClassId, getTeacherWClassesAndSubjects } from './api/Teachers';
import StudentViewTeacher from './pages/Teacher/StudentViewTeacher';
import StudentViewClassbook from './pages/Classbook/StudentViewClassbook';
import { getStudentClassbook, getStudentSituation, getSubjectSituation, getTeacherClassSubjects } from './api/Subjects';
import StudentViewSubject from './pages/Subject/StudentViewSubject';
import TeacherViewClasses from './pages/Class/TeacherViewClasses';
import TeacherViewClassbook from './pages/Classbook/TeacherViewClassbook';
import { getClassbook } from './api/Classbook';

const router = createBrowserRouter([
  {
    path: '/',
    element: <Homepage />,
    errorElement: <RootBoundary />,
  },
  {
    path: '/register',
    element: <Register />
  },
  {
    path: '/app',
    element: <App />,
    errorElement: <RootBoundary />,
    children: [
      {
        path: 'login',
        element: <Login />
      },

      {
        path: 'profile',
        element: <Profile />
      },
      {
        loader: getAllSchools,
        path: 'schools',
        element: <Schools />,
      },
      {
        path: 'schools/add',
        element: <AddSchool />
      },
      {
        loader: getStudentClass,
        path: 'myclass',
        element: <StudentViewClass />
      },
      {
        loader: getStudentSituation,
        path: 'student/classbook',
        element: <StudentViewClassbook />,

      },
      {
        loader: getAllTeacherClasses,
        path: 'teacher/classes',
        element: <TeacherViewClasses />,
      },
      {
        path: 'teacher/classes/:classId/classbook/:classbookId',
        loader: async ({ req, params }) => {
          const data = await getClassbook(params.classbookId)
          const subjects = await getTeacherClassSubjects(params.classId)
          return { data, subjects }
        },
        element: <TeacherViewClassbook />,
      },
      {
        path: 'classes/add',
        element: <AddClass />
      },
      {
        path: 'teacher/students',
        element: <Students />,
      },
      {
        path: 'students/add',
        element: <AddClass />
      },
      {
        loader: getTeachersByClassId,
        path: 'myteachers',
        element: <StudentViewTeachers />,
      },
      {
        path: 'myteachers/:teacherId',
        loader: ({ params }) => {
          return getTeacherWClassesAndSubjects(params.teacherId)
        },
        element: <StudentViewTeacher />
      },
      {
        path: 'teachers',
        element: <DirectorViewTeachers />,
      },
      {
        path: 'teachers/add',
        element: <AddClass />
      },
      {
        path: 'teacher/subjects',
        element: <Subjects />,
      },
      {
        path: 'subjects/add',
        element: <AddClass />
      },
    ]
  }
])

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <RouterProvider router={router} />
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
