using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class dbo_SchoolTeacher
    {
        public int SchoolId { get; set; }
        public dbo_School School { get; set; }
        public int TeacherId { get; set; }
        public dbo_Teacher Teacher { get; set; }
    }
}