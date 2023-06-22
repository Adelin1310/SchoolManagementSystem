using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;
using server.Dtos.Student;
namespace server.Dtos.Classbook
{
    public class GetClassbookDto
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public bool isHomeroomTeacher { get; set; }
        public List<GetStudentWSituationDto> Students { get; set; }
    }
}