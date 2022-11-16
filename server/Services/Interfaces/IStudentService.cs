using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos.Student;

namespace server.Services.Interfaces
{
    public interface IStudentService
    {
        Task<SR<List<GetStudentDto>>> GetAllStudents();
        Task<SR<GetStudentDto>> GetStudentById(int studentId);
        Task<SR<List<GetStudentDto>>> GetAllStudentsByClassId(int classId);
        Task<SR<List<GetStudentDto>>> GetAllStudentsBySchoolId(int schoolId);
        Task<SR<GetStudentDto>> AddStudent(AddStudentDto newStudent);
        Task<SR<GetStudentDto>> UpdateStudentById(int studentId, UpdateStudentDto updatedStudent);
        Task<SR<object>> DeleteStudentById(int studentId);
    }
}