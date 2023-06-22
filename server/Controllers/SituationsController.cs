using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Services.Interfaces;
using server.Dtos.Situations;
namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SituationsController : ControllerBase
    {
        private readonly IAuthService _auth;
        private readonly ISituationsService _service;
        public SituationsController(IAuthService auth, ISituationsService service)
        {
            _auth = auth;
            _service = service;
        }

        [HttpPost("EndSituation")]
        public async Task<ActionResult<SR<bool>>> EndSituation(EndSituationDto endSituationDto)
        {
            var sessionID = Request.Cookies["sessionID"];
            var user = await _auth.ValidateToken(sessionID);
            if (user.StatusCode != StatusCodes.Status200OK) return StatusCode(user.StatusCode, user);
            var teacher = await _auth.GetTeacherProfile(sessionID);
            if (teacher.StatusCode != StatusCodes.Status200OK) return StatusCode(teacher.StatusCode, teacher);
            var res = await _service.EndSituation(endSituationDto);
            return StatusCode(res.StatusCode, res);
        }
    }
}