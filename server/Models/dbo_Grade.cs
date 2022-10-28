using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class dbo_Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public dbo_Student Student { get; set; }
        public int SubjectId { get; set; }
        public dbo_Subject Subject { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
    }
}