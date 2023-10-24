using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    interface ICalc
    {
        event EventHandler<EventArgs> EventResult;
        float Add(int i);
        float Sub(int i);
        float Div(int i);
        float Mul(int i);
        void CancelLast();
    }
}
