namespace Lesson1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Прабушка и ее муж
            FamilyMember Mark = new FamilyMember() { Name = "Марк" };
            AdultFamilyMember Margo = new AdultFamilyMember() { Name = "Маргарита", Husband = Mark };

            //Дедушки родные и двоюродные

            AdultFamilyMember Pavel = new AdultFamilyMember() { Name = "Павел", Wife = new FamilyMember() { Name = "Ирина" }, Mother = Margo, Father = Mark };// Родной

            AdultFamilyMember Kiril = new AdultFamilyMember() { Name = "Кирилл", Wife = new FamilyMember() { Name = "Анна" }, Mother = Margo, Father = Mark };// двоюродный

            //Дети прабабушки
            Margo.Children = new FamilyMember[] { new FamilyMember() { Name = "Галина", Mother = Margo, Father = Mark }, Pavel, Kiril };

            //Тети дяди и родители
            AdultFamilyMember Ksu = new AdultFamilyMember() { Name = "Ксения", Father = Kiril };//двоюродная сестра

            AdultFamilyMember Max = new AdultFamilyMember() { Name = "Максим", Wife = new FamilyMember() { Name = "Юлия" }, Father = Pavel };// двоюродный

            AdultFamilyMember Fill = new AdultFamilyMember() { Name = "Филипп", Wife = new FamilyMember() { Name = "Людмила" }, Father = Pavel };// Отец


            //Дети деда 

            Pavel.Children = new FamilyMember[] { new FamilyMember() { Name = "Мария", Father = Pavel }, Max, Fill };
            Kiril.Children = new FamilyMember[] { Ksu };

            // Дети отца и дядь

            Fill.Children = new FamilyMember[] { new FamilyMember() { Name = "Я", Father = Fill }, new FamilyMember() { Name = "Андрей", Father = Fill }, new FamilyMember() { Name = "Денис", Father = Fill } };

            Max.Children = new FamilyMember[] { new FamilyMember() { Name = "Арина", Father = Max } };

            Ksu.Children = new FamilyMember[] { new FamilyMember() { Name = "Кристина", Father = Kiril } };

            // Вызов метода для печати на экране

            Margo.Info(2);


            Ksu.ShowGrandParent();

            Console.ReadLine();


        }


    }
}