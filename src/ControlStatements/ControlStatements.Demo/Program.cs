using System;

namespace ControlStatements.DemoUsingIf
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 20;
            if (num < 10)
            {
                Console.WriteLine("{0}は10より小さいです。", num);
            }
            else
            {
                Console.WriteLine("{0}は10以上です。", num);
            }
        }
    }
}
