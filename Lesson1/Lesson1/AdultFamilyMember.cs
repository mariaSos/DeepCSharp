using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    public class AdultFamilyMember : FamilyMember
    {
        public FamilyMember[]? Children { get; set; }
        public FamilyMember Husband { get; set; }
        public FamilyMember Wife { get; set; }

        public override void Info(int indent = 0)

        {
            base.Info(indent);
            ShowParther(indent);

            foreach (var child in Children)
            {
                child.Info(indent * 2);
            }

        }

        public void ShowParther(int indent)
        {
            if (Husband != null || Wife != null)
            {
                ShowIndent(indent, " ");
            }

            if (Husband != null)
                Console.WriteLine($"Муж: {Husband.Name}");
            if (Wife != null)
                Console.WriteLine($"Жена: {Wife.Name}");
        }
    }

}
