using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Models;
namespace server
{
    public class SMGMSYSContext : DbContext
    {

        public DbSet<dbo_Absence> dbo_Absence { get; set; }
        public DbSet<dbo_Class> dbo_Class { get; set; }
        public DbSet<dbo_Classbook> dbo_Classbook { get; set; }
        public DbSet<dbo_Grade> dbo_Grade { get; set; }
        public DbSet<dbo_School> dbo_School { get; set; }
        public DbSet<dbo_SchoolTeacher> dbo_SchoolTeacher { get; set; }
        public DbSet<dbo_Student> dbo_Student { get; set; }
        public DbSet<dbo_Subject> dbo_Subject { get; set; }
        public DbSet<dbo_Teacher> dbo_Teacher { get; set; }
        public DbSet<dbo_TeacherSubject> dbo_TeacherSubject { get; set; }

        public SMGMSYSContext(DbContextOptions options) : base(options)
        {
        }

    }
}