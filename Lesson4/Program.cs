namespace Lesson4
{
    //Дан массив и число.Найдите три числа в массиве сумма которых равна искомому числу.
    //Подсказка: если взять первое число в массиве, 
     //можно ли найти в оставшейся его части два числа равных по сумме первому.
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {6, 2, 3, 7, 8, 9, 10, 22,20, 30, 40, 50, 60, 70, 80, 90, 100,110 };

            int target = 116;

            var s = new HashSet<int>();
            s.Add(arr[0]);
            
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    
                    var x = target - arr[j] - arr[i];
                    
                    
                    if (s.Contains(x) & x < arr[j] & x < arr[i] & x != arr[j] & x != arr[i])
                    {
                        Console.WriteLine($"{target} = {x}  + {arr[i]} +  {arr[j]} ");
                    }
                    else
                    {
                        s.Add(arr[j]);
                    }
                }

            }
        }
    }
}