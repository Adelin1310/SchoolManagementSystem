using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server.Dtos.Grade;
using server.Models;
using server.Services.Interfaces;

namespace server.Services
{
    public class GradeService : IGradeService
    {
        private readonly SMGMSYSContext _context;
        private readonly IMapper _mapper;

        public GradeService(SMGMSYSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SR<GetGradeDto>> AddGrade(AddGradeDto newGrade)
        {
            var res = new SR<GetGradeDto>();
            try
            {
                var grade = _mapper.Map<dbo_Grade>(newGrade);
                var student = await _context.dbo_Student.FirstOrDefaultAsync(x => x.Id == newGrade.StudentId);
                var subject = await _context.dbo_Subject.FirstOrDefaultAsync(x => x.Id == newGrade.SubjectId);
                if (student == null)
                {
                    res.NotFound("Student");
                    return res;
                }
                if (subject == null)
                {
                    res.NotFound("Subject");
                    return res;
                }
                await _context.dbo_Grade.AddAsync(grade);
                await _context.SaveChangesAsync();
                res.Data = _mapper.Map<GetGradeDto>(grade);
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<object> DeleteGradeById(int gradeId)
        {
            var res = new SR<List<GetGradeDto>>();
            try
            {
                var grade = await _context.dbo_Grade.FirstOrDefaultAsync(x => x.Id == gradeId);
                if (grade == null)
                {
                    res.NotFound("Grade");
                    return res;
                }
                _context.dbo_Grade.Remove(grade);
                await _context.SaveChangesAsync();
                return new { Message = "Grade deleted successfully!", Success = true };
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<List<GetGradeDto>>> GetAllGrades()
        {
            var res = new SR<List<GetGradeDto>>();
            try
            {
                res.Data = await _context.dbo_Grade
                    .Include(x => x.Subject)
                    .Include(x => x.Student)
                    .Select(x => _mapper.Map<GetGradeDto>(x))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<GetGradeDto>> GetGradeById(int gradeId)
        {
            var res = new SR<GetGradeDto>();
            try
            {
                var grade = await _context.dbo_Grade
                    .Include(x => x.Student)
                    .Include(x => x.Subject)
                    .FirstOrDefaultAsync(x => x.Id == gradeId);
                if (grade == null)
                {
                    res.NotFound("Grade");
                    return res;
                }
                res.Data = _mapper.Map<GetGradeDto>(grade);
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<List<GetGradeDto>>> GetStudentGradesByStudentId(int studentId)
        {
            var res = new SR<List<GetGradeDto>>();
            try
            {
                var student = await _context.dbo_Student.FirstOrDefaultAsync(x => x.Id == studentId);
                if (student == null)
                {
                    res.NotFound("Student");
                    return res;
                }
                res.Data = await _context.dbo_Grade
                    .Select(x => _mapper.Map<GetGradeDto>(x))
                    .Where(x => x.StudentId == studentId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<GetGradeDto>> UpdateGradeById(int gradeId, UpdateGradeDto updatedGrade)
        {
            var res = new SR<GetGradeDto>();
            try
            {
                var grade = await _context.dbo_Grade
                    .Include(x => x.Student)
                    .Include(x => x.Subject)
                    .FirstOrDefaultAsync(x => x.Id == gradeId);
                var student = await _context.dbo_Student.FirstOrDefaultAsync(x=>x.Id == updatedGrade.StudentId);
                var subject = await _context.dbo_Subject.FirstOrDefaultAsync(x=>x.Id == updatedGrade.SubjectId);
                if(subject == null){
                    res.NotFound("Subject");
                    return res;
                }
                if(student == null){
                    res.NotFound("Student");
                    return res;
                }
                if (grade == null)
                {
                    res.NotFound("Grade");
                    return res;
                }

                grade.Date = updatedGrade.Date;
                grade.StudentId = updatedGrade.StudentId;
                grade.SubjectId = updatedGrade.SubjectId;
                grade.Value = updatedGrade.Value;

                await _context.SaveChangesAsync();
                res.Data = _mapper.Map<GetGradeDto>(grade);
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