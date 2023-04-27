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
        private readonly IAuthService _service;
        private readonly IMapper _mapper;

        public StudentService(SMGMSYSContext context, IMapper mapper, IAuthService service)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }
        private static int GetRandomNumberInRange(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max + 1);
        }
        public async Task<SR<List<AddStudentDto>>> GenerateRandomStudents()
        {
            var res = new SR<List<AddStudentDto>>();
            try
            {
                string[] firstNames = { "John", "Jane", "Michael", "Emma", "David", "Sophia" };
                string[] lastNames = { "Doe", "Smith", "Johnson", "Brown", "Lee", "Taylor" };

                // Generate an array of 10 random user objects
                List<AddStudentDto> randomStudents = new List<AddStudentDto>();
                Random random = new Random();
                for (int i = 0; i < 30; i++)
                {
                    AddStudentDto student = new AddStudentDto
                    {
                        FirstName = firstNames[random.Next(firstNames.Length)],
                        LastName = lastNames[random.Next(lastNames.Length)],
                        Address = "1234 Example St, City, State, ZIP",
                        ClassId = GetRandomNumberInRange(8, 27),
                        SchoolId = 4,
                        Photo = "https://example.com/profile-photo.jpg",
                        UserId = _context.dbo_User.OrderBy(u => u.Id).Last().Id + 1
                    };
                    randomStudents.Add(student);

                }
                res.Data = randomStudents;
                res.Message = "Students generated successfully!";
                res.Success = true;
                res.StatusCode = StatusCodes.Status200OK;
            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.StatusCode = StatusCodes.Status500InternalServerError;
                res.Success = false;
            }
            return res;
        }

        public async Task<SR<List<GetStudentDto>>> AddStudents(List<AddStudentDto> newStudents)
        {
            var res = new SR<List<GetStudentDto>>();
            try
            {
                var mappedStudents = newStudents.Select(s => _mapper.Map<dbo_Student>(s)).ToList();
                await _context.dbo_Student.AddRangeAsync(mappedStudents);
                await _context.SaveChangesAsync();
                res.Data = mappedStudents.Select(s => _mapper.Map<GetStudentDto>(s)).ToList();
                res.Message = "Students added successfully!";
                res.StatusCode = StatusCodes.Status200OK;
                res.Success = true;
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.StatusCode = StatusCodes.Status500InternalServerError;
                res.Success = false;
            }
            return res;
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