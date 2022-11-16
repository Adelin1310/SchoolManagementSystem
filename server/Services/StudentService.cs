using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server.Dtos.Student;
using server.Models;
using server.Services.Interfaces;

namespace server.Services
{
    public class StudentService : IStudentService
    {
        private readonly SMGMSYSContext _context;
        private readonly IMapper _mapper;

        public StudentService(SMGMSYSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SR<GetStudentDto>> AddStudent(AddStudentDto newStudent)
        {
            var res = new SR<GetStudentDto>();
            try
            {
                var student = _mapper.Map<dbo_Student>(newStudent);
                await _context.dbo_Student.AddAsync(student);
                await _context.SaveChangesAsync();
                res.Data = _mapper.Map<GetStudentDto>(student);
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<object>> DeleteStudentById(int studentId)
        {
            var res = new SR<object>();
            try
            {
                var student = await _context.dbo_Student.FirstOrDefaultAsync(x => x.Id == studentId);
                if (student == null)
                {
                    res.NotFound("Student");
                    return res;
                }
                _context.dbo_Student.Remove(student);
                await _context.SaveChangesAsync();
                return res;
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
                res.StatusCode = 500;
            }
            return res;
        }

        public async Task<SR<List<GetStudentDto>>> GetAllStudents()
        {
            var res = new SR<List<GetStudentDto>>();
            try
            {
                res.Data = await _context.dbo_Student
                    .Include(x => x.Class)
                    .Include(x => x.School)
                    .Select(x => _mapper.Map<GetStudentDto>(x))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<List<GetStudentDto>>> GetAllStudentsByClassId(int classId)
        {
            var res = new SR<List<GetStudentDto>>();
            try
            {
                var cls = await _context.dbo_Class.FirstOrDefaultAsync(x => x.Id == classId);
                if (cls == null)
                {
                    res.NotFound("Class");
                    return res;
                }
                res.Data = await _context.dbo_Student.Where(x => x.ClassId == classId).Select(x => _mapper.Map<GetStudentDto>(x)).ToListAsync();
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<List<GetStudentDto>>> GetAllStudentsBySchoolId(int schoolId)
        {
            var res = new SR<List<GetStudentDto>>();
            try
            {
                var school = await _context.dbo_School.FirstOrDefaultAsync(x => x.Id == schoolId);
                if (school == null)
                {
                    res.NotFound("School");
                    return res;
                }
                res.Data = await _context.dbo_Student
                    .Include(x => x.Class)
                    .Where(x => x.SchoolId == schoolId).Select(x => _mapper.Map<GetStudentDto>(x)).ToListAsync();
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<GetStudentDto>> GetStudentById(int studentId)
        {
            var res = new SR<GetStudentDto>();
            try
            {
                var student = await _context.dbo_Student.FirstOrDefaultAsync(x => x.Id == studentId);
                if (student == null)
                {
                    res.NotFound("Student");
                    return res;
                }
                res.Data = _mapper.Map<GetStudentDto>(student);
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<GetStudentDto>> UpdateStudentById(int studentId, UpdateStudentDto updatedStudent)
        {
            var res = new SR<GetStudentDto>();
            try
            {
                var student = await _context.dbo_Student.FirstOrDefaultAsync(x => x.Id == studentId);
                var school = await _context.dbo_School.FirstOrDefaultAsync(x => x.Id == updatedStudent.SchoolId);
                var cls = await _context.dbo_Class.FirstOrDefaultAsync(x => x.Id == updatedStudent.ClassId);
                if (student == null)
                {
                    res.NotFound("Student");
                    return res;
                }
                if (school == null)
                {
                    res.NotFound("School");
                    return res;
                }
                if (cls == null)
                {
                    res.NotFound("Class");
                    return res;
                }
                if (school.Id != cls.SchoolId)
                {
                    res.Message = "Class is not part of the School!";
                    res.Success = false;
                    return res;
                }
                student.Address = updatedStudent.Address;
                student.ClassId = updatedStudent.ClassId;
                student.FirstName = updatedStudent.FirstName;
                student.LastName = updatedStudent.LastName;
                student.SchoolId = updatedStudent.SchoolId;
                student.Photo = updatedStudent.Photo;

                await _context.SaveChangesAsync();

                res.Data = _mapper.Map<GetStudentDto>(student);

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