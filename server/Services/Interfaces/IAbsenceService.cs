using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos.Absence;

namespace server.Services.Interfaces
{
    public interface IAbsenceService
    {
        Task<SR<List<GetAbsenceDto>>> GetAllAbsences();
        Task<SR<List<GetAbsenceDto>>> GetAllSchoolAbsences(int schoolId);
        Task<SR<List<GetAbsenceDto>>> GetAllClassAbsences(int classId);
        Task<SR<List<GetAbsenceDto>>> GetAllStudentAbsences(int studentId);
        Task<SR<GetAbsenceDto>> GetAbsenceById(int absenceId);
        Task<SR<GetAbsenceDto>> AddAbsence(AddAbsenceDto newAbsence);
        Task<SR<GetAbsenceDto>> UpdateAbsenceById(int absenceId, UpdateAbsenceDto updatedAbsence);
        Task<object> DeleteAbsenceById(int absenceId);
    }
}