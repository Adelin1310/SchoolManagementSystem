using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Teacher
{
    public class GetClassWSubjectDto{
        public string Name { get; set; }
        public string Subject { get; set; }
    }

    public class GetTeacherWClassesAndSubjectsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<GetClassWSubjectDto> Classes { get; set; }
        public List<string> Subjects { get; set; }
    }
}