using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Class
{
    public class GetClassSubjectDto
    {
        public int Id { get; set; }
        public int ClassbookId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string School { get; set; } = string.Empty;
        public int SchoolId { get; set; }
        public string Specialization { get; set; }
        public string Year { get; set; }
        public int StudentsCount { get; set; }
        public string HomeroomTeacher { get; set; }
        public int HomeroomTeacherId { get; set; }
    }
}