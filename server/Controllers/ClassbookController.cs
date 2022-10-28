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

        public ClassbookController(IClassbookService service)
        {
            _service = service;
        }

        [HttpGet("GetAllClassbooks")]
        public async Task<ActionResult<SR<List<GetClassbookDto>>>> GetAllClassbooks()
        {
            var res = await _service.GetAllClassbooks();
            return res;
        }
        [HttpGet("GetAllSchoolClassbooks/{schoolId}")]
        public async Task<ActionResult<SR<List<GetClassbookDto>>>> GetAllSchoolClassbooks(int schoolId)
        {
            var res = await _service.GetAllSchoolClassbooks(schoolId);
            return res;
        }
        [HttpGet("GetClassbook/{classbookId}")]
        public async Task<ActionResult<SR<GetClassbookDto>>> GetClassbook(int classbookId)
        {
            var res = await _service.GetClassbook(classbookId);
            return res;
        }
        [HttpGet("GetClassbookByClass/{classId}")]
        public async Task<ActionResult<SR<GetClassbookDto>>> GetClassbookByClass(int classId)
        {
            var res = await _service.GetClassbookByClass(classId);
            return res;
        }
        [HttpPut("UpdateClassbookById/{classbookId}")]
        public async Task<ActionResult<SR<GetClassbookDto>>> UpdateClassbookById(int classbookId, UpdateClassbookDto updatedClassbook)
        {
            var res = await _service.UpdateClassbookById(classbookId, updatedClassbook);
            return res;
        }
        [HttpDelete("DeleteClassbookById/{classbookId}")]
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