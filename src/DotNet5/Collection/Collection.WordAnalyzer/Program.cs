using System;
using System.Collections.Generic;

namespace Collection.WordAnalyzer
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("英文を入力してください。（複数行可）");
            Console.WriteLine("**End と入力すると、解析を実行します。");

            var texts = new List<string>();

            string text;
            while ((text = Console.ReadLine()) != "**End")
            {
                texts.Add(text);
            }

            Analyze(texts);
        }

        private static void Analyze(List<string> texts)
        {
            if (texts == null)
            {
                return;
            }

            var dictionary = new Dictionary<string, int>();

            var maxLength = 0;
            foreach (var text in texts)
            {
                var words = text
                    .Replace("\r\n", " ")
                    .Replace("\r", " ")
                    .Replace("\n", " ")
                    .Replace("\t", " ")
                    .Replace("’", "'")
                    .Split(
                        new[] { '.', ' ', '　', ',', ';', ':', '(', ')', '[', ']', '!', '?' }
                        //,StringSplitOptions.RemoveEmptyEntries
                    );

                foreach (var word in words)
                {
                    var normalized = word.ToLower().Trim();
                    if (normalized == "")
                    {
                        continue;
                    }

                    if (dictionary.TryGetValue(normalized, out var count))
                    {
                        dictionary[normalized] = ++count;
                        continue;
                    }

                    dictionary.Add(normalized, 1);
                    if (maxLength < normalized.Length)
                    {
                        maxLength = normalized.Length;
                    }
                }
            }

            var results = new List<KeyValuePair<string, int>>();
            results.AddRange(dictionary);

            //並び替え
            Sort(results);

            var width = 2;
            var line = "--";
            for (int i = 0; i < maxLength; i++)
            {
                width++;
                line += "-";
            }

            var format = $"{{0,{-width}}}|{{1}}";

            Console.WriteLine();
            Console.WriteLine(format, "Word", "Value");
            Console.WriteLine($"{line}+--------");
            foreach (var result in results)
            {
                Console.WriteLine(format, result.Key, result.Value);
            }
        }

        private static void Sort(List<KeyValuePair<string, int>> list)
        {
            if (list == null)
            {
                return;
            }

            for (int i = 0; i < list.Count - 1; i++)
            {
                var swapped = false;
                for (int j = 1; j < list.Count - i; j++)
                {
                    var x = list[j - 1];
                    var y = list[j];

                    if (
                        x.Value < y.Value ||
                        x.Value == y.Value && x.Key.CompareTo(y.Key) > 0
                        )
                    {
                        var temp = list[j - 1];
                        list[j - 1] = list[j];
                        list[j] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
        }
    }
}
