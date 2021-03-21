using System;

namespace FizzBuzzUsingIf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("整数を入力してください。=> ");
            string input = Console.ReadLine();

            int i = int.Parse(input);
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("!?");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("!");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("?");
            }
            else
            {
                Console.WriteLine(i);
            }

            i++;
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("!?");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("!");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("?");
            }
            else
            {
                Console.WriteLine(i);
            }

            i++;
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("!?");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("!");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("?");
            }
            else
            {
                Console.WriteLine(i);
            }

            i++;
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("!?");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("!");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("?");
            }
            else
            {
                Console.WriteLine(i);
            }

            i++;
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("!?");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("!");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("?");
            }
            else
            {
                Console.WriteLine(i);
            }

            i++;
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("!?");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("!");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("?");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }
}
