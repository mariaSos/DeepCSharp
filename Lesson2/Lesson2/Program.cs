namespace Lesson2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            byte b = 222;
            Bits bits = new Bits(b);

            Console.WriteLine(bits.Value);
//-----------------------------------------------------
            long longs = 333;
            bits = longs;

            Console.WriteLine(bits.Value);
//-----------------------------------------------------
            int ints = 444;
            bits = ints;

            Console.WriteLine(bits.Value);
        }
    }
}