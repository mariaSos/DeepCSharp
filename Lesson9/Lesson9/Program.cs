using System.Text.Json;
using System.Xml;

namespace Lesson9
{
    class Program
    {
        static void Main()
        {
            string filePath = @"c:\xmlDir\";
            string jsonString =@"{
  ""Class Name"": ""Science"",
  ""Teacher\u0027s Name"": ""Jane"",
  ""Semester"": ""2019-01-01"",
  ""Students"": [
    {
      ""Name"": ""John"",
      ""Grade"": 94.3
    },
    {
      ""Name"": ""James"",
      ""Grade"": 81.0
    },
    {
      ""Name"": ""Julia"",
      ""Grade"": 91.9
    },
    {
      ""Name"": ""Jessica"",
      ""Grade"": 72.4
    },
    {
      ""Name"": ""Johnathan"",
        ""Grade"": 56.4
    }
  ]
 
}
";

            using (JsonDocument document = JsonDocument.Parse(jsonString))
            {
                JsonElement root = document.RootElement;
                JsonElement studentsElementJ = root.GetProperty("Students");

                //создание главного объекта документа
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement rootElement = xmlDoc.CreateElement("root");
                //Создаем элемент студенты
                XmlElement studentsElement = xmlDoc.CreateElement("Students");

                foreach (JsonElement student in studentsElementJ.EnumerateArray())

                {

                    //Получаем значение из полей JSON
                    var gradeJ = student.GetProperty("Grade").GetDecimal();
                    var nameJ = student.GetProperty("Name").GetString();

                    //Создаем XML-элементы
                    XmlElement studentElement = xmlDoc.CreateElement("Student");

                    XmlElement name = xmlDoc.CreateElement("Name");
                    name.InnerText = nameJ;
                    studentElement.AppendChild(name);

                    XmlElement grade = xmlDoc.CreateElement("Grade");
                    grade.InnerText = gradeJ.ToString();
                    studentElement.AppendChild(grade);

                    studentsElement.AppendChild(studentElement);
                }

                    rootElement.AppendChild(studentsElement);
                    xmlDoc.AppendChild(rootElement);
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                        xmlDoc.Save(filePath+"test.xml");
            }
           
        }

        
    }
}