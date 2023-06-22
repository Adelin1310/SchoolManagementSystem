using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Subject;
using server.Services.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _service;
        private readonly IAuthService _auth;

        public SubjectController(ISubjectService service, IAuthService auth)
        {
            _auth = auth;
            _service = service;
        }
        [HttpGet("GetStudentSituation")]
        public async Task<ActionResult<SR<GetStudentSituationDto>>> GetStudentSituation()
        {
            var sessionID = Request.Cookies["sessionID"];
            var user = await _auth.ValidateToken(sessionID);
            if (user.StatusCode != StatusCodes.Status200OK) return StatusCode(user.StatusCode, user);
            if (user.Data.Role != "Student") return StatusCode(StatusCodes.Status401Unauthorized);
            var student = await _auth.GetStudentProfile(sessionID);
            if (student.StatusCode != StatusCodes.Status200OK) return StatusCode(student.StatusCode, student);
            var res = await _service.GetStudentSituation(student.Data.Id, student.Data.Class.Id);
            return StatusCode(res.StatusCode, res);
        }
        [HttpGet("GetTeacherClassSubjects/{classId}")]
        public async Task<ActionResult<SR<GetStudentSituationDto>>> GetTeacherClassSubjects(int classId)
        {
            var sessionID = Request.Cookies["sessionID"];
            var user = await _auth.ValidateToken(sessionID);
            if (user.StatusCode != StatusCodes.Status200OK) return StatusCode(user.StatusCode, user);
            if (user.Data.Role != "Teacher") return StatusCode(StatusCodes.Status401Unauthorized);
            var teacher = await _auth.GetTeacherProfile(sessionID);
            if (teacher.StatusCode != StatusCodes.Status200OK) return StatusCode(teacher.StatusCode, teacher);
            var res = await _service.GetTeacherClassSubjects(classId, teacher.Data.Id);
            return StatusCode(res.StatusCode, res);
        }
        [HttpGet("GetAllClassSubjects")]
        public async Task<ActionResult<SR<List<GetSubjectDto>>>> GetAllClassSubjects()
        {
            var sessionID = Request.Cookies["sessionID"];
            var user = await _auth.ValidateToken(sessionID);
            if (user.StatusCode != StatusCodes.Status200OK) return StatusCode(user.StatusCode, user);
            var student = await _auth.GetStudentProfile(sessionID);
            if (student.StatusCode != StatusCodes.Status200OK) return StatusCode(student.StatusCode, student);
            var res = await _service.GetAllClassSubjects(student.Data.Class.Id);
            return StatusCode(res.StatusCode, res);
        }
        [HttpGet("GetAllSubjects")]
        public async Task<ActionResult<SR<List<GetSubjectDto>>>> GetAllSubjects()
        {
            var res = await _service.GetAllSubjects();
            return res;
        }
        [HttpPost("AddSubject")]
        public async Task<ActionResult<SR<GetSubjectDto>>> AddSubject(AddSubjectDto newSubject)
        {
            var res = await _service.AddSubject(newSubject);
            return res;
        }
        [HttpPut("UpdateSubjectById")]
        public async Task<ActionResult<SR<GetSubjectDto>>> UpdateSubjectById(int subjectId, UpdateSubjectDto updatedSubject)
        {
            var res = await _service.UpdateSubjectById(subjectId, updatedSubject);
            return res;
        }
        [HttpDelete("DeleteSubjectById")]
        public async Task<ActionResult<object>> DeleteSubjectById(int subjectId)
        {
            var res = await _service.DeleteSubjectById(subjectId);
            return res;
        }
    }
}