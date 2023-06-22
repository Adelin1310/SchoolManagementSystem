using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos.Grade;
using server.Dtos.Absence;

namespace server.Dtos.Subject
{
    public class GetStudentSituationDto
    {
        public string Subject { get; set; }
        public List<GetGradeDto> Grades { get; set; }
        public List<GetAbsenceDto> Absences { get; set; }
        public decimal? Situation { get; set; }
    }
}