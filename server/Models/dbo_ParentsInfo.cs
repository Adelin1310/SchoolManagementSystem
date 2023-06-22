using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class dbo_ParentsInfo
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public dbo_Student Student { get; set; }
        public string MotherFirstName { get; set; }
        public string MotherLastName { get; set; }
        public string MotherJob { get; set; }
        public string MotherPhone { get; set; }
        public DateTime MotherDateOfBirth { get; set; }
        public string FatherFirstName { get; set; }
        public string FatherLastName { get; set; }
        public string FatherJob { get; set; }
        public string FatherPhone { get; set; }
        public DateTime FatherDateOfBirth { get; set; }

    }
}