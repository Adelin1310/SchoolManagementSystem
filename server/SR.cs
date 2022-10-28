using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server
{
    public class SR<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; } = true;

        public void NotFound(string Name)
        {
            this.Message = $"{Name} not found!";
            Success = false;
        }
    }
}