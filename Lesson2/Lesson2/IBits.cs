using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    internal interface IBits
    {
        bool getBits(int numer);
        void setBits(int numer, bool bit);
    }
}
