using System.Text;
using System.Security.Claims;
using server.Services.Interfaces;
using server.Utils.Auth;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
namespace server.Services
{
    public class AuthService : IAuthService
    {
        private readonly SMGMSYSContext _context;
        private readonly ITokenGenerator _generator;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        private readonly List<KeyValuePair<string, Type>> _roles = new List<KeyValuePair<string, Type>>{
            new KeyValuePair<string, Type>("Student", Type.GetType("GetStudentProfileDto"))
        };

        public AuthService(SMGMSYSContext context, ITokenGenerator generator, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _generator = generator;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<SR<object>> Register(Dtos.User.UserRegisterDto newUser)
        {
            var res = new SR<object>();
            try
            {

                if (await userExists(newUser.Username))
                {
                    res.StatusCode = StatusCodes.Status400BadRequest;
                    res.Success = false;
                    res.Message = "There already is an user with that username!";
                    return res;
                }
                if (!await AuthAlgorithms.ValidatePassword(newUser.Password))
                {
                    res.StatusCode = StatusCodes.Status400BadRequest;
                    res.Success = false;
                    res.Message = "Password is not valid! Check the password requirements and try again.";
                    return res;
                }

                var passwordHash = AuthAlgorithms.HashPassword(newUser.Password);

                await _context.dbo_User.AddAsync(new Models.dbo_User
                {
                    Password = passwordHash,
                    Username = newUser.Username,

                    // TODO: Implement invitation-type registration 
                    // For now, every new user will be registered as a Student
                    RoleId = 1,
                });

                await _context.SaveChangesAsync();

                res.Message = "Account created successfully!";
                res.StatusCode = StatusCodes.Status200OK;
                res.Success = true;
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.StatusCode = StatusCodes.Status500InternalServerError;
                res.Success = false;
            }

            return res;

        }

        public async Task<SR<string>> Login(Dtos.User.UserLoginDto credentials)
        {
            var res = new SR<string>();
            try
            {

                if (!await userExists(credentials.Username))
                {
                    res.Message = "Username incorrect!";
                    res.Success = false;
                    res.StatusCode = StatusCodes.Status400BadRequest;
                    return res;
                }
                var user = await _context.dbo_User.Include(u => u.Role).FirstOrDefaultAsync(u => u.Username == credentials.Username);
                if (!await AuthAlgorithms.VerifyPassword(credentials.Password, user.Password))
                {
                    res.Message = "Password incorrect!";
                    res.Success = false;
                    res.StatusCode = StatusCodes.Status400BadRequest;
                    return res;
                }
                var claims = new List<Claim>{
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.Name),
            };
                var session = new Models.dbo_Session
                {
                    Token = _generator.GenerateToken(new System.Security.Claims.ClaimsIdentity(claims)),
                    User = user,
                    UserId = user.Id,
                };

                await _context.dbo_Session.AddAsync(session);
                await _context.SaveChangesAsync();

                res.Data = session.Id;
                res.Message = "Login successful!";
                res.StatusCode = StatusCodes.Status200OK;
                res.Success = true;
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
                res.StatusCode = StatusCodes.Status500InternalServerError;
            }
            return res;
        }

        public async Task<SR<object>> Logout(string sessionId)
        {
            var res = new SR<object>();
            try
            {
                if (sessionId == string.Empty)
                {
                    res.Message = "Invalid attempt";
                    res.StatusCode = StatusCodes.Status400BadRequest;
                    res.Success = false;
                    return res;
                }
                var session = await _context.dbo_Session.FirstOrDefaultAsync(s => s.Id == sessionId);
                if (session == null)
                {
                    res.Message = "Invalid attempt";
                    res.StatusCode = StatusCodes.Status400BadRequest;
                    res.Success = false;
                    return res;
                }
                _context.dbo_Session.Remove(session);
                await _context.SaveChangesAsync();

                res.Message = "Logout successful!";
                res.StatusCode = StatusCodes.Status200OK;
                res.Success = true;
            }
            catch (System.Exception ex)
            {
                res.Message = ex.Message;
                res.StatusCode = StatusCodes.Status500InternalServerError;
                res.Success = false;
            }
            return res;
        }
        public async Task<SR<Dtos.User.GetUserDto>> ValidateToken(string sessionId)
        {
            var res = new SR<Dtos.User.GetUserDto>();
            try
            {
                if (sessionId == string.Empty)
                {
                    res.Message = "Invalid attempt";
                    res.StatusCode = StatusCodes.Status400BadRequest;
                    res.Success = false;
                    return res;
                }
                var session = await _context.dbo_Session.FirstOrDefaultAsync(s => s.Id == sessionId);
                if (session == null)
                {
                    res.Message = "Invalid attempt";
                    res.StatusCode = StatusCodes.Status400BadRequest;
                    res.Success = false;
                    return res;
                }
                // Get token from session
                var token = session.Token;

                // Create token handler
                var tokenHandler = new JwtSecurityTokenHandler();

                var jwtSettings = _configuration.GetSection("JwtSettings").Get<JwtSettings>();

                // Define the validation parameters
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero // Optionally set clock skew
                };

                // Validate the token
                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

                if (DateTime.UtcNow > validatedToken.ValidTo)
                {
                    _context.dbo_Session.Remove(session);
                    await _context.SaveChangesAsync();

                    res.Message = "Session expired";
                    res.Success = false;
                    res.StatusCode = StatusCodes.Status200OK;

                    return res;
                }

                var user = await _context.dbo_User.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == session.UserId);

