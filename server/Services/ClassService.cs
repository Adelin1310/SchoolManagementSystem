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
                var school = await _context.dbo_School.FirstOrDefaultAsync(x => x.Id == newClass.SchoolId);
                if (school == null)
                {
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

        public async Task<SR<List<GetClassDto>>> AddSecondaryEducationNoHSClasses(string[] names, int schoolId)
        {
            var res = new SR<List<GetClassDto>>();
            try
            {
                var school = await _context.dbo_School.FirstOrDefaultAsync(x => x.Id == schoolId);
                if (school == null)
                {
                    res.NotFound("School");
                    return res;
                }
                var classes = new List<dbo_Class>();
                foreach (var name in names)
                {
                    classes.Add(_mapper.Map<dbo_Class>(new AddClassDto
                    {
                        Name = name,
                        SchoolId = schoolId
                    }));
                }
                await _context.dbo_Class.AddRangeAsync(classes);
                await _context.SaveChangesAsync();
                res.Data = classes.Select(x => _mapper.Map<GetClassDto>(x)).ToList();
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

        public async Task<SR<List<GetClassSubjectDto>>> GetAllTeacherClasses(int teacherId)
        {
            var res = new SR<List<GetClassSubjectDto>>();
            try
            {
                res.Data = _context.dbo_ClassSubject
                    .Include(x => x.Class).ThenInclude(x => x.ClassSpecialization)
                    .Include(x => x.Class).ThenInclude(x => x.HomeroomTeacher)
                    .Include(x => x.Subject)
                    .Where(x => x.TeacherId == teacherId)
                    .Select(x => _mapper.Map<GetClassSubjectDto>(x))
                    .ToList().DistinctBy(x => x.Id).ToList();
                res.Data.ForEach(async x =>
                {
                    x.StudentsCount = await _context.dbo_Student.Where(y => y.ClassId == x.Id).CountAsync();
                    x.ClassbookId = await _context.dbo_Classbook.Where(y => y.ClassId == x.Id).Select(y => y.Id).FirstOrDefaultAsync();
                });
            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }
        public async Task<SR<List<GetClassDto>>> GetAllClasses()
        {
            var res = new SR<List<GetClassDto>>();
            try
            {
                res.Data = await _context.dbo_Class
                    .Include(x => x.School)
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

        public async Task<SR<GetStudentClassDto>> GetStudentClass(string sessionID)
        {
            var res = new SR<GetStudentClassDto>();
            try
            {
                if (sessionID == null)
                {
                    res.SetSessionExpiredError();
                    return res;
                }
                var session = await _context.dbo_Session.Include(s => s.User).ThenInclude(u => u.Role).FirstOrDefaultAsync(s => s.Id == sessionID);
                if (session == null)
                {
                    res.SetSessionExpiredError();
                    return res;
                }
                var student = await _context.dbo_Student.FirstOrDefaultAsync(s => s.UserId == session.UserId);
                if (student == null)
                {
                    res.SetError();
                    return res;
                }
                var student_class = await _context.dbo_Class
                    .Include(c => c.ClassSpecialization)
                    .Include(c => c.HomeroomTeacher)
                    .FirstOrDefaultAsync(c => c.Id == student.ClassId);
                if (student_class == null)
                {
                    res.SetError();
                    return res;
                }
                var students = await _context.dbo_Student
                    .Where(s => s.ClassId == student_class.Id)
                    .Select(s => _mapper.Map<Dtos.Student.GetStudentDto>(s))
                    .ToListAsync();
                var classleader = await _context.dbo_ClassLeader
                    .Include(cl => cl.ClassLeader)
                    .FirstOrDefaultAsync(cl => cl.ClassId == student.ClassId);
                res.Data = _mapper.Map<GetStudentClassDto>(student_class);
                res.Data.Students = students;
                res.Data.StudentsCount = students.Count;
                res.Data.ClassLeader = $"{classleader.ClassLeader.FirstName} {classleader.ClassLeader.LastName}";
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
                res.StatusCode = StatusCodes.Status500InternalServerError;
            }
            return res;
        }
    }
}