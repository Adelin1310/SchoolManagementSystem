using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.School
{
    public class GetSchoolWClassesDto
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Classes { get; set; }
    }
}