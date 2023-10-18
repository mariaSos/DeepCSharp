namespace Lesson4
{
    //Дан массив и число.Найдите три числа в массиве сумма которых равна искомому числу.
    //Подсказка: если взять первое число в массиве, 
     //можно ли найти в оставшейся его части два числа равных по сумме первому.
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 7, 8, 9, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            int target = 189;

            var s = new HashSet<int>();

            foreach (int i in arr)
            {
                foreach (int j in arr)
                {
                    var x = target - j - i;
                    if (s.Contains(x))
                    {
                        Console.WriteLine($"{target} = {x} + {j} + {i} ");
                    }
                    else
                    {
                        s.Add(j);
                    }
                }
            }
        }
    }
}