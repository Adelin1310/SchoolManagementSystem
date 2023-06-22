using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.SchoolTeacher;
using server.Dtos.Teacher;
using server.Dtos.TeacherSubject;
using server.Services.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;
        private readonly IAuthService _auth;

        public TeacherController(ITeacherService service, IAuthService auth)
        {
            _auth = auth;
            _service = service;
        }

        [HttpGet("GetAllTeachers")]
        public async Task<ActionResult<SR<List<GetTeacherDto>>>> GetAllTeachers()
        {
            var res = await _service.GetAllTeachers();
            return res;
        }
        [HttpGet("GetAllTeachersWSchoolsAndSubjects")]
        public async Task<ActionResult<SR<List<GetTeacherWSchoolsAndSubjectsDto>>>> GetAllTeachersWSchoolsAndSubjects()
        {
            var res = await _service.GetAllTeachersWithSchoolsAndSubjects();
            return res;
        }
        [HttpGet("GetAllTeachersBySchoolId")]
        public async Task<ActionResult<SR<List<GetTeacherDto>>>> GetAllTeachersBySchoolId(int schoolId)
        {
            var res = await _service.GetAllTeachersBySchoolId(schoolId);
            return res;
        }
        [HttpGet("GetTeachersByClassId")]
        public async Task<ActionResult<SR<List<GetTeacherWSubject>>>> GetTeachersByClassId()
        {
            var sessionID = Request.Cookies["sessionID"];
            var user = await _auth.ValidateToken(sessionID);
            if (user.StatusCode != StatusCodes.Status200OK) return StatusCode(user.StatusCode, user);
            var student = await _auth.GetStudentProfile(sessionID);
            if (student.StatusCode != StatusCodes.Status200OK) return StatusCode(student.StatusCode, student);
            var res = await _service.GetTeachersByClassId(student.Data.Class.Id);
            return StatusCode(res.StatusCode, res);
        }
        [HttpGet("GetTeacherById")]
        public async Task<ActionResult<SR<GetTeacherDto>>> GetTeacherById(int teacherId)
        {
            var res = await _service.GetTeacherById(teacherId);
            return res;
        }
        [HttpGet("GetTeacherWClassesAndSubjects/{teacherId}")]
        public async Task<ActionResult<SR<GetTeacherWClassesAndSubjectsDto>>> GetTeacherWClassesAndSubjects(int teacherId)
        {
            var sessionID = Request.Cookies["sessionID"];
            var user = await _auth.ValidateToken(sessionID);
            if (user.StatusCode != StatusCodes.Status200OK) return StatusCode(user.StatusCode, user);
            var student = await _auth.GetStudentProfile(sessionID);
            if (student.StatusCode != StatusCodes.Status200OK) return StatusCode(student.StatusCode, student);
            var res = await _service.GetTeacherWClassesAndSubjects(student.Data.Class.SchoolId, teacherId);
            return StatusCode(res.StatusCode, res);
        }
        [HttpPost("AddTeacher")]
        public async Task<ActionResult<SR<GetTeacherDto>>> AddTeacher(AddTeacherDto newTeacher)
        {
            var res = await _service.AddTeacher(newTeacher);
            return res;
        }
        [HttpPut("UpdateTeacherById")]
        public async Task<ActionResult<SR<GetTeacherDto>>> UpdateTeacherById(int teacherId, UpdateTeacherDto updatedTeacher)
        {
            var res = await _service.UpdateTeacherById(teacherId, updatedTeacher);
            return res;
        }
        [HttpPut("AssignTeacherToSchool")]
        public async Task<ActionResult<SR<GetTeacherDto>>> AssignTeacherToSchool(AddSchoolTeacherDto newSchoolTeacher)
        {
            var res = await _service.AssignTeacherToSchool(newSchoolTeacher);
            return res;
        }
        [HttpPut("AssignSubjectToTeacher")]
        public async Task<ActionResult<SR<GetTeacherDto>>> AssignSubjectToTeacher(AddTeacherSubjectDto newTeacherSubject)
        {
            var res = await _service.AssignSubjectToTeacher(newTeacherSubject);
            return res;
        }
        [HttpDelete("DeleteTeacherById")]
        public async Task<ActionResult<object>> DeleteTeacherById(int teacherId)
        {
            var res = await _service.DeleteTeacherById(teacherId);
            return res;
        }


    }
}