using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    class CalculatorException : Exception
    {
        public CalculatorException(string msg, Exception inner, List<CalculatorActionLog> log) : base(msg, inner)
        {
        }
    }
}
