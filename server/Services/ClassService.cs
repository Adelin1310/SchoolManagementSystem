using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server.Dtos.Class;
using server.Models;
using server.Services.Interfaces;

namespace server.Services
{
    public class ClassService : IClassService

    {
        private readonly SMGMSYSContext _context;
        private readonly IMapper _mapper;

        public ClassService(SMGMSYSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SR<GetClassDto>> AddClass(AddClassDto newClass)
        {
            var res = new SR<GetClassDto>();
            try
            {
                var school= await _context.dbo_School.FirstOrDefaultAsync(x=>x.Id == newClass.SchoolId);
                if(school == null){
                    res.NotFound("School");
                    return res;
                }
                
                var mappedClass = _mapper.Map<dbo_Class>(newClass);
                await _context.dbo_Class.AddAsync(mappedClass);
                await _context.SaveChangesAsync();
                
                res.Data = _mapper.Map<GetClassDto>(mappedClass);
            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<List<GetClassDto>>> AddSecondaryEducationNoHSClasses(char[] names, int schoolId)
        {
            var res = new SR<List<GetClassDto>>();
            try
            {
                var school = await _context.dbo_School.FirstOrDefaultAsync(x=>x.Id == schoolId);
                if(school == null){
                    res.NotFound("School");
                    return res;
                }
                
            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<object> DeleteClassById(int classId)
        {
            try
            {
                var cls = await _context.dbo_Class.FirstOrDefaultAsync(x => x.Id == classId);
                if (cls != null)
                {
                    _context.dbo_Class.Remove(cls);
                    await _context.SaveChangesAsync();
                    return new { Message = "Class deleted successfully!", Success = true };
                }
                else return new { Message = "Class not found!", Success = false };
            }
            catch (System.Exception ex)
            {
                return new { Message = ex.Message, Success = false };
            }
        }

        public async Task<SR<List<GetClassDto>>> GetAllClasses()
        {
            var res = new SR<List<GetClassDto>>();
            try
            {
                res.Data = await _context.dbo_Class
                    .Include(x=>x.School)
                    .Select(x => _mapper.Map<GetClassDto>(x)).ToListAsync();
            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<GetClassDto>> GetClassById(int classId)
        {
            var res = new SR<GetClassDto>();
            try
            {
                var cls = await _context.dbo_Class.FirstOrDefaultAsync(x => x.Id == classId);
                if (cls == null) { res.NotFound("Class"); return res; }
                else res.Data = _mapper.Map<GetClassDto>(cls);
            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<GetClassDto>> UpdateClassById(int classId, UpdateClassDto updatedClass)
        {
            var res = new SR<GetClassDto>();
            try
            {
                var cls = await _context.dbo_Class.FirstOrDefaultAsync(x => x.Id == classId);
                if (cls == null) { res.NotFound("Class"); return res; }
                else
                {
                    cls.SchoolId = updatedClass.SchoolId;
                    cls.Name = updatedClass.Name;
                    await _context.SaveChangesAsync();
                    res.Data = _mapper.Map<GetClassDto>(cls);
                }
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