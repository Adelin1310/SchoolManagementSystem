using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.School;
using server.Services.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _service;
        private readonly IAuthService _auth;
        public SchoolController(ISchoolService service, IAuthService auth)
        {
            _service = service;
            _auth = auth;
        }
        [HttpDelete("DeleteSchoolById")]
        public async Task<ActionResult<object>> DeleteSchoolById(int schoolId)
        {
            var res = await _service.DeleteSchoolById(schoolId);
            return res;
        }
        [HttpGet("GetAllSchools")]
        public async Task<ActionResult<SR<List<GetSchoolDto>>>> GetAllSchools()
        {
            var sessionID = Request.Cookies["sessionID"];
            if (sessionID == null)
                return StatusCode(401);
            var role = await _auth.GetRole(sessionID);
            var user = await _auth.GetUser(sessionID);
            var res = await _service.GetAllSchools();
            switch (role)
            {
                case "Student":
                    return StatusCode(401);
                case "Teacher":
                case "Director":
                    res = await _service.GetAllSchoolsByTeacherId(user.Id);
                    return StatusCode(res.StatusCode, res);
                case "Admin":
                    return StatusCode(res.StatusCode, res);
                default: break;
            }
            return StatusCode(401);
        }
        [HttpGet("GetAllSchoolsWithClasses")]
        public async Task<ActionResult<SR<List<object>>>> GetAllSchoolsWithClasses()
        {
            var res = await _service.GetAllSchoolsWithClasses();
            return res;
        }
        [HttpGet("GetAllSchoolsOrderedByStudents")]
        public async Task<ActionResult<SR<List<GetSchoolDto>>>> GetAllSchoolsOrderedByStudents()
        {
            var res = await _service.GetAllSchoolsOrderedByStudents();
            return res;
        }
        [HttpPost("AddSchool")]
        public async Task<ActionResult<SR<GetSchoolDto>>> AddSchool(AddSchoolDto newSchool)
        {
            var res = await _service.AddSchool(newSchool);
            return res;
        }
        [HttpPut("UpdateSchoolById")]
        public async Task<ActionResult<SR<GetSchoolDto>>> UpdateSchoolById(int schoolId, UpdateSchoolDto updatedSchool)
        {
            var res = await _service.UpdateSchoolById(schoolId, updatedSchool);
            return res;
        }
    }
}