using System;

namespace ControlStatements.DemoUsingWhile
{
    class Program
    {
        static void Main(string[] args)
        {
            //while (true)
            //{
            //    Console.WriteLine("infinite loop");
            //}

            //while
            int i = 1;
            while (i <= 10)
            {
                Console.WriteLine(i);
                i++;
            }

            //do while
            int j = 100;
            do
            {
                Console.WriteLine(j);
                j++;
            } while (j <= 10);
        }
    }
}
