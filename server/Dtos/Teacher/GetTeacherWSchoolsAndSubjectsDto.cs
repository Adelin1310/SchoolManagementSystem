using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Teacher
{
    public class GetTeacherWSchoolsAndSubjectsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Age { get; set; }
        public List<string> Schools { get; set; } = new List<string>();
        public List<string> Subjects { get; set; } = new List<string>();
    }
}