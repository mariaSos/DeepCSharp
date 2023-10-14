namespace Lesson3
{
    internal class Program
    {
        static bool HasExit(int startI, int startJ, int[,] l, out int count)
        {
            count = 0;
            Stack<Tuple<int, int>> next = new Stack<Tuple<int, int>>();
            Stack<Tuple<int, int, int>> next2 = new Stack<Tuple<int, int, int>>();

            next2.Push(new Tuple<int, int, int>(1, 2, 1));
            var cur = next2.Pop();
          
            //Кладем заданный элемент
            if (l[startI, startJ] == 0)
            {
                next.Push(new Tuple<int, int>(startI, startJ));
            }

            while (next.Count > 0)
            {
                var current = next.Pop();
                
                //Item < 0 - когда предположительный элемент, находится за пределами матрицы
                if (current.Item1 < 0 || current.Item1 == l.GetLength(0)) continue;
                if (current.Item2 < 0 || current.Item2 == l.GetLength(1)) continue;


                if (l[current.Item1, current.Item2] == 1) continue;
                
                //Определить сколько всего выходов имеется в лабиринте:

                if (l[current.Item1, current.Item2] == 0 && (current.Item1 == l.GetLength(0) - 1 | current.Item2 == l.GetLength(1) - 1) | current.Item1 == 0 | current.Item2 == 0)
                {
                    count++;
                }

                l[current.Item1, current.Item2] = 1;


                next.Push(new Tuple<int, int>(current.Item1 - 1, current.Item2));
                next.Push(new Tuple<int, int>(current.Item1 + 1, current.Item2));
                next.Push(new Tuple<int, int>(current.Item1, current.Item2 - 1));
                next.Push(new Tuple<int, int>(current.Item1, current.Item2 + 1));

            }
            Console.WriteLine($"Количество выходов = {count}");
            return false;
        }


        static void Main(string[] args)
        {
  
            int[,] labirynth1 = new int[,]
                {
                    {1, 1, 1, 1, 1, 1, 0 },
                    {1, 0, 0, 0, 0, 0, 0 },
                    {1, 0, 1, 1, 1, 0, 1 },
                    {0, 0, 0, 0, 1, 0, 1 },
                    {1, 1, 0, 0, 1, 0, 1 },
                    {1, 1, 1, 1, 1, 0, 0 },
                    {1, 1, 1, 1, 1, 1, 0 }
                };
            HasExit(0, 6, labirynth1, out int count);

            Console.ReadKey();

        }
    }
}