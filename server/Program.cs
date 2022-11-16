using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using server;
using server.Services;
using server.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database connection using Pomelo's EFCore MySql package
var connString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<SMGMSYSContext>(options=>options.UseMySQL(connString));


// Services registration
builder.Services.AddScoped<IAbsenceService, AbsenceService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IClassbookService, ClassbookService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<ISchoolService, SchoolService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddAutoMapper(typeof(server.AutoMapperProfile).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => {
    builder.AllowAnyOrigin();
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
