using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Dtos.Absence
{
    public class GetAbsenceDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public dbo_Student MyProperty { get; set; }
        public int SubjectId { get; set; }
        public dbo_Subject Subject { get; set; }
        public DateTime Date { get; set; }
        public bool WithLeave { get; set; }
    }
}