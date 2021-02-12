using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exceptions
{
    public class TodoValidationException : Exception
    {
        public TodoValidationException()
        {
        }

        public TodoValidationException(string message)
            : base(message)
        {
        }

        public TodoValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
