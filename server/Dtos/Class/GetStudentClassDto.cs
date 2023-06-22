using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Class
{
    public class GetStudentClassDto
    {
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; }
        public string Year { get; set; }
        public int StudentsCount { get; set; }
        public string ClassLeader { get; set; }
        public string HomeroomTeacher { get; set; }
        public List<Student.GetStudentDto> Students { get; set; }
    }
}