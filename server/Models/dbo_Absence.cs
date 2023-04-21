using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class dbo_Absence
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public dbo_Student Student { get; set; } = new dbo_Student();
        public int SubjectId { get; set; }
        public dbo_Subject Subject { get; set; } = new dbo_Subject();
        public DateTime Date { get; set; }
        public bool WithLeave { get; set; }
    }
}