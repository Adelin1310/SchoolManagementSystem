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
        public AbsenceController(IAbsenceService service)
        {
            _service = service;
        }
        [HttpPost("AddAbsence")]
        public async Task<ActionResult<SR<GetAbsenceDto>>> AddAbsence(AddAbsenceDto newAbsence)
        {
            var res = await _service.AddAbsence(newAbsence);
            return res;
        }
        [HttpGet("GetAllStudentAbsences/{studentId}")]
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
        [HttpGet("GetAllSchoolAbsences/{schoolId}")]
        public async Task<ActionResult<SR<List<GetAbsenceDto>>>> GetAllSchoolAbsences(int schoolId)
        {
            var res = await _service.GetAllSchoolAbsences(schoolId);
            return res;
        }
        [HttpGet("GetAllClassAbsences/{classId}")]
        public async Task<ActionResult<SR<List<GetAbsenceDto>>>> GetAllClassAbsences(int classId)
        {
            var res = await _service.GetAllClassAbsences(classId);
            return res;
        }
        [HttpGet("GetAbsenceById/{absenceId}")]
        public async Task<ActionResult<SR<GetAbsenceDto>>> GetAbsenceById(int absenceId)
        {
            var res = await _service.GetAbsenceById(absenceId);
            return res;
        }
        [HttpPut("UpdateAbsenceById{absenceId}")]
        public async Task<ActionResult<SR<GetAbsenceDto>>> UpdateAbsenceById(int absenceId, UpdateAbsenceDto updatedAbsence){
            var res = await _service.UpdateAbsenceById(absenceId, updatedAbsence);
            return res;
        }
        [HttpDelete("DeleteAbsenceById/{absenceId}")]
        public async Task<ActionResult<object>> DeleteAbsenceById(int absenceId){
            var res = await _service.DeleteAbsenceById(absenceId);
            return res;
        }
    }
}