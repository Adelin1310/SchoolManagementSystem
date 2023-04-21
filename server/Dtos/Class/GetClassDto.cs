using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Dtos.Class
{
    public class GetClassDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string School { get; set; } = string.Empty;
        public int SchoolId { get; set; }
    }
}