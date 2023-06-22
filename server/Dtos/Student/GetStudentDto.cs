using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos.Class;
using server.Dtos.School;
using server.Models;

namespace server.Dtos.Student
{
    public class GetStudentDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public int SchoolId { get; set; }
        public int ClassId { get; set; }
        public string School { get; set; } = string.Empty;
        public string? Photo { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}