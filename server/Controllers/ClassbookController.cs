using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Classbook;
using server.Services.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassbookController : ControllerBase
    {
        private readonly IClassbookService _service;
        private readonly IAuthService _auth;

        public ClassbookController(IClassbookService service, IAuthService auth)
        {
            _auth = auth;
            _service = service;
        }

        [HttpGet("GetAllTeacherClassbooks")]
        public async Task<ActionResult<SR<List<GetClassbookDto>>>> GetAllTeacherClassbooks()
        {
            var sessionID = Request.Cookies["sessionID"];
            var user = await _auth.ValidateToken(sessionID);
            if (user.StatusCode != StatusCodes.Status200OK) return StatusCode(user.StatusCode, user);
            var teacher = await _auth.GetTeacherProfile(sessionID);
            if (teacher.StatusCode != StatusCodes.Status200OK) return StatusCode(teacher.StatusCode, teacher);
            var res = await _service.GetAllTeacherClassbooks(teacher.Data.Id);
            return StatusCode(res.StatusCode, res);

        }
        [HttpGet("GetStudentsSituation/{subjectId}/{classId}/{classbookId}")]
        public async Task<ActionResult<SR<List<GetClassbookDto>>>> GetStudentsSituation(int subjectId, int classId, int classbookId)
        {
            var sessionID = Request.Cookies["sessionID"];
            var user = await _auth.ValidateToken(sessionID);
            if (user.StatusCode != StatusCodes.Status200OK) return StatusCode(user.StatusCode, user);
            var teacher = await _auth.GetTeacherProfile(sessionID);
            if (teacher.StatusCode != StatusCodes.Status200OK) return StatusCode(teacher.StatusCode, teacher);
            var res = await _service.GetStudentsSituation(subjectId, classId, classbookId, teacher.Data.Id);
            return StatusCode(res.StatusCode, res);

        }
        [HttpGet("GetAllClassbooks")]
        public async Task<ActionResult<SR<List<GetClassbookDto>>>> GetAllClassbooks()
        {
            var res = await _service.GetAllClassbooks();
            return res;
        }

        [HttpGet("GetAllSchoolClassbooks")]
        public async Task<ActionResult<SR<List<GetClassbookDto>>>> GetAllSchoolClassbooks(int schoolId)
        {
            var res = await _service.GetAllSchoolClassbooks(schoolId);
            return res;
        }

        [HttpGet("GetClassbook/{classbookId}")]
        public async Task<ActionResult<SR<GetClassbookDto>>> GetClassbook(int classbookId)
        {
            var sessionID = Request.Cookies["sessionID"];
            var user = await _auth.ValidateToken(sessionID);
            if (user.StatusCode != StatusCodes.Status200OK) return StatusCode(401, user);
            var teacher = await _auth.GetTeacherProfile(sessionID);
            if (teacher.StatusCode != StatusCodes.Status200OK) return StatusCode(401, teacher);
            var res = await _service.GetClassbook(classbookId, teacher.Data.Id);
            return StatusCode(res.StatusCode, res);
        }

        [HttpGet("GetClassbookByClass")]
        public async Task<ActionResult<SR<GetClassbookDto>>> GetClassbookByClass(int classId)
        {
            var res = await _service.GetClassbookByClass(classId);
            return res;
        }

        [HttpPut("UpdateClassbookById")]
        public async Task<ActionResult<SR<GetClassbookDto>>> UpdateClassbookById(int classbookId, UpdateClassbookDto updatedClassbook)
        {
            var res = await _service.UpdateClassbookById(classbookId, updatedClassbook);
            return res;
        }

        [HttpDelete("DeleteClassbookById")]
        public async Task<ActionResult<object>> DeleteClassbookById(int classbookId)
        {
            var res = await _service.DeleteClassbookById(classbookId);
            return res;
        }

        [HttpPost("AddClassbook")]
        public async Task<ActionResult<SR<GetClassbookDto>>> AddClassbook(AddClassbookDto newClassbook)
        {
            var res = await _service.AddClassbook(newClassbook);
            return res;
        }

    }
}