using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server.Dtos.Subject;
using server.Models;
using server.Services.Interfaces;

namespace server.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly SMGMSYSContext _context;
        private readonly IMapper _mapper;

        public SubjectService(SMGMSYSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<SR<List<GetSubjectDto>>> GetTeacherClassSubjects(int classId, int teacherId)
        {
            var res = new SR<List<GetSubjectDto>>();
            try
            {
                res.Data = await _context.dbo_ClassSubject
                    .Where(x => x.ClassId == classId && x.TeacherId == teacherId)
                    .Include(x => x.Subject)
                    .Select(x => _mapper.Map<GetSubjectDto>(x.Subject))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }
        public async Task<SR<List<GetStudentSituationDto>>> GetStudentSituation(int studentId, int classId)
        {
            var res = new SR<List<GetStudentSituationDto>>();
            try
            {
                var subjects = await _context.dbo_ClassSubject
                    .Include(x => x.Subject)
                    .Where(x => x.ClassId == classId)
                    .Select(x => new { Id = x.SubjectId, Name = x.Subject.Name })
                    .ToListAsync();
                var classbook = await _context.dbo_Classbook
                    .OrderBy(x => x.Id)
                    .LastOrDefaultAsync(x => x.ClassId == classId);
                res.Data = new List<GetStudentSituationDto>();
                foreach (var s in subjects)
                {
                    var grades = await _context.dbo_Grade
                    .Where(x => x.StudentId == studentId && x.SubjectId == s.Id)
                    .Select(x => _mapper.Map<Dtos.Grade.GetGradeDto>(x))
                    .ToListAsync();

                    var absences = await _context.dbo_Absence
                    .Where(x => x.StudentId == studentId && x.SubjectId == s.Id)
                    .Select(x => _mapper.Map<Dtos.Absence.GetAbsenceDto>(x))
                    .ToListAsync();
                    var situation = await _context.dbo_Situations
                        .FirstOrDefaultAsync(x => x.StudentId == studentId
                        && x.ClassbookId == classbook.Id && x.SubjectId == s.Id);
                    res.Data.Add(new GetStudentSituationDto
                    {
                        Subject = s.Name,
                        Grades = grades,
                        Absences = absences,
                        Situation = situation?.Value
                    });
                }
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }
        public async Task<SR<List<GetSubjectDto>>> GetAllClassSubjects(int classId)
        {
            var res = new SR<List<GetSubjectDto>>();
            try
            {
                res.Data = await _context.dbo_ClassSubject
                    .Where(x => x.ClassId == classId)
                    .Include(x => x.Subject)
                    .Select(x => _mapper.Map<GetSubjectDto>(x.Subject))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }
        public async Task<SR<GetSubjectDto>> AddSubject(AddSubjectDto newSubject)
        {
            var res = new SR<GetSubjectDto>();
            try
            {
                var mappedSubject = _mapper.Map<dbo_Subject>(newSubject);
                await _context.dbo_Subject.AddAsync(mappedSubject);
                await _context.SaveChangesAsync();
                res.Data = _mapper.Map<GetSubjectDto>(mappedSubject);
            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<object> DeleteSubjectById(int subjectId)
        {
            var subject = await _context.dbo_Subject.FirstOrDefaultAsync(x => x.Id == subjectId);
            if (subject == null) return new { Message = "Subject not found" };
            _context.dbo_Subject.Remove(subject);
            await _context.SaveChangesAsync();
            return new { Message = "Subject removed successfully!" };
        }

        public async Task<SR<List<GetSubjectDto>>> GetAllSubjects()
        {
            var res = new SR<List<GetSubjectDto>>();
            res.Data = await _context.dbo_Subject
                .Select(x => _mapper.Map<GetSubjectDto>(x))
                .ToListAsync();
            return res;
        }

        public async Task<SR<GetSubjectDto>> UpdateSubjectById(int subjectId, UpdateSubjectDto updatedSubject)
        {
            var res = new SR<GetSubjectDto>();
            var oldSubject = await _context.dbo_Subject.FirstOrDefaultAsync(x => x.Id == subjectId);
            if (oldSubject == null) res.NotFound("Subject");
            else
            {
                oldSubject.Name = updatedSubject.Name;
                await _context.SaveChangesAsync();
                res.Data = _mapper.Map<GetSubjectDto>(oldSubject);
            }
            return res;
        }
    }
}