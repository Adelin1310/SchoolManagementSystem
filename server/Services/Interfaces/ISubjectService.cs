using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos.Subject;
using server.Models;
namespace server.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<SR<List<GetStudentSituationDto>>> GetStudentSituation(int studentId, int classId);
        Task<SR<List<GetSubjectDto>>> GetAllClassSubjects(int classId);
        Task<SR<List<GetSubjectDto>>> GetTeacherClassSubjects(int classId, int teacherId);
        Task<SR<List<GetSubjectDto>>> GetAllSubjects();
        Task<SR<GetSubjectDto>> AddSubject(AddSubjectDto newSubject);
        Task<SR<GetSubjectDto>> UpdateSubjectById(int subjectId, UpdateSubjectDto updatedSubject);
        Task<object> DeleteSubjectById(int subjectId);
    }
}