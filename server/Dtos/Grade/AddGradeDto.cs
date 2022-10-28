using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Grade
{
    public class AddGradeDto
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
    }
}