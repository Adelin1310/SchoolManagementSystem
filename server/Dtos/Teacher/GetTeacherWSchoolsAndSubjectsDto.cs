using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Teacher
{
    public class GetTeacherWSchoolsAndSubjectsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public List<string> Schools { get; set; }
        public List<string> Subjects { get; set; }
    }
}