using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class dbo_Class
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public dbo_School School { get; set; }
    }
}