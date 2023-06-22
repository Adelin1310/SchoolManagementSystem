using System.Diagnostics;
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

        public async Task<SR<List<GetClassbookDto>>> GetAllTeacherClassbooks(int teacherId)
        {
            var res = new SR<List<GetClassbookDto>>();
            try
            {
                var classes = await _context.dbo_ClassSubject
                    .Where(x => x.TeacherId == teacherId)
                    .Select(x => x.ClassId)
                    .ToListAsync();
                res.Data = await _context.dbo_Classbook
                    .Include(x => x.Class)
                    .Where(x => classes.Contains(x.ClassId))
                    .Select(x => _mapper.Map<GetClassbookDto>(x))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }
        public async Task<SR<List<GetClassbookDto>>> GetAllClassbooks()
        {
            var res = new SR<List<GetClassbookDto>>();
            try
            {
                var data = await _context.dbo_Classbook
                    .Include(x => x.Class)
                    .ThenInclude(x => x.School)
                    .Select(x => _mapper.Map<GetClassbookDto>(x))
                    .ToListAsync();
                res.Data = data;
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
                var data = await _context.dbo_Classbook
                    .Include(x => x.Class)
                    .ThenInclude(x => x.School)
                    .Where(x => x.Class.SchoolId == schoolId)
                    .Select(x => _mapper.Map<GetClassbookDto>(x))
                    .ToListAsync();
                res.Data = data;


            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }
        public async Task<SR<GetClassbookDto>> GetStudentsSituation(int subjectId, int classId, int classbookId, int teacherId)
        {
            var res = new SR<GetClassbookDto>();
            res.Data = new GetClassbookDto();
            try
            {


                var students = await _context.dbo_Student.Where(x => x.ClassId == classId).ToListAsync();
                var requiredGradeCount = await _context.dbo_ClassSubject
                    .Where(x => x.SubjectId == subjectId && x.ClassId == classId)
                    .Select(x => x.RequiredGrades)
                    .FirstOrDefaultAsync();

                res.Data.Students = new List<Dtos.Student.GetStudentWSituationDto>();
                res.Data.SubjectId = subjectId;
                res.Data.isHomeroomTeacher = _context.dbo_Class.FirstOrDefault(x => x.Id == classId).HomeroomTeacherId == teacherId;
                res.Data.Id = classbookId;
                res.Data.ClassId = classId;
                foreach (var s in students)
                {
                    var gradeCount = await _context.dbo_Grade
                            .Where(x => x.StudentId == s.Id && x.ClassbookId == classbookId && x.SubjectId == subjectId)
                            .CountAsync();
                    res.Data.Students.Add(new Dtos.Student.GetStudentWSituationDto
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Grades = await _context.dbo_Grade
                            .Where(x => x.StudentId == s.Id && x.ClassbookId == classbookId && x.SubjectId == subjectId && x.SubjectId == subjectId)
                            .OrderBy(x => x.Date)
                            .Select(x => _mapper.Map<Dtos.Grade.GetGradeDto>(x))
                            .ToListAsync(),
                        Absences = await _context.dbo_Absence
                            .Where(x => x.StudentId == s.Id && x.ClassbookId == classbookId && x.SubjectId == subjectId && x.SubjectId == subjectId)
                            .OrderBy(x => x.Date)
                            .Select(x => _mapper.Map<Dtos.Absence.GetAbsenceDto>(x))
                            .ToListAsync(),
                        Situation = _context.dbo_Situations.FirstOrDefault(x => x.StudentId == s.Id
                            && x.ClassbookId == classbookId
                            && x.SubjectId == subjectId)?.Value,
                        IsEnded = await _context.dbo_Situations.Where(x => x.StudentId == s.Id
                            && x.ClassbookId == classbookId
                            && x.SubjectId == subjectId).CountAsync() != 0,
                        CanEnd = gradeCount >= requiredGradeCount
                    });
                }
            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
                res.StatusCode = StatusCodes.Status500InternalServerError;
            }
            return res;
        }
        public async Task<SR<GetClassbookDto>> GetClassbook(int classbookId, int teacherId)
        {
            var res = new SR<GetClassbookDto>();
            res.Data = new GetClassbookDto();
            try
            {
                var classId = _context.dbo_Classbook
                    .Where(x => x.Id == classbookId)
                    .Select(x => x.ClassId)
                    .First();
                var subject = await _context.dbo_ClassSubject
                    .Where(x => x.ClassId == classId && x.TeacherId == teacherId)
                    .FirstAsync();
                var students = await _context.dbo_Student.Where(x => x.ClassId == classId).ToListAsync();
                res.Data.Students = new List<Dtos.Student.GetStudentWSituationDto>();
                res.Data.SubjectId = subject.SubjectId;
                res.Data.Id = classbookId;
                res.Data.ClassId = classId;
                foreach (var s in students)
                {
                    var gradeCount = await _context.dbo_Grade
                            .Where(x => x.StudentId == s.Id && x.ClassbookId == classbookId && x.SubjectId == subject.SubjectId)
                            .CountAsync();
                    res.Data.Students.Add(new Dtos.Student.GetStudentWSituationDto
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Grades = await _context.dbo_Grade
                            .Where(x => x.StudentId == s.Id && x.ClassbookId == classbookId && x.SubjectId == subject.SubjectId)
                            .Select(x => _mapper.Map<Dtos.Grade.GetGradeDto>(x))
                            .ToListAsync(),
                        Absences = await _context.dbo_Absence
                            .Where(x => x.StudentId == s.Id && x.ClassbookId == classbookId && x.SubjectId == subject.SubjectId)
                            .Select(x => _mapper.Map<Dtos.Absence.GetAbsenceDto>(x))
                            .ToListAsync(),
                        Situation = _context.dbo_Situations.FirstOrDefault(x => x.StudentId == s.Id
                        && x.ClassbookId == classbookId
                        && x.SubjectId == subject.SubjectId)?.Value,
                        IsEnded = await _context.dbo_Situations.Where(x => x.StudentId == s.Id
                        && x.ClassbookId == classbookId
                        && x.SubjectId == subject.SubjectId).CountAsync() != 0,
                        CanEnd = gradeCount >= subject.RequiredGrades,
                    });
                }
            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
                res.StatusCode = StatusCodes.Status500InternalServerError;
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
                    .Include(x => x.Class)
                    .ThenInclude(x => x.School)
                    .Where(x => x.ClassId == classId)
                    .Select(x => _mapper.Map<GetClassbookDto>(x)).FirstAsync();
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
                    .Include(x => x.Class)
                    .ThenInclude(x => x.School)
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