using System.Globalization;
using System.Runtime.Intrinsics.X86;
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
                    Email = newUser.Email,
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
                    res.StatusCode = StatusCodes.Status200OK;
                    return res;
                }
                var user = await _context.dbo_User.Include(u => u.Role).FirstOrDefaultAsync(u => u.Username == credentials.Username);
                if (!await AuthAlgorithms.VerifyPassword(credentials.Password, user.Password))
                {
                    res.Message = "Password incorrect!";
                    res.Success = false;
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
                    res.Message = "Invalid attempt - session not found!";
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
                res.Data.ProfileImg = await _context.dbo_ProfilePhotos.Where(pp => pp.UserId == user.Id).Select(pp => pp.Photo).FirstOrDefaultAsync();
                res.Message = "Validation successful!";
                res.Success = true;
                res.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception ex)
            {
                res.Message = ex.StackTrace;
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
            if (session.User.Role.Name != "Student")
            {
                res.Success = false;
                res.StatusCode = StatusCodes.Status401Unauthorized;
                res.Message = "Only students can access this endpoint!";
                return res;
            }
            try
            {
                var student = await _context.dbo_Student
                    .Include(s => s.Class)
                    .Include(s => s.School)
                    .FirstOrDefaultAsync(s => s.UserId == session.UserId);

                if (student != null)
                {
                    var parentsInfo = await _context.dbo_ParentsInfo
                        .Include(pi => pi.Student)
                        .Where(pi => pi.StudentId == student.Id)
                        .Select(pi => _mapper.Map<Dtos.ParentsInfo.GetParentsInfoDto>(pi))
                        .FirstAsync();
                    var studentsCount = await _context.dbo_Student.Where(st => st.ClassId == student.ClassId).CountAsync();
                    var grades = await _context.dbo_Grade
                        .Include(g => g.Subject)
                        .Where(g => g.StudentId == session.UserId)
                        .OrderByDescending(g => g.Date)
                        .Select(g => _mapper.Map<Dtos.Grade.GetGradeDto>(g))
                        .Take(10)
                        .ToListAsync();
                    var absences = await _context.dbo_Absence
                        .Include(a => a.Subject)
                        .Where(a => a.StudentId == student.Id)
                        .Select(a => _mapper.Map<Dtos.Absence.GetAbsenceDto>(a))
                        .ToListAsync();
                    var cls = await _context.dbo_Class
                        .Where(c => c.Id == student.ClassId)
                        .Include(c => c.ClassSpecialization)
                        .Include(c => c.HomeroomTeacher)
                        .Include(c => c.School)
                        .Select(c => _mapper.Map<Dtos.Class.GetClassDto>(c)).FirstAsync();
                    var classLeader = await _context.dbo_ClassLeader.Where(cl => cl.ClassId == student.ClassId).Select(cl => $"{cl.ClassLeader.FirstName} {cl.ClassLeader.LastName}").FirstAsync();

                    res.Data = new Dtos.Profile.GetStudentProfileDto
                    {
                        Id = student.Id,
                        Absences = absences,
                        LatestGrades = grades,
                        Address = student.Address,
                        Class = cls,
                        FullName = $"{student.FirstName} {student.LastName}",
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Email = session.User.Email,
                        ParentsInfo = parentsInfo,
                        DateOfBirth = DateOnly.FromDateTime(student.DateOfBirth).ToString("dd MMMM yyyy", CultureInfo.GetCultureInfo("en-US")),
                    };
                    res.Data.Class.ClassLeader = classLeader;
                    res.Data.Class.StudentsCount = studentsCount;

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
        public async Task<SR<Dtos.Profile.GetTeacherProfileDto>> GetTeacherProfile(string sessionId)
        {
            var res = new SR<Dtos.Profile.GetTeacherProfileDto>();
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
            if (session.User.Role.Name != "Teacher")
            {
                res.Success = false;
                res.StatusCode = StatusCodes.Status401Unauthorized;
                res.Message = "Only teachers can access this endpoint!";
                return res;
            }
            try
            {
                var teacher = await _context.dbo_Teacher
                    .FirstOrDefaultAsync(s => s.UserId == session.UserId);
                res.Data = new Dtos.Profile.GetTeacherProfileDto();
                if (teacher is not null)
                {

                    var schools = await _context.dbo_SchoolTeacher
                        .Include(st => st.School)
                        .Where(st => st.TeacherId == teacher.Id)
                        .ToListAsync();
                    var classes = await _context.dbo_ClassSubject
                        .Include(cs => cs.Class)
                        .Where(cs => cs.TeacherId == teacher.Id)
                        .ToListAsync();
                    classes = classes.Where(cs => schools.Any(sc => sc.SchoolId == cs.Class.SchoolId)).ToList();
                    res.Data.SchoolsTaught = new List<Dtos.School.GetSchoolWClassesDto>();
                    foreach (var sc in schools)
                    {
                        res.Data.SchoolsTaught.Add(new Dtos.School.GetSchoolWClassesDto
                        {
                            Name = sc.School.Name,
                            Classes = classes
                                .OrderBy(cls => cls.Class.Name)
                                .Select(cls => cls.Class.Name)
                                .Distinct()
                                .ToList()
                        });
                    }
                    res.Data.Subjects = await _context.dbo_TeacherSubject
                        .Include(ts => ts.Subject)
                        .Where(ts => ts.TeacherId == teacher.Id)
                        .Select(ts => ts.Subject.Name)
                        .ToListAsync();
                    res.Data.Id = teacher.Id;
                    res.Data.Address = teacher.Address;
                    res.Data.FullName = $"{teacher.FirstName} {teacher.LastName}";
                    res.Data.FirstName = teacher.FirstName;
                    res.Data.LastName = teacher.LastName;
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
        private async Task<bool> userExists(string username) => await _context.dbo_User.Where(u => u.Username.ToLower() == username.ToLower()).CountAsync() != 0;

    }
}