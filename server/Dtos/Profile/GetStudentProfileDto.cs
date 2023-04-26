using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Profile
{
    public class GetStudentProfileDto : Base.Profile
    {
        public string Class { get; set; } = string.Empty;
        public string School { get; set; } = string.Empty;
        public List<Grade.GetGradeDto> LatestGrades = new List<Grade.GetGradeDto>();
        public List<Absence.GetAbsenceDto> Absences = new List<Absence.GetAbsenceDto>(); 
    }
}