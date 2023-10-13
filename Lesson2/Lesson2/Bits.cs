using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public class Bits :IBits
    {
        public Bits(byte b)
        {
            this.Value = b;
            this.Size = 8;
        }

        public Bits(long b)
        {
            this.Value = b;
            this.Size = 64;
        }

        public Bits(int b)
        {
            this.Value = b;
            this.Size = 32;
        }


        //Операторы неявного приведения из long,int,byte в Bits
        public static implicit operator Bits(byte b) => new Bits(b);

        public static implicit operator Bits(int b) => new Bits(b);

        public static implicit operator Bits(long b) => new Bits(b);


        public bool getBits(int numer)
        {
            if (numer > Size - 1 || numer < 0)
            {
                Console.WriteLine("Ошибка! Выход за пределы");
                return false;
            }
            return ((Value >> numer) & 1) == 1;
        }

        public void setBits(int numer, bool bit)
        {
            if (numer > Size - 1 || numer < 0) return;
            if (bit == true)
                Value = (byte)(Value | (1 << numer));
            else
            {
                var mask = (byte)(1 << numer);
                mask = (byte)(0xff ^ mask);
                Value &= (byte)(Value & mask);
            }
        }


        public long Value { get; private set; } = 0;
        
        private int Size = 64;

    }
}
