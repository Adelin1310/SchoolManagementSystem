
```
SchoolManagementSystem
├─ .vscode
│  ├─ launch.json
│  └─ tasks.json
├─ client
│  ├─ package-lock.json
│  ├─ package.json
│  ├─ public
│  │  ├─ favicon.ico
│  │  ├─ index.html
│  │  ├─ logo192.png
│  │  ├─ logo512.png
│  │  ├─ manifest.json
│  │  └─ robots.txt
│  ├─ README.md
│  └─ src
│     ├─ api
│     │  ├─ Classbooks.js
│     │  ├─ Classes.js
│     │  ├─ globals.js
│     │  ├─ Schools.js
│     │  ├─ Students.js
│     │  ├─ Subjects.js
│     │  └─ Teachers.js
│     ├─ App.js
│     ├─ components
│     │  ├─ Chart.jsx
│     │  ├─ Datatable.jsx
│     │  ├─ Featured.jsx
│     │  ├─ Form.jsx
│     │  ├─ Forms
│     │  │  ├─ ClassForm.jsx
│     │  │  ├─ StudentEditForm.jsx
│     │  │  ├─ StudentForm.jsx
│     │  │  └─ TeacherForm.jsx
│     │  ├─ globals.js
│     │  ├─ Navbar.jsx
│     │  ├─ Sidebar.jsx
│     │  ├─ styles
│     │  │  ├─ chart.scss
│     │  │  ├─ datatable.scss
│     │  │  ├─ featured.scss
│     │  │  ├─ form.scss
│     │  │  ├─ navbar.scss
│     │  │  ├─ sidebar.scss
│     │  │  ├─ table.scss
│     │  │  ├─ theme.scss
│     │  │  └─ widget.scss
│     │  ├─ Table.jsx
│     │  └─ Widget.jsx
│     ├─ datatablesource.js
│     ├─ formInputs.js
│     ├─ formSource.js
│     ├─ index.css
│     ├─ index.js
│     ├─ pages
│     │  ├─ Class
│     │  │  ├─ CreateClass.js
│     │  │  ├─ ViewClass.js
│     │  │  └─ ViewClasses.js
│     │  ├─ Classbook
│     │  │  └─ ViewClassbooks.js
│     │  ├─ Home.jsx
│     │  ├─ List.jsx
│     │  ├─ Login.jsx
│     │  ├─ School
│     │  │  ├─ ViewSchool.js
│     │  │  └─ ViewSchools.js
│     │  ├─ Student
│     │  │  ├─ CreateStudent.js
│     │  │  ├─ EditStudent.js
│     │  │  └─ ViewStudents.js
│     │  ├─ styles
│     │  │  ├─ home.scss
│     │  │  ├─ list.scss
│     │  │  └─ login.scss
│     │  ├─ Subject
│     │  │  └─ ViewSubjects.js
│     │  └─ Teacher
│     │     ├─ CreateTeacher.js
│     │     └─ ViewTeachers.js
│     └─ reportWebVitals.js
├─ client_v2
│  ├─ package-lock.json
│  ├─ package.json
│  ├─ public
│  │  ├─ favicon.ico
│  │  ├─ index.html
│  │  ├─ manifest.json
│  │  └─ robots.txt
│  ├─ README.md
│  └─ src
│     ├─ api
│     │  ├─ Absence.js
│     │  ├─ Auth.js
│     │  ├─ Class.js
│     │  ├─ Classbook.js
│     │  ├─ Grade.js
│     │  ├─ index.js
│     │  ├─ Schools.js
│     │  ├─ Situations.js
│     │  ├─ Students.js
│     │  ├─ Subjects.js
│     │  └─ Teachers.js
│     ├─ App.css
│     ├─ App.js
│     ├─ components
│     │  ├─ actions
│     │  │  ├─ actions.css
│     │  │  └─ Actions.jsx
│     │  ├─ buttons
│     │  │  ├─ button.css
│     │  │  ├─ Button.js
│     │  │  ├─ dropdown.css
│     │  │  └─ Dropdown.jsx
│     │  ├─ card
│     │  │  ├─ Card.css
│     │  │  └─ Card.jsx
│     │  ├─ codes
│     │  │  ├─ 401
│     │  │  │  ├─ unauthorized.css
│     │  │  │  └─ Unauthorized.js
│     │  │  ├─ 404
│     │  │  │  ├─ notfound.css
│     │  │  │  └─ NotFound.js
│     │  │  ├─ 500
│     │  │  │  ├─ InternalServer.css
│     │  │  │  └─ InternalServer.js
│     │  │  └─ RootBoundary.jsx
│     │  ├─ icons
│     │  │  └─ profileicon
│     │  │     ├─ profileicon.css
│     │  │     └─ ProfileIcon.js
│     │  ├─ loading
│     │  │  ├─ LoadingSpinner.jsx
│     │  │  └─ spinner.css
│     │  ├─ modal
│     │  │  ├─ AddAbsenceModal
│     │  │  │  ├─ AddAbsenceModal.css
│     │  │  │  └─ AddAbsenceModal.jsx
│     │  │  ├─ AddGradeModal
│     │  │  │  ├─ AddGradeModal.css
│     │  │  │  └─ AddGradeModal.jsx
│     │  │  ├─ EditAbsenceModal
│     │  │  │  ├─ EditAbsenceModal.css
│     │  │  │  └─ EditAbsenceModal.jsx
│     │  │  ├─ modal.css
│     │  │  ├─ Modal.jsx
│     │  │  ├─ SessionExpiredModal
│     │  │  │  └─ SessionExpiredModal.jsx
│     │  │  └─ StudentGradeDetailsModal
│     │  │     └─ StudentGradeDetailsModal.jsx
│     │  ├─ navbar
│     │  │  ├─ button
│     │  │  │  └─ button.js
│     │  │  ├─ navbar.css
│     │  │  └─ Navbar.js
│     │  ├─ profile
│     │  │  ├─ profile.css
│     │  │  ├─ StudentProfile.jsx
│     │  │  └─ TeacherProfile.jsx
│     │  ├─ table
│     │  │  ├─ classes
│     │  │  │  ├─ Options.js
│     │  │  │  └─ TableColumns.js
│     │  │  ├─ table.css
│     │  │  └─ Table.js
│     │  ├─ topbar
│     │  │  ├─ topbar.css
│     │  │  └─ Topbar.js
│     │  └─ wrapper.jsx
│     ├─ contexts
│     │  └─ UserContext.js
│     ├─ data
│     │  └─ TableColumns.js
│     ├─ index.css
│     ├─ index.js
│     ├─ pages
│     │  ├─ Class
│     │  │  ├─ AddClass.js
│     │  │  ├─ StudentViewClass.js
│     │  │  └─ TeacherViewClasses.js
│     │  ├─ Classbook
│     │  │  ├─ StudentViewClassbook.js
│     │  │  └─ TeacherViewClassbook.js
│     │  ├─ Classes.js
│     │  ├─ Homepage.js
│     │  ├─ Login.js
│     │  ├─ Profile.js
│     │  ├─ Register.js
│     │  ├─ School
│     │  │  └─ AddSchool.js
│     │  ├─ Schools.js
│     │  ├─ Student
│     │  ├─ Students.js
│     │  ├─ Styles
│     │  │  ├─ homepage.css
│     │  │  ├─ login.css
│     │  │  ├─ register.css
│     │  │  ├─ studentviewclass.css
│     │  │  ├─ studentviewteacher.css
│     │  │  ├─ teacherviewclassbook.css
│     │  │  └─ teacherviewclasses.css
│     │  ├─ Subject
│     │  │  └─ StudentViewSubject.js
│     │  ├─ Subjects.js
│     │  └─ Teacher
│     │     ├─ DirectorViewTeachers.js
│     │     ├─ StudentViewTeacher.js
│     │     └─ StudentViewTeachers.js
│     ├─ reportWebVitals.js
│     └─ Theme.js
├─ data
│  └─ photos
│     ├─ defaultProfilePicture.png
│     └─ IMG_20221021_233821_688.jpg
├─ server
│  ├─ appsettings.Development.json
│  ├─ appsettings.json
│  ├─ AutoMapperProfile.cs
│  ├─ bin
│  ├─ Controllers
│  │  ├─ AbsenceController.cs
│  │  ├─ AuthController.cs
│  │  ├─ ClassbookController.cs
│  │  ├─ ClassController.cs
│  │  ├─ ErrorHandler.cs
│  │  ├─ GradeController.cs
│  │  ├─ SchoolController.cs
│  │  ├─ SituationsController.cs
│  │  ├─ StudentController.cs
│  │  ├─ SubjectController.cs
│  │  └─ TeacherController.cs
│  ├─ Dtos
│  │  ├─ Absence
│  │  │  ├─ AddAbsenceDto.cs
│  │  │  ├─ GetAbsenceDto.cs
│  │  │  └─ UpdateAbsenceDto.cs
│  │  ├─ Base
│  │  │  └─ Profile.cs
│  │  ├─ Class
│  │  │  ├─ AddClassDto.cs
│  │  │  ├─ GetClassDto.cs
│  │  │  ├─ GetClassSubjectDto.cs
│  │  │  ├─ GetStudentClassDto.cs
│  │  │  └─ UpdateClassDto.cs
│  │  ├─ Classbook
│  │  │  ├─ AddClassbookDto.cs
│  │  │  ├─ GetClassbookDto.cs
│  │  │  └─ UpdateClassbookDto.cs
│  │  ├─ Grade
│  │  │  ├─ AddGradeDto.cs
│  │  │  ├─ GetGradeDto.cs
│  │  │  └─ UpdateGradeDto.cs
│  │  ├─ ParentsInfo
│  │  │  ├─ AddParentsInfoDto.cs
│  │  │  ├─ GetParentsInfoDto.cs
│  │  │  └─ UpdateParentsInfoDto.cs
│  │  ├─ Profile
│  │  │  ├─ GetStudentProfileDto.cs
│  │  │  └─ GetTeacherProfileDto.cs
│  │  ├─ School
│  │  │  ├─ AddSchoolDto.cs
│  │  │  ├─ GetSchoolDto.cs
│  │  │  ├─ GetSchoolWClassesDto.cs
│  │  │  └─ UpdateSchoolDto.cs
│  │  ├─ SchoolTeacher
│  │  │  └─ AddSchoolTeacherDto.cs
│  │  ├─ Situations
│  │  │  └─ EndSituationDto.cs
│  │  ├─ Student
│  │  │  ├─ AddStudentDto.cs
│  │  │  ├─ GetStudentDto.cs
│  │  │  ├─ GetStudentWSituationDto.cs
│  │  │  └─ UpdateStudentDto.cs
│  │  ├─ Subject
│  │  │  ├─ AddSubjectDto.cs
│  │  │  ├─ GetStudentSituationDto.cs
│  │  │  ├─ GetSubjectDto.cs
│  │  │  └─ UpdateSubjectDto.cs
│  │  ├─ Teacher
│  │  │  ├─ AddTeacherDto.cs
│  │  │  ├─ GetTeacherDto.cs
│  │  │  ├─ GetTeacherWClassesAndSubjects.cs
│  │  │  ├─ GetTeacherWSchoolsAndSubjectsDto.cs
│  │  │  ├─ GetTeacherWSubject.cs
│  │  │  └─ UpdateTeacherDto.cs
│  │  ├─ TeacherSubject
│  │  │  └─ AddTeacherSubjectDto.cs
│  │  └─ User
│  │     ├─ GetUserDto.cs
│  │     ├─ UserLoginDto.cs
│  │     └─ UserRegisterDto.cs
│  ├─ Models
│  │  ├─ dbo_Absence.cs
│  │  ├─ dbo_Class.cs
│  │  ├─ dbo_Classbook.cs
│  │  ├─ dbo_ClassLeader.cs
│  │  ├─ dbo_ClassSpecialization.cs
│  │  ├─ dbo_ClassSubject.cs
│  │  ├─ dbo_Grade.cs
│  │  ├─ dbo_ParentsInfo.cs
│  │  ├─ dbo_ProfilePhotos.cs
│  │  ├─ dbo_Role.cs
│  │  ├─ dbo_School.cs
│  │  ├─ dbo_SchoolTeacher.cs
│  │  ├─ dbo_SchoolYear.cs
│  │  ├─ dbo_Session.cs
│  │  ├─ dbo_Situations.cs
│  │  ├─ dbo_Student.cs
│  │  ├─ dbo_Subject.cs
│  │  ├─ dbo_Teacher.cs
│  │  ├─ dbo_TeacherSubject.cs
│  │  └─ dbo_User.cs
│  ├─ obj
│  ├─ Program.cs
│  ├─ Properties
│  │  └─ launchSettings.json
│  ├─ server.csproj
│  ├─ Services
│  │  ├─ AbsenceService.cs
│  │  ├─ AuthService.cs
│  │  ├─ ClassbookService.cs
│  │  ├─ ClassService.cs
│  │  ├─ GradeService.cs
│  │  ├─ SchoolService.cs
│  │  ├─ SituationsService.cs
│  │  ├─ StudentService.cs
│  │  ├─ SubjectService.cs
│  │  └─ TeacherService.cs
│  ├─ SMGMSYSContext.cs
│  ├─ SR.cs
│  └─ Utils
│     ├─ Auth
│     │  ├─ AuthAlgorithms.cs
│     │  ├─ AuthorizeAttribute.cs
│     │  ├─ ITokenGenerator.cs
│     │  ├─ JwtSettings.cs
│     │  └─ TokenGenerator.cs
│     └─ Roles.cs
├─ UI Specifications.docx
├─ Use-Case_Diagram.drawio
└─ ~$ Specifications.docx

```