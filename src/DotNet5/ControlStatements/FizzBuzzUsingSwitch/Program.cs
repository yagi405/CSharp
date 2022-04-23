using System;

namespace FizzBuzzUsingSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                switch (i % 15)
                {
                    case 0:
                        Console.WriteLine("!?");
                        break;
                    case 3:
                    case 6:
                    case 9:
                    case 12:
                        Console.WriteLine("!");
                        break;
                    case 5:
                    case 10:
                        Console.WriteLine("?");
                        break;
                    default:
                        Console.WriteLine(i);
                        break;
                }

            }
        }
    }
}
