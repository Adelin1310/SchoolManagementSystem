using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Dtos.Classbook
{
    public class GetClassbookDto
    {
        public int Id { get; set; }
        public string Class { get; set; }
        public int ClassId { get; set; }
        public int StudentsCount { get; set; }
        public string School { get; set; }
    }
}