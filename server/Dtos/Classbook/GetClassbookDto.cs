using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Dtos.Classbook
{
    public class GetClassbookDto
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public dbo_Class Class { get; set; }
    }
}