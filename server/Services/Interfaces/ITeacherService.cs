using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos.SchoolTeacher;
using server.Dtos.Teacher;
using server.Dtos.TeacherSubject;

namespace server.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<SR<List<GetTeacherDto>>> GetAllTeachers();
        Task<SR<List<GetTeacherWSchoolsAndSubjectsDto>>> GetAllTeachersWithSchoolsAndSubjects();
        Task<SR<List<GetTeacherDto>>> GetAllTeachersBySchoolId(int schoolId);
        Task<SR<GetTeacherDto>> GetTeacherById(int teacherId);
        Task<SR<GetTeacherWClassesAndSubjectsDto>> GetTeacherWClassesAndSubjects(int schoolId, int teacherId);
        Task<SR<GetTeacherDto>> AddTeacher(AddTeacherDto newTeacher);
        Task<SR<GetTeacherDto>> UpdateTeacherById(int teacherId, UpdateTeacherDto updatedTeacher);
        Task<SR<GetTeacherDto>> AssignTeacherToSchool(AddSchoolTeacherDto newSchoolTeacher);
        Task<SR<GetTeacherDto>> AssignSubjectToTeacher(AddTeacherSubjectDto newTeacherSubject);
        Task<SR<List<GetTeacherWSubject>>> GetTeachersByClassId(int classId);

        Task<object> DeleteTeacherById(int teacherId);
    }
}