using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Student
{
    public class AddStudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int ClassId { get; set; }
        public int SchoolId { get; set; }
        public string? Photo { get; set; }

    }
}