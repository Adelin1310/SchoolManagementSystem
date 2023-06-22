using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server.Dtos.SchoolTeacher;
using server.Dtos.Teacher;
using server.Dtos.TeacherSubject;
using server.Models;
using server.Services.Interfaces;

namespace server.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly SMGMSYSContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public TeacherService(SMGMSYSContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<SR<GetTeacherDto>> AddTeacher(AddTeacherDto newTeacher)
        {
            var res = new SR<GetTeacherDto>();
            try
            {
                var teacher = _mapper.Map<dbo_Teacher>(newTeacher);
                teacher.Photo = _configuration.GetSection("Defaults:ProfilePhoto").Get<string>();
                await _context.dbo_Teacher.AddAsync(teacher);
                await _context.SaveChangesAsync();
                var teacher_subjects = new List<AddTeacherSubjectDto>();
                
                foreach (var subjectId in newTeacher.Subjects)
                {
                    teacher_subjects.Add(new AddTeacherSubjectDto
                    {
                        SubjectId = subjectId,
                        TeacherId = teacher.Id
                    });
                }
                await _context.dbo_TeacherSubject.AddRangeAsync(teacher_subjects.Select(ts=>_mapper.Map<dbo_TeacherSubject>(ts)));
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

        public async Task<SR<GetTeacherDto>> AssignSubjectToTeacher(AddTeacherSubjectDto newTeacherSubject)
        {
            var res = new SR<GetTeacherDto>();
            try
            {
                var teacher = await _context.dbo_Teacher.FirstOrDefaultAsync(x => x.Id == newTeacherSubject.TeacherId);
                var subject = await _context.dbo_Subject.FirstOrDefaultAsync(x => x.Id == newTeacherSubject.SubjectId);
                if (teacher == null || subject == null)
                {
                    res.NotFound("Teacher or subject");
                    return res;
                }
                await _context.dbo_TeacherSubject.AddAsync(_mapper.Map<dbo_TeacherSubject>(newTeacherSubject));
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

        public async Task<SR<GetTeacherDto>> AssignTeacherToSchool(AddSchoolTeacherDto newSchoolTeacher)
        {
            var res = new SR<GetTeacherDto>();
            try
            {
                var teacher = await _context.dbo_Teacher.FirstOrDefaultAsync(x => x.Id == newSchoolTeacher.TeacherId);
                var school = await _context.dbo_School.FirstOrDefaultAsync(x => x.Id == newSchoolTeacher.SchoolId);

                if (teacher == null || school == null)
                {
                    res.NotFound("School or Teachr");
                    return res;
                }
                if (await _context.dbo_SchoolTeacher.FirstOrDefaultAsync(x => x.SchoolId == newSchoolTeacher.SchoolId && x.TeacherId == newSchoolTeacher.TeacherId) == null)
                {
                    await _context.dbo_SchoolTeacher.AddAsync(_mapper.Map<dbo_SchoolTeacher>(newSchoolTeacher));
                    await _context.SaveChangesAsync();
                }
                else
                {
                    res.Message = "Teacher is already assigned to this school";
                    res.Success = false;
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

        public async Task<SR<List<GetTeacherWSchoolsAndSubjectsDto>>> GetAllTeachersWithSchoolsAndSubjects()
        {
            var res = new SR<List<GetTeacherWSchoolsAndSubjectsDto>>();
            try
            {
                res.Data = await _context.dbo_Teacher.Select(x => _mapper.Map<GetTeacherWSchoolsAndSubjectsDto>(x)).ToListAsync();
                res.Data.ForEach(async x => x.Schools = await GetSchools(x.Id));
                res.Data.ForEach(async x => x.Subjects = await GetSubjects(x.Id));
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }
        public async Task<SR<GetTeacherWClassesAndSubjectsDto>> GetTeacherWClassesAndSubjects(int schoolId, int teacherId)
        {

            var res = new SR<GetTeacherWClassesAndSubjectsDto>();
            try
            {
                res.Data = await _context.dbo_Teacher
                    .Where(x => x.Id == teacherId)
                    .Select(x => _mapper.Map<GetTeacherWClassesAndSubjectsDto>(x)).FirstAsync();
                var school_classes = await _context.dbo_Class
                    .Where(cls => cls.SchoolId == schoolId)
                    .Select(cls => cls.Id)
                    .ToListAsync();
                var classes_subjects = await _context.dbo_ClassSubject
                    .Include(cls => cls.Subject)
                    .Include(cls => cls.Class)
                    .Where(cls => cls.TeacherId == teacherId && school_classes.Contains(cls.ClassId))
                    .Select(cls => _mapper.Map<GetClassWSubjectDto>(cls))
                    .ToListAsync();
                var subjects = await _context.dbo_TeacherSubject
                    .Include(tcs => tcs.Subject)
                    .Where(tcs => tcs.TeacherId == teacherId)
                    .Select(tcs => tcs.Subject.Name)
                    .ToListAsync();
                res.Data.Classes = classes_subjects;
                res.Data.Subjects = subjects;
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<List<GetTeacherWSubject>>> GetTeachersByClassId(int classId)
        {
            var res = new SR<List<GetTeacherWSubject>>();
            try
            {
                res.Data = await _context.dbo_ClassSubject
                    .Include(cs => cs.Teacher)
                    .Include(cs => cs.Subject)
                    .Where(cs => cs.ClassId == classId)
                    .Select(cs => _mapper.Map<GetTeacherWSubject>(cs))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
                res.StatusCode = StatusCodes.Status500InternalServerError;
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
                var teacher = await _context.dbo_Teacher.FirstOrDefaultAsync(x => x.Id == teacherId);
                if (teacher == null)
                {
                    res.NotFound("Teacher");
                    return res;
                }
                teacher.Address = updatedTeacher.Address;
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

        //Helper methods for getting a teacher and his/her schools and subjects
        private async Task<List<string>> GetSchools(int teacherId) => await _context.dbo_SchoolTeacher
            .Include(x => x.School)
            .Where(x => x.TeacherId == teacherId)
            .Select(x => x.School.Name)
            .ToListAsync();

        private async Task<List<string>> GetSubjects(int teacherId) => await _context.dbo_TeacherSubject
            .Include(x => x.Subject)
            .Where(x => x.TeacherId == teacherId)
            .Select(x => x.Subject.Name)
            .ToListAsync();
    }
}