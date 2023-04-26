using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class dbo_User
    {
        public int Id { get; set; }
        public string Email {get;set;} = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public dbo_Role Role { get; set; }
        public int RoleId { get; set; }
    }
}