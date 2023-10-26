using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    class CalculatorActionLog
    {
        public CalculatorAction CalcAction;
        public float CalcArgument;

        public CalculatorActionLog(CalculatorAction calcAction, float calcArgument)
        {
            this.CalcAction = calcAction;
            this.CalcArgument = calcArgument;
        }
    }
}
