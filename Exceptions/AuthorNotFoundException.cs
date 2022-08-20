using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QulixTask.Exceptions
{
    public class AuthorNotFoundException : ArgumentNullException
    {
        public AuthorNotFoundException()
        : base() { }
        public AuthorNotFoundException(string message)
        : base(message) { }
    }
}

