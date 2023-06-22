using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Absence;
using server.Services.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbsenceController : ControllerBase
    {
        private readonly IAbsenceService _service;
        private readonly IAuthService _auth;
        public AbsenceController(IAbsenceService service, IAuthService auth)
        {
            _auth = auth;
            _service = service;
        }
        [HttpPost("AddAbsence")]
        public async Task<ActionResult<SR<GetAbsenceDto>>> AddAbsence(AddAbsenceDto newAbsence)
        {
            var sessionID = Request.Cookies["sessionID"];
            var user = await _auth.ValidateToken(sessionID);
            if (user.StatusCode != StatusCodes.Status200OK) return StatusCode(401, user);
            var teacher = await _auth.GetTeacherProfile(sessionID);
            if (teacher.StatusCode != StatusCodes.Status200OK) return StatusCode(401, teacher);
            var res = await _service.AddAbsence(newAbsence);
            return res;
        }
        [HttpGet("GetAllStudentAbsences")]
        public async Task<ActionResult<SR<List<GetAbsenceDto>>>> GetAllStudentAbsences(int studentId)
        {
            var res = await _service.GetAllStudentAbsences(studentId);
            return res;
        }

        [HttpGet("GetAllAbsences")]
        public async Task<ActionResult<SR<List<GetAbsenceDto>>>> GetAllAbsences()
        {
            var res = await _service.GetAllAbsences();
            return res;
        }
        [HttpGet("GetAllSchoolAbsences")]
        public async Task<ActionResult<SR<List<GetAbsenceDto>>>> GetAllSchoolAbsences(int schoolId)
        {
            var res = await _service.GetAllSchoolAbsences(schoolId);
            return res;
        }
        [HttpGet("GetAllClassAbsences")]
        public async Task<ActionResult<SR<List<GetAbsenceDto>>>> GetAllClassAbsences(int classId)
        {
            var res = await _service.GetAllClassAbsences(classId);
            return res;
        }
        [HttpGet("GetAbsenceById")]
        public async Task<ActionResult<SR<GetAbsenceDto>>> GetAbsenceById(int absenceId)
        {
            var res = await _service.GetAbsenceById(absenceId);
            return res;
        }
        [HttpPost("MotivateAbsence")]
        public async Task<ActionResult<SR<GetAbsenceDto>>> MotivateAbsence(UpdateAbsenceDto updatedAbsence){
            var sessionID = Request.Cookies["sessionID"];
            var user = await _auth.ValidateToken(sessionID);
            if (user.StatusCode != StatusCodes.Status200OK) return StatusCode(401, user);
            var teacher = await _auth.GetTeacherProfile(sessionID);
            if (teacher.StatusCode != StatusCodes.Status200OK) return StatusCode(401, teacher);
            var res = await _service.UpdateAbsenceById(updatedAbsence, teacher.Data.Id);
            return res;
        }
        [HttpDelete("DeleteAbsenceById")]
        public async Task<ActionResult<object>> DeleteAbsenceById(int absenceId){
            var res = await _service.DeleteAbsenceById(absenceId);
            return res;
        }
    }
}