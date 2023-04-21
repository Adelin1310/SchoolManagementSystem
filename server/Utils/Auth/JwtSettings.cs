using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Utils.Auth
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}