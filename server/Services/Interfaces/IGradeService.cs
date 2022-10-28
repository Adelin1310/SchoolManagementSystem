using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server;
using server.Dtos.Grade;
namespace server.Services.Interfaces
{
    public interface IGradeService
    {
        Task<SR<List<GetGradeDto>>> GetAllGrades();
        Task<SR<GetGradeDto>> GetGradeById(int gradeId);
        Task<SR<List<GetGradeDto>>> GetStudentGradesByStudentId(int studentId);
        Task<SR<GetGradeDto>> AddGrade(AddGradeDto newGrade);
        Task<SR<GetGradeDto>> UpdateGradeById(int gradeId, UpdateGradeDto updatedGrade);
        Task<object> DeleteGradeById(int gradeId);
    }
}