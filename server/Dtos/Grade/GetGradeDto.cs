using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Dtos.Grade
{
    public class GetGradeDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public dbo_Student Student { get; set; } = new dbo_Student();
        public int SubjectId { get; set; }
        public dbo_Subject Subject { get; set; } = new dbo_Subject();
        public int Value { get; set; }
        public DateTime Date { get; set; }
    }
}