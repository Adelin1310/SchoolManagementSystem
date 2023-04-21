using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Class
{
    public class UpdateClassDto
    {
        public int SchoolId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}