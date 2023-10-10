using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    public class FamilyMember
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public FamilyMember Father { get; set; }
        public FamilyMember Mother { get; set; }
        public Gender Gend { get; set; }

        public virtual void Info(int indent = 0)
        {

            ShowIndent(indent, "-");

            Console.WriteLine($"Имя: {Name}");
        }

        public void ShowParent()
        {
            if (Father == null)
                Console.WriteLine("Отец неизвестен");
            else
                Console.WriteLine("Отец:" + Father.Name);
            Console.WriteLine("Мать:" + Mother?.Name);
        }
        public void ShowGrandParent()
        {

            Console.WriteLine("По отцовской линии:");
            Console.WriteLine("Дедушка:" + Father?.Father?.Name);
            Console.WriteLine("Бабушка:" + Father?.Mother?.Name);

            Console.WriteLine("По материнской линии:");
            Console.WriteLine("Дедушка:" + Mother?.Father?.Name);
            Console.WriteLine("Бабушка:" + Mother?.Mother?.Name);
        }
        public void ShowIndent(int indent, string str)
        {
            for (int i = 0; i < indent; i++)
            {

                Console.Write(str);

            }
        }
    }
}
