using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Student
{
    public class UpdateStudentDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int ClassId { get; set; }
        public int SchoolId { get; set; }
        public string? Photo { get; set; }

    }
}