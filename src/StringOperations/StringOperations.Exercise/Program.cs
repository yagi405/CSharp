using System;

namespace StringOperations.Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "")
            {
                Console.WriteLine("長さ => {0}", input.Length);
                Console.WriteLine("すべて大文字 => {0}", input.ToUpper());
                Console.WriteLine("すべて小文字 => {0}", input.ToLower());

                var rev = "";
                for (var i = input.Length - 1; i >= 0; i--)
                {
                    var s = input.Substring(i, 1);
                    rev += s;
                }
                Console.WriteLine("逆順 => {0}", rev);

                var inv = "";
                for (var i = input.Length - 1; i >= 0; i--)
                {
                    var s = input.Substring(i, 1);

                    var upper = s.ToUpper();
                    if (s == upper)
                    {
                        inv += s.ToLower();
                    }
                    else
                    {
                        inv += s.ToUpper();
                    }
                }
                Console.WriteLine("逆順+反転 => {0}",inv);
                Console.WriteLine();
            }
        }
    }
}
