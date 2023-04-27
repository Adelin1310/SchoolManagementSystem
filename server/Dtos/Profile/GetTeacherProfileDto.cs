using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Profile
{
    public class GetTeacherProfileDto : Base.Profile
    {
        public List<School.GetSchoolWClassesDto> SchoolsTaught { get; set; }
        public List<string> Subjects { get; set; }
    }
}