using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class dbo_TeacherSubject
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public dbo_Teacher Teacher { get; set; }
        public int SubjectId { get; set; }
        public dbo_Subject Subject { get; set; }
    }
}