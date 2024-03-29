using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos.Classbook;

namespace server.Services.Interfaces
{
    public interface IClassbookService
    {
        Task<SR<GetClassbookDto>> AddClassbook(AddClassbookDto newClassbook);
        Task<SR<List<GetClassbookDto>>> GetAllClassbooks();
        Task<SR<List<GetClassbookDto>>> GetAllSchoolClassbooks(int schoolId);
        Task<SR<GetClassbookDto>> GetClassbook(int classbookId);
        Task<SR<GetClassbookDto>> GetClassbookByClass(int classId);
        Task<SR<GetClassbookDto>> UpdateClassbookById(int classbookId, UpdateClassbookDto updatedClassbook);
        Task<object> DeleteClassbookById(int classbookId);
    }
}