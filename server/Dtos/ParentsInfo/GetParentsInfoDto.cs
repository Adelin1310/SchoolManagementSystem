using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.ParentsInfo
{
    public class GetParentsInfoDto
    {
        public string MotherFirstName { get; set; }
        public string MotherLastName { get; set; }
        public string MotherJob { get; set; }
        public string MotherPhone { get; set; }
        public DateOnly MotherDateOfBirth { get; set; }
        public string FatherFirstName { get; set; }
        public string FatherLastName { get; set; }
        public string FatherJob { get; set; }
        public string FatherPhone { get; set; }
        public DateOnly FatherDateOfBirth { get; set; }
    }
}