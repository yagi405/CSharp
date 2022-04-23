using System;

namespace ControlStatements.DemoUsingGoto
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 0; i < 100; i++)
            {
                for (int j = i; j < 100; j++)
                {
                    sum += i * j;
                    if (10000 <= sum)
                    {
                        goto loop_end;
                    }
                }
            }
            loop_end:
            Console.WriteLine(sum);
        }
    }
}
