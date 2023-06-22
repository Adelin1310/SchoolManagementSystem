using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server
{
    public class SR<T>
    {
        public T Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; } = true;
        public int StatusCode { get; set; } = 200;

        public void NotFound(string Name)
        {
            this.Message = $"{Name} not found!";
            Success = false;
            StatusCode = StatusCodes.Status404NotFound;
        }

        public void SetStatusCode(int statusCode)
        {
            this.StatusCode = statusCode;
        }
        public void SetError()
        {
            Success = false;
            StatusCode = StatusCodes.Status500InternalServerError;
            Message = "Unexpected Error! Contact support team.";
        }
        public void SetSessionExpiredError()
        {
            Success = false;
            StatusCode = StatusCodes.Status401Unauthorized;
            Message = "Session Expired!";
        }
    }
}