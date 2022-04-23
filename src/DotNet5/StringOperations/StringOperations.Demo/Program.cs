using System;

namespace StringOperations.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Format();
            //Escape();
            //HereDocument();
            StringInterpolation();
        }

        private static void Format()
        {
            var input = Console.ReadLine();

            //Console.WriteLine("Hello {0}!",input);
            var result = string.Format("Hello {0}!", input);
            Console.WriteLine(result);
        }

        private static void Escape()
        {
            var s1 = "1行目\r\n2行目\r\n3行目";
            Console.WriteLine(s1);

            var s2 = "\\";
            Console.WriteLine(s2);

            var s3 = "改行文字 => \\r\\n";
            Console.WriteLine(s3);
        }

        private static void HereDocument()
        {
            var s = @"1行目
2行目
3行目
                    4行目
";
            Console.WriteLine(s);
        }

        private static void StringInterpolation()
        {
            var s = "aBc";

            //Console.WriteLine("長さ => {0}",s.Length);
            Console.WriteLine($"長さ => {s.Length}");

            var upper = $"全て大文字 => {s.ToUpper()}";
            Console.WriteLine(upper);
        }
    }
}
