using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QulixTask.Exceptions
{
    public class ItemNotFoundException : ArgumentNullException
    {
        public ItemNotFoundException()
        : base() { }
        public ItemNotFoundException(string message)
        : base(message) { }
    }
}
