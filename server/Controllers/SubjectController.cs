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

        public SubjectController(ISubjectService service)
        {
            _service = service;
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
        [HttpPut("UpdateSubjectById/{subjectId}")]
        public async Task<ActionResult<SR<GetSubjectDto>>> UpdateSubjectById(int subjectId, UpdateSubjectDto updatedSubject)
        {
            var res = await _service.UpdateSubjectById(subjectId, updatedSubject);
            return res;
        }
        [HttpDelete("DeleteSubjectById/{subjectId}")]
        public async Task<ActionResult<object>> DeleteSubjectById(int subjectId){
            var res =await _service.DeleteSubjectById(subjectId);
            return res;
        }
    }
}