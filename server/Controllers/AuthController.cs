using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Services.Interfaces;
namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SMGMSYSContext _context;
        private readonly IAuthService _service;

        public AuthController(SMGMSYSContext context, IAuthService service)
        {
            _context = context;
            _service = service;
        }

        [HttpPost("register")]
        public async Task<ActionResult<SR<object>>> Register(Dtos.User.UserRegisterDto newUser)
        {
            var res = await _service.Register(newUser);
            return StatusCode(res.StatusCode, res);
        }

        [HttpPost("login")]
        public async Task<ActionResult<SR<string>>> Login(Dtos.User.UserLoginDto credentials)
        {
            var res = await _service.Login(credentials);
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.Lax,
            };
            if (res.Data != null)
            {
                Response.Cookies.Append(
                    "sessionID",
                    res.Data,
                    cookieOptions
                );
            }
            return StatusCode(res.StatusCode, res);
        }
        [HttpPost("logout")]
        public async Task<ActionResult<SR<object>>> Logout()
        {
            var sessionID = Request.Cookies["sessionID"];
            var res = await _service.Logout(sessionID);
            Response.Cookies.Delete("sessionID");
            return StatusCode(res.StatusCode, res);
        }
        [HttpPost("validate")]
        public async Task<ActionResult<SR<Dtos.User.GetUserDto>>> ValidateToken()
        {
            var sessionID = Request.Cookies["sessionID"];
            var res = await _service.ValidateToken(sessionID);
            if (res.StatusCode == StatusCodes.Status200OK && res.Data == null)
            {
                Response.Cookies.Delete("sessionID");
            }
            return StatusCode(res.StatusCode, res);
        }
    }
}