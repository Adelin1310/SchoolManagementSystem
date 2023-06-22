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
        public dbo_Student Student { get; set; }
        public int SubjectId { get; set; }
        public dbo_Subject Subject { get; set; }
        public int Value { get; set; }
        public DateOnly Date { get; set; }
    }
}