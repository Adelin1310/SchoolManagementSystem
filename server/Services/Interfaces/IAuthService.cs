using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services.Interfaces
{
    public interface IAuthService
    {
        Task<SR<object>> Register(Dtos.User.UserRegisterDto newUser);
        Task<SR<string>> Login(Dtos.User.UserLoginDto credentials);
        Task<SR<object>> Logout(string sessionId);
        Task<SR<Dtos.User.GetUserDto>> ValidateToken(string sessionId);
        Task<string> GetRole(string sessionId);
        Task<Models.dbo_User> GetUser(string sessionId);
        Task<SR<Dtos.Profile.GetStudentProfileDto>> GetStudentProfile(string sessionId);
    }
}