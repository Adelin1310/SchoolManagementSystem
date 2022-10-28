using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class dbo_Classbook
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public dbo_Class Class { get; set; }
    }
}