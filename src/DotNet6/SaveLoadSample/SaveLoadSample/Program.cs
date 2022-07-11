using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace SaveLoadSample
{
    internal class Program
    {
        static void Main()
        {
            var items = new List<SampleItem>{
                new(){ Name ="やくそう", },
                new(){ Name ="こんぼう", },
            };

            var p1 = new SamplePlayer()
            {
                Name = "Tom",
                Level = 10,
                Items = items,
                IgnoredMember = "Ignored"
            };

            Console.WriteLine(p1);

            var saveFilePath = @"sample.json";

            //セーブ
            Save(p1, saveFilePath);

            //ロード
            var p2 = Load<SamplePlayer>(saveFilePath);

            Console.WriteLine(p2);
        }

        public static void Save<T>(T player, string filePath)
        {
            //TODO:validate parameter
            //TODO:try catch

            var jsonString = JsonSerializer.Serialize(player, GetSerializerOptions());
            File.WriteAllText(filePath, jsonString);
        }

        public static T? Load<T>(string filePath)
        {
            //TODO:validate parameter
            //TODO:try catch

            var jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(jsonString, GetSerializerOptions());
        }

        private static JsonSerializerOptions GetSerializerOptions()
        {
            return new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            };
        }
    }
}