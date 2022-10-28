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

        public GradeController(IGradeService service)
        {
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
            var res = await _service.AddGrade(newGrade);
            return res;
        }
        [HttpDelete("DeleteGradeById/{gradeId}")]
        public async Task<ActionResult<object>> DeleteGradeById(int gradeId)
        {
            var res = await _service.DeleteGradeById(gradeId);
            return res;
        }
        [HttpGet("GetGradeById/{gradeId}")]
        public async Task<ActionResult<SR<GetGradeDto>>> GetGradeById(int gradeId)
        {
            var res = await _service.GetGradeById(gradeId);
            return res;
        }
        [HttpGet("GetStudentGradesByStudentId/{studentId}")]
        public async Task<ActionResult<SR<List<GetGradeDto>>>> GetStudentGradesByStudentId(int studentId)
        {
            var res = await _service.GetStudentGradesByStudentId(studentId);
            return res;
        }
        [HttpPut("UpdateGradeById/{gradeId}")]
        public async Task<ActionResult<SR<GetGradeDto>>> UpdateGradeById(int gradeId, UpdateGradeDto updatedGrade)
        {
            var res = await _service.UpdateGradeById(gradeId, updatedGrade);
            return res;
        }


    }
}