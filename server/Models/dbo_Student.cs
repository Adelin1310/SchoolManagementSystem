using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class dbo_Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int ClassId { get; set; }
        public dbo_Class Class { get; set; }
        public int SchoolId { get; set; }
        public dbo_School School { get; set; }
        public string? Photo { get; set; }
    }
}