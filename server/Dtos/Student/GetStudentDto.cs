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
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Class { get; set; }
        public int SchoolId { get; set; }
        public int ClassId { get; set; }
        public string School { get; set; }
        public string? Photo { get; set; }
    }
}