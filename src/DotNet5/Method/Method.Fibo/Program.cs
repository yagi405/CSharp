using System;

namespace Method.Fibo
{
    public class Program
    {
        private static void Main()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.Write(FiboLoop(i));
                Console.Write(",");
            }

            Console.WriteLine();

            for (var i = 0; i < 10; i++)
            {
                Console.Write(FiboRecursive(i));
                Console.Write(",");
            }
        }

        private static int FiboLoop(int n)
        {
            //0 1 1 2 3 5 8 13
            var values = new int[n + 1];
            values[0] = 0;

            if (n < 1)
            {
                return values[n];
            }

            values[1] = 1;
            for (var i = 2; i < values.Length; i++)
            {
                values[i] = values[i - 2] + values[i - 1];
            }

            return values[n];
        }

        private static int FiboRecursive(int n)
        {
            if (n < 2)
            {
                return n;
            }
            return FiboRecursive(n - 2) + FiboRecursive(n - 1);
        }
    }
}