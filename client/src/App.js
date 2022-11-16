import Home from "./pages/Home";
import Login from "./pages/Login";
import List from "./pages/List";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { productInputs, userInputs } from "./formSource";
import { getAllSchools } from "./api/Schools";
import { schoolColumns, studentColumns } from "./datatablesource";
import { getAllStudents } from "./api/Students";
import ViewStudents from "./pages/Student/ViewStudents";
import ViewClassbooks from "./pages/Classbook/ViewClassbooks";
import ViewClasses from "./pages/Class/ViewClasses";
import ViewSchools from "./pages/School/ViewSchools";
import ViewSchool from "./pages/School/ViewSchool";
import ViewClass from "./pages/Class/ViewClass";
import ViewTeachers from "./pages/Teacher/ViewTeachers";
import ViewSubjects from "./pages/Subject/ViewSubjects";
import CreateStudent from "./pages/Student/CreateStudent";
import EditStudent from "./pages/Student/EditStudent";
import CreateTeacher from "./pages/Teacher/CreateTeacher";

function App() {

    return (
        <BrowserRouter>
            <Routes>
                <Route path="/classbooks" element={<ViewClassbooks />} />
                <Route path="/classes" element={<ViewClasses />} />
                <Route path="/classes/:classId" element={<ViewClass />} />
                <Route path="/students" element={<ViewStudents />} />
                <Route path="/students/new" element={<CreateStudent />} />
                <Route path="/students/edit/:studentId" element={<EditStudent />}/>
                <Route path="/teachers" element={<ViewTeachers />} />
                <Route path="/teachers/new" element={<CreateTeacher />} />
                <Route path="/schools" element={<ViewSchools />} />
                <Route path="/schools/:schoolId" element={<ViewSchool />} />
                <Route path="/subjects" element={<ViewSubjects />} />
                <Route path="/login" element={<Login />} />
                <Route path="/" element={<Home />} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;