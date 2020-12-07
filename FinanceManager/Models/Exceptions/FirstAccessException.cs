using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Models.Exceptions
{
    public class FirstAccessException : Exception
    {
        public FirstAccessException(string message)
            : base(message)
        { }
    }
}
