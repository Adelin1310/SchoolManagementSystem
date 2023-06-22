using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class dbo_Class
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ClassSpecializationId { get; set; }
        public dbo_ClassSpecialization ClassSpecialization { get; set; }
        public int HomeroomTeacherId { get; set; }
        public dbo_Teacher HomeroomTeacher { get; set; }
        public int SchoolId { get; set; }
        public dbo_School School { get; set; } = new dbo_School();
        public string Year { get; set; }
    }
}