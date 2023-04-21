using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Utils.Auth
{
    public interface ITokenGenerator
    {
        public string GenerateToken(ClaimsIdentity claimsIdentity);
    }
}