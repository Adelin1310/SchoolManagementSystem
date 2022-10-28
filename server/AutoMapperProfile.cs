using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using server.Dtos.Absence;
using server.Dtos.Class;
using server.Dtos.Classbook;
using server.Dtos.Grade;
using server.Dtos.School;
using server.Dtos.Student;
using server.Dtos.Subject;
using server.Dtos.Teacher;
using server.Models;

namespace server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
                        //Add -> Models
            CreateMap<AddAbsenceDto, dbo_Absence>().ReverseMap();
            CreateMap<AddClassDto, dbo_Class>().ReverseMap();
            CreateMap<AddClassbookDto, dbo_Classbook>().ReverseMap();
            CreateMap<AddGradeDto, dbo_Grade>().ReverseMap();
            CreateMap<AddSchoolDto, dbo_School>().ReverseMap();
            CreateMap<AddStudentDto, dbo_Student>().ReverseMap();
            CreateMap<AddSubjectDto, dbo_Subject>().ReverseMap();
            CreateMap<AddTeacherDto, dbo_Teacher>().ReverseMap();

            //Models -> Get
            CreateMap<dbo_Absence, GetAbsenceDto>().ReverseMap();
            CreateMap<dbo_Class, GetClassDto>().ReverseMap();
            CreateMap<dbo_Classbook, GetClassbookDto>().ReverseMap();
            CreateMap<dbo_Grade, GetGradeDto>().ReverseMap();
            CreateMap<dbo_School, GetSchoolDto>().ReverseMap();
            CreateMap<dbo_Student, GetStudentDto>()
                .ForMember(x=>x.FullName, opt=>opt.MapFrom(y=>y.FirstName + " " + y.LastName))
                .ForMember(x=>x.School, opt=>opt.MapFrom(y=>y.School.Name));
            CreateMap<dbo_Subject, GetSubjectDto>().ReverseMap();
            CreateMap<dbo_Teacher, GetTeacherDto>().ReverseMap();
        }
    }
}