using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Class;
using server.Services.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _service;
        private readonly IAuthService _auth;
        public ClassController(IClassService service, IAuthService auth)
        {
            _auth = auth;
            _service = service;
        }
        [HttpDelete("DeleteClassById")]
        public async Task<ActionResult<object>> DeleteClassById(int classId)
        {
            var res = await _service.DeleteClassById(classId);
            return res;
        }

        [HttpPost("AddClass")]
        public async Task<ActionResult<SR<GetClassDto>>> AddClass(AddClassDto newClass)
        {
            var res = await _service.AddClass(newClass);
            return res;
        }
        [HttpPost("AddSecondaryEducationNoHSClasses")]
        public async Task<ActionResult<SR<List<GetClassDto>>>> AddSecondaryEducationNoHSClasses(string[] names, int schoolId)
        {
            var res = await _service.AddSecondaryEducationNoHSClasses(names, schoolId);
            return res;
        }
        [HttpGet("GetAllClasses")]
        public async Task<ActionResult<SR<List<GetClassDto>>>> GetAllClasses()
        {
            var res = await _service.GetAllClasses();
            return res;
        }
        [HttpGet("GetAllTeacherClasses")]
        public async Task<ActionResult<SR<List<GetClassSubjectDto>>>> GetAllTeacherClasses()
        {
            var sessionID = Request.Cookies["sessionID"];
            var user = await _auth.ValidateToken(sessionID);
            if (user.StatusCode != StatusCodes.Status200OK) return StatusCode(401, user);
            var teacher = await _auth.GetTeacherProfile(sessionID);
            if (teacher.StatusCode != StatusCodes.Status200OK) return StatusCode(401, teacher);
            var res = await _service.GetAllTeacherClasses(teacher.Data.Id);
            return res;
        }
        [HttpGet("GetClassById")]
        public async Task<ActionResult<SR<GetClassDto>>> GetClassById(int classId)
        {
            var res = await _service.GetClassById(classId);
            return res;
        }
        [HttpPut("UpdateClassById")]
        public async Task<ActionResult<SR<GetClassDto>>> UpdateClassById(int classId, UpdateClassDto updatedClass)
        {
            var res = await _service.UpdateClassById(classId, updatedClass);
            return res;
        }

        [HttpGet("GetStudentClass")]
        public async Task<ActionResult<SR<GetStudentClassDto>>> GetStudentClass()
        {
            var sessionID = Request.Cookies["sessionID"];
            var res = await _service.GetStudentClass(sessionID);
            return StatusCode(res.StatusCode, res);
        }
    }
}