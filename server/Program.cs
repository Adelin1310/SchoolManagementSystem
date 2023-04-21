using Microsoft.VisualBasic.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using server;
using server.Services;
using server.Services.Interfaces;
using server.Utils.Auth;

var builder = WebApplication.CreateBuilder(args);
// Get Jwt Settings from appsettings.json
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database connection using Pomelo's EFCore MySql package
var connString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<SMGMSYSContext>(options => options.UseMySQL(connString ?? ""));

// Configure token validation parameters using the JWT settings, including the expiration time
var tokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidIssuer = jwtSettings.Issuer,

    ValidateAudience = true,
    ValidAudience = jwtSettings.Audience,

    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),

    // Set the token expiration time
    ValidateLifetime = true,
    ClockSkew = TimeSpan.Zero, // No clock skew
    RequireExpirationTime = true,
};

// Services registration
builder.Services.AddScoped<IAbsenceService, AbsenceService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IClassbookService, ClassbookService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<ISchoolService, SchoolService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddSingleton<ITokenGenerator, TokenGenerator>();
builder.Services.AddAutoMapper(typeof(server.AutoMapperProfile).Assembly);

builder.Services.AddAuthentication().AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = !builder.Environment.IsDevelopment();
    opt.SaveToken = true;
    opt.TokenValidationParameters = tokenValidationParameters;
});
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.WithOrigins("http://localhost:3000");
    builder.AllowCredentials();
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
