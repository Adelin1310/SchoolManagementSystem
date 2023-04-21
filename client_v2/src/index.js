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
import Teachers from './pages/Teachers';
import Subjects from './pages/Subjects';
import Unauthorized from './components/codes/401/Unauthorized';
import NotFound from './components/codes/404/NotFound';

const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
    errorElement:<NotFound/>,
    children: [
      {
        path:'unauthorized',
        element:<Unauthorized/>
      },
      {
        path: 'schools',
        element: <Schools />,
      },
      {
        path:'schools/add',
        element:<AddSchool/>
      },
      {
        path: 'classes',
        element: <Classes />,
      },
      {
        path:'classes/add',
        element:<AddClass/>
      },
      {
        path: 'students',
        element: <Students />,
      },
      {
        path:'students/add',
        element:<AddClass/>
      },
      {
        path: 'teachers',
        element: <Teachers />,
      },
      {
        path:'teachers/add',
        element:<AddClass/>
      },
      {
        path: 'subjects',
        element: <Subjects />,
      },
      {
        path:'subjects/add',
        element:<AddClass/>
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
