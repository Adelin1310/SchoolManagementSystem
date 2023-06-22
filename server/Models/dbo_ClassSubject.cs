using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class dbo_ClassSubject
    {
        /*
            This class/table solves the following problem:

            I need to know which Teacher teaches which Subject to which Class,
            therefore I made this class/table to make unique pairs of the three. 
        */
        public int Id { get; set; }
        public int ClassId { get; set; }
        public dbo_Class Class { get; set; }
        public int SubjectId { get; set; }
        public dbo_Subject Subject { get; set; }
        public int TeacherId { get; set; }
        public dbo_Teacher Teacher { get; set; }
        public int WeeklyHours { get; set; }
        public int RequiredGrades { get; set; }
    }
}