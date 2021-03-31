using System;

namespace Method.Demo
{
    public class Program
    {
        private static void Main()
        {
            Greet("さいとう", "こんばんは");
            Greet("さいとう");
            Greet();

            Console.WriteLine("{0} {1} {2} {3} {4} {5}", 0, 1, 2, 3, 4, 5, 1, 1, 1, 1, 1, 1, 1, 1);
            ParamsSample(10, "a", true);
            ParamsSample();
        }

        //private static void Greet(string name = "名無し", string message) // error
        private static void Greet(string name = "名無し", string message = "こんにちは")
        {
            Console.WriteLine($"{name} さん {message}");
        }

        private static void ParamsSample(params object[] args)
        {
            foreach (var t in args)
            {
                Console.WriteLine(t);
            }
        }
    }
}
