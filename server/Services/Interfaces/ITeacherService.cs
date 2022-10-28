using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos.Teacher;

namespace server.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<SR<List<GetTeacherDto>>> GetAllTeachers();
        Task<SR<List<GetTeacherDto>>> GetAllTeachersBySchoolId(int schoolId);
        Task<SR<GetTeacherDto>> GetTeacherById(int teacherId);
        Task<SR<GetTeacherDto>> AddTeacher(AddTeacherDto newTeacher);
        Task<SR<GetTeacherDto>> UpdateTeacherById(int teacherId, UpdateTeacherDto updatedTeacher);
        Task<object> DeleteTeacherById(int teacherId);
    }
}