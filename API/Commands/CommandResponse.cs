using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Commands
{
    public class CommandResponse
    {
        public CommandResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }

        public string Message { get; private set; }
        public bool Success { get; private set; }
        //public IEnumerable<ValidationFailure> ValidationErrors { get; } = new List<ValidationFailure>();
        //public bool IsSuccessful => ValidationErrors == null || !ValidationErrors.Any();
    }
}
