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
        public ClassController(IClassService service)
        {
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
        [HttpGet("GetAllClasses")]
        public async Task<ActionResult<SR<List<GetClassDto>>>> GetAllClasses()
        {
            var res = await _service.GetAllClasses();
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
    }
}