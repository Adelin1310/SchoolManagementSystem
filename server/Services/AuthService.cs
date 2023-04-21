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

                if(DateTime.UtcNow > validatedToken.ValidTo){
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
        private async Task<bool> userExists(string username) => _context.dbo_User.Where(u => u.Username.ToLower() == username.ToLower()).Count() != 0;

    }
}