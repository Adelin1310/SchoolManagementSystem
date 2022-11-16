using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Student;
using server.Services.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;

        }
        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<SR<List<GetStudentDto>>>> GetAllStudents()
        {
            var res = await _service.GetAllStudents();
            return ErrorHandler.ResponseCodeHandler(res.StatusCode, res);
        }
        [HttpGet("GetAllStudentsBySchoolId/")]
        public async Task<ActionResult<SR<List<GetStudentDto>>>> GetAllStudentsBySchoolId(int schoolId)
        {
            var res = await _service.GetAllStudentsBySchoolId(schoolId);
            return ErrorHandler.ResponseCodeHandler(res.StatusCode, res);

        }

        [HttpGet("GetAllStudentsByClassId/")]
        public async Task<ActionResult<SR<List<GetStudentDto>>>> GetAllStudentsByClassId(int classId)
        {
            var res = await _service.GetAllStudentsByClassId(classId);
            return ErrorHandler.ResponseCodeHandler(res.StatusCode, res);

        }
        [HttpGet("GetStudentById")]
        public async Task<ActionResult<SR<GetStudentDto>>> GetStudentById(int studentId)
        {
            var res = await _service.GetStudentById(studentId);
            return ErrorHandler.ResponseCodeHandler(res.StatusCode, res);

        }
        [HttpPost("AddStudent")]
        public async Task<ActionResult<SR<GetStudentDto>>> AddStudent(AddStudentDto newStudent)
        {
            var res = await _service.AddStudent(newStudent);
            return ErrorHandler.ResponseCodeHandler(res.StatusCode, res);

        }
        [HttpPut("UpdateStudentById")]
        public async Task<ActionResult<SR<GetStudentDto>>> UpdateStudentById(int studentId, UpdateStudentDto updatedStudent)
        {
            var res = await _service.UpdateStudentById(studentId, updatedStudent);
            return ErrorHandler.ResponseCodeHandler(res.StatusCode, res);

        }
        [HttpDelete("DeleteStudentById/")]
        public async Task<ActionResult<object>> DeleteStudentById(int studentId)
        {
            var res = await _service.DeleteStudentById(studentId);
            return ErrorHandler.ResponseCodeHandler(res.StatusCode, res);

        }
    }
}