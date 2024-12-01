using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Core.Errors
{
    public class ValidationException : ServiceException
    {
        public ValidationException(string message) : base(message) { }
    }
}
