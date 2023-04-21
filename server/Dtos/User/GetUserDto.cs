using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.User
{
    public class GetUserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; }
    }
}