                if (user == null)
                {
                    res.Message = "Invalid attempt - user not found!";
                    res.StatusCode = StatusCodes.Status400BadRequest;
                    res.Success = false;
                    return res;
                }
                res.Data = _mapper.Map<Dtos.User.GetUserDto>(user);
                res.Message = "Validation successful!";
                res.Success = true;
                res.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.StatusCode = StatusCodes.Status500InternalServerError;
                res.Success = false;
            }
            return res;
        }

        public async Task<string> GetRole(string sessionId)
        {
            if (sessionId == null) return string.Empty;
            var session = await _context.dbo_Session.Include(s => s.User).ThenInclude(u => u.Role).FirstOrDefaultAsync(s => s.Id == sessionId);
            if (session == null) return string.Empty;
            return session.User.Role.Name;
        }
        public async Task<Models.dbo_User> GetUser(string sessionId)
        {
            if (sessionId == null) return null;
            var session = await _context.dbo_Session.Include(s => s.User).ThenInclude(u => u.Role).FirstOrDefaultAsync(s => s.Id == sessionId);
            if (session == null) return null;
            return session.User;
        }
        public async Task<SR<Dtos.Profile.GetStudentProfileDto>> GetStudentProfile(string sessionId)
        {
            var res = new SR<Dtos.Profile.GetStudentProfileDto>();
            if (sessionId == null)
            {
                res.Success = false;
                res.StatusCode = StatusCodes.Status401Unauthorized;
                res.Message = "Session Expired!";
                return res;
            }
            var session = await _context.dbo_Session.Include(s => s.User).ThenInclude(u => u.Role).FirstOrDefaultAsync(s => s.Id == sessionId);
            if (session == null)
            {
                res.Success = false;
                res.StatusCode = StatusCodes.Status401Unauthorized;
                res.Message = "Session Expired!";
                return res;
            }
            try
            {
                var student = await _context.dbo_Student
                    .Include(s => s.Class)
                    .Include(s => s.School)
                    .FirstOrDefaultAsync(s => s.UserId == session.UserId);
                res.Data = new Dtos.Profile.GetStudentProfileDto();
                if (student is not null)
                {
                    var grades = await _context.dbo_Grade
                        .Include(g => g.Subject)
                        .Where(g => g.StudentId == session.UserId)
                        .OrderByDescending(g => g.Date)
                        .Select(g => _mapper.Map<Dtos.Grade.GetGradeDto>(g))
                        .Take(10)
                        .ToListAsync();
                    var absences = await _context.dbo_Absence
                        .Include(a => a.Subject)
                        .Where(a => a.StudentId == session.UserId)
                        .Select(a => _mapper.Map<Dtos.Absence.GetAbsenceDto>(a))
                        .ToListAsync();
                    res.Data.Absences = absences;
                    res.Data.LatestGrades = grades;
                    res.Data.Address = student.Address;
                    res.Data.Class = student.Class.Name;
                    res.Data.School = student.School.Name;
                    res.Data.FullName = $"{student.FirstName} {student.LastName}";
                    res.Data.FirstName = student.FirstName;
                    res.Data.LastName = student.LastName;
                    res.Data.Email = session.User.Email;
                    res.Message = "Profile found successfully!";
                    res.Success = true;
                    res.StatusCode = StatusCodes.Status200OK;
                }
                else
                {
                    res.Success = false;
                    res.StatusCode = StatusCodes.Status404NotFound;
                    res.Message = "Student not found!";
                }
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.StatusCode = StatusCodes.Status500InternalServerError;
                res.Success = false;
            }
            return res;
        }
        private async Task GetType(string type)
        {

        }
        private async Task<bool> userExists(string username) => _context.dbo_User.Where(u => u.Username.ToLower() == username.ToLower()).Count() != 0;

    }
}