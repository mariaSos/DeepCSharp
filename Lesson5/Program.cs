namespace Lesson5
{
    
    public class Calculator : ICalc
    {
        public float result = 0;
        public event EventHandler<EventArgs> ?EventResult;

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
    //Доработайте программу калькулятор реализовав выбор действий и вывод
    //результатов на экран в цикле так чтобы калькулятор мог работать до тех пор
    //пока пользователь не нажмет отмена или введёт пустую строку.
    internal class Program
    {

        static void Main(string[] args)
        {

            Calculator c = new Calculator();

            c.EventResult += C_EventResult;

            float result = 0;
            var input = "";
            bool exit = false;
             while (input !="6" & exit == false )
             {
                Console.WriteLine(exit);
                Console.WriteLine("Список допустимых операций:");
                Console.WriteLine("1 - сложение");
                Console.WriteLine("2 - вычитание");
                Console.WriteLine("3 - деление");
                Console.WriteLine("4 - умножение");
                Console.WriteLine("5 - Отмена предыдущей операции");
                Console.WriteLine("6 - Выход");
                Console.WriteLine("Введите номер операции!");

                input = Console.ReadLine();

                     switch (input)
                     {
                         case "1":
                             c.Add(c.EnterNum(out exit));
                             break;
                         case "2":
                             c.Sub(c.EnterNum(out exit));
                             break;
                         case "3":
                             c.Div(c.EnterNum(out exit));
                             break;
                         case "4":
                             c.Mul(c.EnterNum(out exit));
                            break;
                         case "5":
                         c.CancelLast();
                            break;
                         case "6":
                            break;
                         default:
                            Console.WriteLine("Неверная операция");
                            break;
                     }

                 }
            c.EventResult += C_EventResult;

        }

        private static void C_EventResult(object? sender, EventArgs e)
        {
            Console.WriteLine("Результат: "+((Calculator)sender).result);
        }
    }
}