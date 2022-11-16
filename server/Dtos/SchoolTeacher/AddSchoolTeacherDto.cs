using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.SchoolTeacher
{
    public class AddSchoolTeacherDto
    {
        public int TeacherId { get; set; }
        public int SchoolId { get; set; }
    }
}