using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server.Dtos.Classbook;
using server.Models;
using server.Services.Interfaces;

namespace server.Services
{
    public class ClassbookService : IClassbookService
    {
        private readonly SMGMSYSContext _context;
        private readonly IMapper _mapper;

        public ClassbookService(SMGMSYSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SR<GetClassbookDto>> AddClassbook(AddClassbookDto newClassbook)
        {
            var res = new SR<GetClassbookDto>();
            try
            {
                var cls = await _context.dbo_Class.FirstOrDefaultAsync(x => x.Id == newClassbook.ClassId);
                if (cls == null)
                {
                    res.NotFound("Class");
                    return res;
                }
                var classbook = _mapper.Map<dbo_Classbook>(newClassbook);
                await _context.dbo_Classbook.AddAsync(classbook);
                await _context.SaveChangesAsync();

                res.Data = _mapper.Map<GetClassbookDto>(classbook);
            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<object> DeleteClassbookById(int classbookId)
        {
            var res = new SR<List<GetClassbookDto>>();
            try
            {
                var classbook = await _context.dbo_Classbook.FirstOrDefaultAsync(x => x.Id == classbookId);
                if (classbook == null) return new { Message = "Class not found!", Success = false };

                _context.dbo_Classbook.Remove(classbook);
                await _context.SaveChangesAsync();

            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return new { Message = "Classbook deleted" };
        }

        public async Task<SR<List<GetClassbookDto>>> GetAllClassbooks()
        {
            var res = new SR<List<GetClassbookDto>>();
            try
            {
                res.Data = await _context.dbo_Classbook
                    .Include(x=>x.Class)
                    .ThenInclude(x=>x.School)
                    .Select(x => _mapper.Map<GetClassbookDto>(x))
                    .ToListAsync();
            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<List<GetClassbookDto>>> GetAllSchoolClassbooks(int schoolId)
        {
            var res = new SR<List<GetClassbookDto>>();
            try
            {
                res.Data = await _context.dbo_Classbook
                    .Include(x => x.Class)
                    .ThenInclude(x=>x.School)
                    .Where(x => x.Class.SchoolId == schoolId)
                    .Select(x => _mapper.Map<GetClassbookDto>(x))
                    .ToListAsync();
            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<GetClassbookDto>> GetClassbook(int classbookId)
        {
            var res = new SR<GetClassbookDto>();
            try
            {
                var classbook = await _context.dbo_Classbook
                    .Include(x=>x.Class)
                    .ThenInclude(x=>x.School)
                    .Select(x => _mapper.Map<GetClassbookDto>(x))
                    .FirstOrDefaultAsync(x => x.Id == classbookId);
                if (classbook == null)
                {
                    res.NotFound("Classbook");
                    return res;
                }
                res.Data = classbook;
            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<GetClassbookDto>> GetClassbookByClass(int classId)
        {
            var res = new SR<GetClassbookDto>();
            try
            {
                var cls = await _context.dbo_Class.FirstOrDefaultAsync(x => x.Id == classId);
                if (cls == null)
                {
                    res.NotFound("Class");
                    return res;
                }
                var classbook = await _context.dbo_Classbook
                    .Include(x=>x.Class)
                    .ThenInclude(x=>x.School)
                    .Select(x => _mapper.Map<GetClassbookDto>(x))
                    .FirstOrDefaultAsync(x => x.ClassId == classId);
                if (classbook == null)
                {
                    res.NotFound("Classbook");
                    return res;
                }
                res.Data = classbook;
            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<GetClassbookDto>> UpdateClassbookById(int classbookId, UpdateClassbookDto updatedClassbook)
        {
            var res = new SR<GetClassbookDto>();
            try
            {
                var cls = await _context.dbo_Class.FirstOrDefaultAsync(x => x.Id == updatedClassbook.ClassId);
                if (cls == null)
                {
                    res.NotFound("Class");
                    return res;
                }
                var classbook = await _context.dbo_Classbook
                    .Include(x=>x.Class)
                    .ThenInclude(x=>x.School)
                    .FirstOrDefaultAsync(x => x.ClassId == classbookId);
                if (classbook == null)
                {
                    res.NotFound("Classbook");
                    return res;
                }
                classbook.ClassId = updatedClassbook.ClassId;
                await _context.SaveChangesAsync();

                res.Data = _mapper.Map<GetClassbookDto>(classbook);
            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }
    }
}