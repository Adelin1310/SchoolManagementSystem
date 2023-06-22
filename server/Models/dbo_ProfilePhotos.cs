using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    // IMPORTANT: 
    // This class/table solves a problem that I had with the 
    // redundancy of the Photo field in the Student and Teacher tables
    // I need the photos to be displayed as profile icon on the topbar
    public class dbo_ProfilePhotos
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public dbo_Student? Student { get; set; }
        public int? TeacherId { get; set; }
        public dbo_Teacher? Teacher { get; set; }
        public int UserId { get; set; }
        public dbo_User User { get; set; }
        public string Photo { get; set; }
    }
}