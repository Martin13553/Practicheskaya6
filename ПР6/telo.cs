using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace ПР6
{
    internal class telo
    {
        public static void TUT()
        {
            Convert();
        }
       
         public static void Convert ()
        {
            figure kvadrat = new figure();
            kvadrat.name = "Квадрат";
            kvadrat.length = 15;
            kvadrat.width = 15;

            figure kvadratt= new figure();
            kvadratt.name = "Квадрат - 2";
            kvadratt.length = 5;
            kvadratt.width = 5;

            figure pramougol = new figure();
            pramougol.name = "Рауль";
            pramougol.length = 16;
            pramougol.width = 10;

            List<figure> Humans = new List<figure>();
            Humans.Add(kvadrat);
            Humans.Add(kvadratt);
            Humans.Add(pramougol);


            Console.WriteLine("Введите путь к файлу, который хотите открыть");
            string a = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Сохранить в одном из форматов (.txt, .json, .xml) " +
                              "\n-------------------------------------------------------------------------------");
            string choice = Console.ReadLine();


            if (choice.Contains(".txt"))
            {
                string[] text = File.ReadAllLines(a);
                foreach (string item in text)
                {
                    Console.WriteLine(item);
                }
            }
            else if (choice.Contains(".json"))
            {
                JsonTextReader reader = new JsonTextReader(new StringReader(a));
                reader.SupportMultipleContent = true;
                while (true)
                {
                    if (!reader.Read()) break;

                    JsonSerializer serializer = new JsonSerializer();
                    List<figure> model = serializer.Deserialize<List<figure>>(reader);
                }

                string json = File.ReadAllText(a);
                List<figure> result = JsonConvert.DeserializeObject<List<figure>>(json);
                foreach (var item in result)
                {
                    Console.WriteLine(item.name);
                    Console.WriteLine(item.length);
                    Console.WriteLine(item.width);
                }
            }
            else if (choice.Contains(".xml"))
            {
                figure Y;
                XmlSerializer xml = new XmlSerializer(typeof(List<figure>));
                using (FileStream fs = new FileStream(a, FileMode.Open))
                {
                    Y = (figure)xml.Deserialize(fs);
                }

            }
        }
    }
}

