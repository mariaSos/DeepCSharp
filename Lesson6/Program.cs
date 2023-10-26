namespace Lesson6
{
    /*
         Доработайте класс калькулятора способным работать как с целочисленными так и с дробными числами.
        *Дап задание необязательное: задействовать перегрузку операторов (предлагаю +=, *=, -=, /= вместо тех функций которые уже реализованы)
         */
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            float num = 0;
            calculator.GotResult += Calculator_GotResult;
            
            /*Доп.задание*/
            num = calculator + 120;
            num = calculator - 10;
            num = calculator / 2;
            num = calculator * 2.5f;
            calculator.CancelLast();
            calculator.CancelLast();
            num = calculator + 5.55f;

            /*Вызов других методов*/
            /*calculator.Add(20);
            calculator.Add(40);
            calculator.Sub(4.5f);
            calculator.Div(2.6f);
            calculator.Mul(5);
            calculator.CancelLast();*/

        }

        private static void Calculator_GotResult(object? sender, EventArgs e)
        {
            Console.SetCursorPosition(1, 1);
            Console.WriteLine(((Calculator)sender).Result);
        }
    }
}