using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.TeacherSubject
{
    public class AddTeacherSubjectDto
    {
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
    }
}