using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server.Dtos.Absence;
using server.Models;
using server.Services.Interfaces;

namespace server.Services
{
    public class AbsenceService : IAbsenceService
    {
        public SMGMSYSContext _context { get; }
        public IMapper _mapper { get; }
        public AbsenceService(SMGMSYSContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<SR<List<GetAbsenceDto>>> GetAllAbsences()
        {
            var res = new SR<List<GetAbsenceDto>>();
            try
            {
                res.Data = await _context.dbo_Absence
                    .Select(x => _mapper.Map<GetAbsenceDto>(x))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<List<GetAbsenceDto>>> GetAllClassAbsences(int classId)
        {
            var res = new SR<List<GetAbsenceDto>>();
            try
            {
                res.Data = await _context.dbo_Absence
                    .Include(x => x.Student)
                    .Where(x => x.Student.ClassId == classId)
                    .Select(x => _mapper.Map<GetAbsenceDto>(x))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<List<GetAbsenceDto>>> GetAllSchoolAbsences(int schoolId)
        {
            var res = new SR<List<GetAbsenceDto>>();
            try
            {
                res.Data = await _context.dbo_Absence
                    .Where(x => x.Student.SchoolId == schoolId)
                    .Select(x => _mapper.Map<GetAbsenceDto>(x))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<List<GetAbsenceDto>>> GetAllStudentAbsences(int studentId)
        {
            var res = new SR<List<GetAbsenceDto>>();
            try
            {
                var student = await _context.dbo_Student.FirstOrDefaultAsync(x => x.Id == studentId);
                if (student == null)
                {
                    res.NotFound("Student");
                    return res;
                }
                res.Data = await _context.dbo_Absence
                    .Where(x => x.StudentId == studentId)
                    .Select(x => _mapper.Map<GetAbsenceDto>(x))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<GetAbsenceDto>> GetAbsenceById(int absenceId)
        {
            var res = new SR<GetAbsenceDto>();
            try
            {
                var absence = await _context.dbo_Absence.FirstOrDefaultAsync(x => x.Id == absenceId);
                if (absence == null)
                {
                    res.NotFound("Absence");
                    return res;
                }
                res.Data = _mapper.Map<GetAbsenceDto>(absence);
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<GetAbsenceDto>> AddAbsence(AddAbsenceDto newAbsence)
        {
            var res = new SR<GetAbsenceDto>();
            try
            {
                var absence = _mapper.Map<dbo_Absence>(newAbsence);
                await _context.dbo_Absence.AddAsync(absence);
                await _context.SaveChangesAsync();
                res.Data = _mapper.Map<GetAbsenceDto>(absence);
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<GetAbsenceDto>> UpdateAbsenceById(UpdateAbsenceDto updatedAbsence, int teacherId)
        {
            var res = new SR<GetAbsenceDto>();
            try
            {
                var absence = await _context.dbo_Absence
                    .Include(x => x.Classbook).ThenInclude(x => x.Class)
                    .FirstOrDefaultAsync(x => x.Id == updatedAbsence.Id);
                if (absence == null)
                {
                    res.NotFound("Absence");
                    return res;
                }
                if (absence.Classbook.Class.HomeroomTeacherId != teacherId)
                {
                    res.StatusCode = StatusCodes.Status401Unauthorized;
                    res.Message = "Teacher is not homeroom teacher!";
                    res.Success = false;
                    return res;
                }
                absence.WithLeave = true;
                await _context.SaveChangesAsync();

                res.Data = _mapper.Map<GetAbsenceDto>(absence);
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<object> DeleteAbsenceById(int absenceId)
        {
            var res = new SR<GetAbsenceDto>();
            try
            {
                var absence = await _context.dbo_Absence.FirstOrDefaultAsync(x => x.Id == absenceId);
                if (absence == null)
                    return new { Message = "Absence not found!", Success = false };
                _context.dbo_Absence.Remove(absence);
                await _context.SaveChangesAsync();
                return new { Message = "Absence deleted successfully!", Success = true };

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