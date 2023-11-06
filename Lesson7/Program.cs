using System;
using System.Reflection;
using System.Text;

namespace Lesson7
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CastomNameAttribute : Attribute
    {
        public int I = 0;
        public string CustomFieldName  { get; set; }
        public CastomNameAttribute(string name) => CustomFieldName = name;
    }


    class TestClass
    {
        public int I { get; set; }
        public string? S { get; set; }
        [CastomName("ToToTo")]
        public decimal D { get; set; }
        public char[]? C { get; set; }

        public TestClass()
        { }
        public TestClass(int i)
        {
            this.I = i;
        }
        public TestClass(int i, string s, decimal d, char[] c) : this(i)
        {
            this.S = s;
            this.D = d;
            this.C = c;
        }
    }

    internal class Program
    {
        static string ObjectToString(object o)
        {
            StringBuilder builder = new();

            builder.Append(o.GetType().ToString() + "|");
            var properties = o.GetType().GetProperties();

            foreach (var property in properties)
            {
                builder.Append(property.PropertyType + "|");
                                

                if (property.GetCustomAttribute<CastomNameAttribute>() != null)
                {
                    builder.Append(property.GetCustomAttribute<CastomNameAttribute>().CustomFieldName + ":");
                }
                else
                {
                    builder.Append(property.Name + ":");
                }



                if (property.PropertyType == typeof(char[]))
                {
                    if (property.GetValue(o, null) != null)
                    {
                        foreach (var value in property.GetValue(o, null) as char[])
                        {

                            builder.Append(value + "|");

                        }
                    }

                }
                else
                {

                    builder.Append(property.GetValue(o) + "|");
                }
            }
            return builder.ToString();
        }
        static object StringToObject(string s)
        {
            var parser = s.Split("|");

            Object obj = Activator.CreateInstance(null, parser[0]).Unwrap(); // 1 type

            Type type = obj.GetType();
            var properties = type.GetProperties();

            for (int i = 1; i < parser.Length - 3; i += 3)
            {
                var property = type.GetProperty(parser[i + 1]);
             
                if (property?.PropertyType == typeof(int))
                {
                    property.SetValue(obj, int.Parse(parser[i + 2]));
                }
                else if (property?.PropertyType == typeof(string))
                {
                    property.SetValue(obj, parser[i + 2]);
                }
                else if (property?.PropertyType == typeof(decimal))
                {
                    property.SetValue(obj, decimal.Parse(parser[i + 2]));
                }
                else if (property?.PropertyType == typeof(char[]))
                {
                    char[] c = new char[3];
                    for (int j = 0; j < c.Length; j++)
                    {
                        c[j] = Char.Parse(parser[i + 2 + j]);
                    }
                    property.SetValue(obj, c);

                }
            }

            return obj;
        }


        static void Main()
        {
            // Разработайте атрибут позволяющий методу
            // ObjectToString сохранять поля классов с использованием произвольного имени.

            TestClass test = new(1, "строка", 2.0m, new char[] { 'A', 'B', 'C' });

            string str = ObjectToString(test);

            Console.WriteLine("Наш  класс: " + str);

           // var obj = StringToObject(str);

           // Console.WriteLine("Наш объект: " + ObjectToString(obj));

        }
    }
}