using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class dbo_Situations
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public dbo_Student Student { get; set; }
        public int SubjectId { get; set; }
        public dbo_Subject Subject { get; set; }
        public int ClassbookId { get; set; }
        public dbo_Classbook Classbook { get; set; }
        public decimal Value { get; set; }
        public bool IsGeneralAverage { get; set; }
    }
}