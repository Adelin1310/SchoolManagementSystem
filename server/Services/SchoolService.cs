using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server.Dtos.School;
using server.Models;
using server.Services.Interfaces;

namespace server.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly IMapper _mapper;
        private readonly SMGMSYSContext _context;
        public SchoolService(SMGMSYSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SR<GetSchoolDto>> AddSchool(AddSchoolDto newSchool)
        {
            var res = new SR<GetSchoolDto>();
            try
            {
                var school = _context.dbo_School.Add(_mapper.Map<dbo_School>(newSchool)).Entity;
                await _context.SaveChangesAsync();
                res.Data = _mapper.Map<GetSchoolDto>(school);
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<object> DeleteSchoolById(int schoolId)
        {
            try
            {
                var school = await _context.dbo_School.FirstOrDefaultAsync(x => x.Id == schoolId);
                if (school != null)
                {
                    _context.dbo_School.Remove(school);
                    await _context.SaveChangesAsync();
                }
                else return new { Message = $"School not found!", Success = false };
                return new { Message = $"School removed successfully!", Success = true };
            }
            catch (Exception ex)
            {
                return new { Message = ex.Message, Success = false };
            }
        }

        public async Task<SR<List<GetSchoolDto>>> GetAllSchools()
        {
            var res = new SR<List<GetSchoolDto>>();
            try
            {
                res.Data = await _context.dbo_School
                        .Select(x => _mapper.Map<GetSchoolDto>(x))
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<List<GetSchoolDto>>> GetAllSchoolsOrderedByStudents()
        {
            var res = new SR<List<GetSchoolDto>>();
            try
            {
                res.Data = await _context.dbo_School
                        .OrderByDescending(x => _context.dbo_Student.Where(y => y.SchoolId == x.Id).ToArray().Count())
                        .Select(x => _mapper.Map<GetSchoolDto>(x))
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<GetSchoolDto>> UpdateSchoolById(int schoolId, UpdateSchoolDto updatedSchool)
        {
            var res = new SR<GetSchoolDto>();
            try
            {
                var oldSchool = await _context.dbo_School.FirstOrDefaultAsync(x => x.Id == schoolId);
                if (oldSchool == null) res.NotFound("School");
                else
                {
                    oldSchool.Name = updatedSchool.Name;
                    await _context.SaveChangesAsync();
                    res.Data = _mapper.Map<GetSchoolDto>(oldSchool);
                }
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