using System;

namespace ControlStatements.DemoUsingFor
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("{0}は10以下です。", i);
            }

            //infinite
            //for (; ; )
            //{
            //    Console.WriteLine("infinite loop");
            //}

            //break continue
            int start = 3;
            int sum = 0;
            for (int i = start; i < start + 10; i++)
            {
                sum += i;
                if (sum >= 100)
                {
                    //break;
                    continue;
                }
                sum += i + i;
            }

            Console.WriteLine("sum = {0}", sum);
        }
    }
}
