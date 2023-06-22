using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos.Absence;
using server.Dtos.Grade;

namespace server.Dtos.Student
{
    public class GetStudentWSituationDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<GetGradeDto> Grades { get; set; }
        public List<GetAbsenceDto> Absences { get; set; }
        public decimal? Situation { get; set; }
        public bool CanEnd { get; set; }
        public bool IsEnded { get; set; }
    }
}