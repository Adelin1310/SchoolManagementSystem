using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    // This class/table solves the following problem:
    /*
        One-to-one relationship that between Class and Student
        A student needs to be put in a Class, therefore I am unable
        to make a reference to a Student when any Student has a necessary
        reference to a Class

        In the DB, there is a UNIQUE index put on the pair made bt ClassLeaderId and ClassId
    */
    public class dbo_ClassLeader
    {
        public int Id { get; set; }
        public int ClassLeaderId { get; set; }
        public dbo_Student ClassLeader { get; set; }
        public int ClassId { get; set; }
        public dbo_Class Class { get; set; }
    }
}