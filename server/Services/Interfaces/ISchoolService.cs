using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos.School;

namespace server.Services.Interfaces
{
    public interface ISchoolService
    {
        Task<SR<List<GetSchoolDto>>> GetAllSchools();
        Task<SR<List<GetSchoolDto>>> GetAllSchoolsOrderedByStudents();
        Task<SR<GetSchoolDto>> AddSchool(AddSchoolDto newSchool);
        Task<object> DeleteSchoolById (int schoolId);
        Task<SR<GetSchoolDto>> UpdateSchoolById(int schoolId, UpdateSchoolDto updatedSchool);
    }
}