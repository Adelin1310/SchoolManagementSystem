using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Utils.Auth;
namespace server.Models
{
    public class dbo_Session
    {
        public string Id { get; set; } = AuthAlgorithms.GenerateSessionId();
        public string Token { get; set; } = string.Empty;
        public int UserId { get; set; }
        public dbo_User User { get; set; }
    }
}