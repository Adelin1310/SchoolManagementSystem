using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Utils.Auth
{
    public static class AuthAlgorithms
    {
        public static string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
        

        public static async Task<bool> ValidatePassword(string password)
        {
            bool hasUppercase = password.Any(char.IsUpper);
            bool hasLowercase = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));
            bool hasLengthOver8 = password.Length > 8;

            return hasUppercase && hasLowercase && hasDigit && hasSpecialChar && hasLengthOver8;
        }


        public static async Task<bool> VerifyPassword(string password, string passwordHash) => BCrypt.Net.BCrypt.Verify(password, passwordHash);
        

        public static string GenerateSessionId()
        {
            int sessionIdLength = 32; // Length of the session ID
            byte[] randomBytes = new byte[sessionIdLength];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            string sessionId = Convert.ToBase64String(randomBytes).TrimEnd('=');
            return sessionId;
        }
    }
}