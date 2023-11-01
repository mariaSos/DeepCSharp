namespace Lesson8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Укажите через пробел имя каталога где искать файл, расширение файла и искомую строку!");
                return;
            }

            string searchDirectory = args[0];
            string fileName = args[1];
            string str = args[2];

            try
            {
                ResearchRecursive(searchDirectory, fileName,str);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Что-то пошло не так: {ex.Message}");
            }
        }

        static void ResearchRecursive(string dirNAme, string fileName, string str)
        {
            string[] matchingFiles = Directory.GetFiles(dirNAme, "*" +fileName);

            foreach (string file in matchingFiles)
            {               
                using (var reader = new StreamReader(File.Open(file, FileMode.Open)))
                {
                    while (reader.Peek() >= 0)
                    {
                        var line = reader.ReadLine();

                        if (line!.ToLower().Contains(str.ToLower()))
                        {
                            Console.WriteLine($"Найдена строка: {line} в файле {file}" );
                        }
                    }
                }
            }

            string[] subDirectories = Directory.GetDirectories(dirNAme);

            foreach (string subDirectory in subDirectories)
            {
                ResearchRecursive(subDirectory, fileName, str);
            }
        }

    }
}
