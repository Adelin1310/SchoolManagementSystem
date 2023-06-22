using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Profile
{
    public class GetStudentProfileDto : Base.Profile
    {
        public Class.GetClassDto Class { get; set; }
        public ParentsInfo.GetParentsInfoDto ParentsInfo { get; set; }
        public List<Grade.GetGradeDto> LatestGrades = new List<Grade.GetGradeDto>();
        public List<Absence.GetAbsenceDto> Absences = new List<Absence.GetAbsenceDto>();
    }
}