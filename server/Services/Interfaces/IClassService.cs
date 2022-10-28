using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos.Class;

namespace server.Services.Interfaces
{
    public interface IClassService
    {
        Task<SR<List<GetClassDto>>> GetAllClasses();
        Task<SR<GetClassDto>> GetClassById(int classId);
        Task<SR<GetClassDto>> UpdateClassById(int classId, UpdateClassDto updatedClass);
        Task<SR<GetClassDto>> AddClass(AddClassDto newClass);
        Task<object> DeleteClassById(int classId);
    }
}