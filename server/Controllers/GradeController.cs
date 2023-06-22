using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Grade;
using server.Services.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _service;
        private readonly IAuthService _auth;

        public GradeController(IGradeService service, IAuthService auth)
        {
            _auth = auth;
            _service = service;
        }
        [HttpGet("GetAllGrades")]
        public async Task<ActionResult<SR<List<GetGradeDto>>>> GetAllGrades()
        {
            var res = await _service.GetAllGrades();
            return res;
        }
        [HttpPost("AddGrade")]
        public async Task<ActionResult<SR<GetGradeDto>>> AddGrade(AddGradeDto newGrade)
        {
            var sessionID = Request.Cookies["sessionID"];
            var user = await _auth.ValidateToken(sessionID);
            if (user.StatusCode != StatusCodes.Status200OK) return StatusCode(401, user);
            var teacher = await _auth.GetTeacherProfile(sessionID);
            if (teacher.StatusCode != StatusCodes.Status200OK) return StatusCode(401, teacher);
            var res = await _service.AddGrade(newGrade);
            return StatusCode(res.StatusCode, res);
        }
        [HttpDelete("DeleteGradeById")]
        public async Task<ActionResult<object>> DeleteGradeById(int gradeId)
        {
            var res = await _service.DeleteGradeById(gradeId);
            return res;
        }
        [HttpGet("GetGradeById")]
        public async Task<ActionResult<SR<GetGradeDto>>> GetGradeById(int gradeId)
        {
            var res = await _service.GetGradeById(gradeId);
            return res;
        }
        [HttpGet("GetStudentGradesByStudentId")]
        public async Task<ActionResult<SR<List<GetGradeDto>>>> GetStudentGradesByStudentId(int studentId)
        {
            var res = await _service.GetStudentGradesByStudentId(studentId);
            return res;
        }
        [HttpPut("UpdateGradeById")]
        public async Task<ActionResult<SR<GetGradeDto>>> UpdateGradeById(int gradeId, UpdateGradeDto updatedGrade)
        {
            var res = await _service.UpdateGradeById(gradeId, updatedGrade);
            return res;
        }


    }
}