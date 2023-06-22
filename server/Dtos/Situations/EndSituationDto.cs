using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Situations
{
    public class EndSituationDto
    {
        public int StudentId { get; set; }
        public int ClassbookId { get; set; }
        public int SubjectId { get; set; }
    }
}