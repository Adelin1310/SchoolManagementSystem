using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using server.Dtos.Absence;
using server.Dtos.Class;
using server.Dtos.Classbook;
using server.Dtos.Grade;
using server.Dtos.ParentsInfo;
using server.Dtos.School;
using server.Dtos.SchoolTeacher;
using server.Dtos.Student;
using server.Dtos.Subject;
using server.Dtos.Teacher;
using server.Dtos.TeacherSubject;
using server.Dtos.User;
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
            CreateMap<AddSchoolTeacherDto, dbo_SchoolTeacher>().ReverseMap();
            CreateMap<AddTeacherSubjectDto, dbo_TeacherSubject>().ReverseMap();
            CreateMap<AddParentsInfoDto, dbo_ParentsInfo>().ReverseMap();

            //Models -> Get
            CreateMap<dbo_Absence, GetAbsenceDto>()
                .ForMember(x=>x.Date, opt=>opt.MapFrom(y=>DateOnly.FromDateTime(y.Date)))
                .ReverseMap();
            CreateMap<dbo_Class, GetClassDto>()
                .ForMember(x => x.School, opt => opt.MapFrom(y => y.School.Name))
                .ForMember(x => x.HomeroomTeacher, opt => opt.MapFrom(y => $"{y.HomeroomTeacher.FirstName} {y.HomeroomTeacher.LastName}"))
                .ForMember(x => x.Specialization, opt => opt.MapFrom(y => y.ClassSpecialization.Name));
            CreateMap<dbo_Class, GetStudentClassDto>()
                .ForMember(x => x.HomeroomTeacher, opt => opt.MapFrom(y => $"{y.HomeroomTeacher.FirstName} {y.HomeroomTeacher.LastName}"))
                .ForMember(x => x.Specialization, opt => opt.MapFrom(y => y.ClassSpecialization.Name));
            

            CreateMap<dbo_ClassSubject, GetTeacherWSubject>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(y => y.Teacher.FirstName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(y => y.Teacher.LastName))
                .ForMember(x => x.FullName, opt => opt.MapFrom(y => $"{y.Teacher.FirstName} {y.Teacher.LastName}"))
                .ForMember(x => x.Subject, opt => opt.MapFrom(y => y.Subject.Name))
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.TeacherId)).ReverseMap();
            CreateMap<dbo_ClassSubject, GetClassWSubjectDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.Class.Name))
                .ForMember(x => x.Subject, opt => opt.MapFrom(y => y.Subject.Name)).ReverseMap();
            CreateMap<dbo_ClassSubject, GetClassSubjectDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.ClassId))
                .ForMember(x => x.HomeroomTeacher, opt => opt.MapFrom(y => $"{y.Class.HomeroomTeacher.FirstName} {y.Class.HomeroomTeacher.LastName}"))
                .ForMember(x => x.HomeroomTeacherId, opt => opt.MapFrom(y => y.Class.HomeroomTeacherId))
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.Class.Name))
                .ForMember(x => x.School, opt => opt.MapFrom(y => y.Class.School.Name))
                .ForMember(x => x.SchoolId, opt => opt.MapFrom(y => y.Class.SchoolId))
                .ForMember(x => x.Specialization, opt => opt.MapFrom(y => y.Class.ClassSpecialization.Name))
                .ForMember(x => x.Year, opt => opt.MapFrom(y => y.Class.Year)).ReverseMap();

            CreateMap<dbo_Grade, GetGradeDto>()
                .ForMember(x=>x.Date, opt=>opt.MapFrom(y=>DateOnly.FromDateTime(y.Date)))
                .ReverseMap();
            CreateMap<dbo_ParentsInfo, GetParentsInfoDto>()
                .ForMember(x => x.FatherDateOfBirth, opt => opt.MapFrom(y => DateOnly.FromDateTime(y.FatherDateOfBirth)))
                .ForMember(x => x.MotherDateOfBirth, opt => opt.MapFrom(y => DateOnly.FromDateTime(y.MotherDateOfBirth)))
                .ReverseMap();
            CreateMap<dbo_School, GetSchoolDto>().ReverseMap();
            CreateMap<dbo_Student, GetStudentDto>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(y => y.FirstName + " " + y.LastName))
                .ForMember(x => x.School, opt => opt.MapFrom(y => y.School.Name))
                .ForMember(x => x.Class, opt => opt.MapFrom(y => y.Class.Name))
                .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(y => DateOnly.FromDateTime(y.DateOfBirth)));
            CreateMap<dbo_Subject, GetSubjectDto>().ReverseMap();
            CreateMap<dbo_Teacher, GetTeacherDto>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(y => y.FirstName + " " + y.LastName));
            CreateMap<dbo_Teacher, GetTeacherWSchoolsAndSubjectsDto>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(y => y.FirstName + " " + y.LastName));
            CreateMap<dbo_Teacher, GetTeacherWClassesAndSubjectsDto>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(y => y.FirstName + " " + y.LastName));
            CreateMap<dbo_User, GetUserDto>()
                .ForMember(x => x.Role, opt => opt.MapFrom(y => y.Role.Name));
        }
    }
}