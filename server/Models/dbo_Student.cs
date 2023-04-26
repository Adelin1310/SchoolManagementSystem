using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class dbo_Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int ClassId { get; set; }
        public dbo_Class Class { get; set; }
        public int SchoolId { get; set; }
        public dbo_School School { get; set; }
        public int UserId { get; set; }
        public dbo_User User { get; set; }
        public string? Photo { get; set; }
    }
}