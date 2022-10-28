using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server.Dtos.Teacher;
using server.Models;
using server.Services.Interfaces;

namespace server.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly SMGMSYSContext _context;
        private readonly IMapper _mapper;

        public TeacherService(SMGMSYSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SR<GetTeacherDto>> AddTeacher(AddTeacherDto newTeacher)
        {
            var res = new SR<GetTeacherDto>();
            try
            {
                var teacher = _mapper.Map<dbo_Teacher>(newTeacher);
                await _context.dbo_Teacher.AddAsync(teacher);
                await _context.SaveChangesAsync();
                res.Data = _mapper.Map<GetTeacherDto>(teacher);
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<object> DeleteTeacherById(int teacherId)
        {
            var res = new SR<List<GetTeacherDto>>();
            try
            {
                var teacher = await _context.dbo_Teacher.FirstOrDefaultAsync(x => x.Id == teacherId);
                if (teacher == null)
                    return new { Message = "Teacher not found!", Success = false };
                _context.dbo_Teacher.Remove(teacher);
                await _context.SaveChangesAsync();
                return new { Message = "Teacher deleted successfully!", Success = true };
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<List<GetTeacherDto>>> GetAllTeachers()
        {
            var res = new SR<List<GetTeacherDto>>();
            try
            {
                res.Data = await _context.dbo_Teacher.Select(x => _mapper.Map<GetTeacherDto>(x)).ToListAsync();
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<List<GetTeacherDto>>> GetAllTeachersBySchoolId(int schoolId)
        {
            var res = new SR<List<GetTeacherDto>>();
            try
            {
                var school = await _context.dbo_School.FirstOrDefaultAsync(x => x.Id == schoolId);
                if (school == null)
                {
                    res.NotFound("School");
                    return res;
                }
                var teachersIds = await _context.dbo_SchoolTeacher.Where(x => x.SchoolId == schoolId).Select(x => x.TeacherId).ToListAsync();
                res.Data = await _context.dbo_Teacher.Select(x => _mapper.Map<GetTeacherDto>(x)).Where(x => teachersIds.Contains(x.Id)).ToListAsync();
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<GetTeacherDto>> GetTeacherById(int teacherId)
        {
            var res = new SR<GetTeacherDto>();
            try
            {
                var teacher = await _context.dbo_Teacher.FirstOrDefaultAsync(x => x.Id == teacherId);
                if (teacher == null)
                {
                    res.NotFound("Teacher");
                    return res;
                }
                res.Data = _mapper.Map<GetTeacherDto>(teacher);

            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<GetTeacherDto>> UpdateTeacherById(int teacherId, UpdateTeacherDto updatedTeacher)
        {
            var res = new SR<GetTeacherDto>();
            try
            {
                var teacher = await _context.dbo_Teacher.FirstOrDefaultAsync(x=>x.Id == teacherId);
                if(teacher == null)
                {
                    res.NotFound("Teacher");
                    return res;
                }
                teacher.Address = updatedTeacher.Address;
                teacher.Age = updatedTeacher.Age;
                teacher.FirstName = updatedTeacher.FirstName;
                teacher.LastName = updatedTeacher.LastName;

                await _context.SaveChangesAsync();
                res.Data = _mapper.Map<GetTeacherDto>(teacher);
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }
    }
}