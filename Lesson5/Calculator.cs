using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    public class Calculator : ICalc
    {
        public float result = 0;
        public event EventHandler<EventArgs>? EventResult;

        public float Add(int x)
        {

            result += x;
            operation.Push(new Tuple<string, int>("+", x));
            SendResult();
            return result;
        }

        public float Sub(int x)
        {

            result -= x;
            operation.Push(new Tuple<string, int>("-", x));

            SendResult();
            return result;
        }

        public float Mul(int x)
        {

            result *= x;
            operation.Push(new Tuple<string, int>("*", x));

            SendResult();
            return result;
        }

        public float Div(int x)
        {

            result /= x;
            operation.Push(new Tuple<string, int>("/", x));

            SendResult();
            return result;
        }

        public void CancelLast()
        {
            string currentOperation = operation.Peek().Item1;
            switch (currentOperation)
            {
                case "+":
                    result -= operation.Pop().Item2;
                    break;
                case "-":
                    result += operation.Pop().Item2;
                    break;
                case "*":
                    result /= operation.Pop().Item2;
                    break;
                case "/":
                    result *= operation.Pop().Item2;
                    break;
                default:
                    Console.WriteLine("Ошибка");
                    break;


            }

            SendResult();
        }

        public int EnterNum(out bool exit)
        {
            exit = false;
            Console.WriteLine("Введите число!");
            var num = Console.ReadLine();
            if (num != "")
            {
                return int.Parse(num);
            }
            exit = true;
            return 0;
        }

        private void SendResult()
        {
            EventResult.Invoke(this, new EventArgs());
        }
        public Stack<Tuple<string, int>> operation = new Stack<Tuple<string, int>>();


    }
}
