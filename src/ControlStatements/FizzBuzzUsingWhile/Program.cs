﻿using System;

namespace FizzBuzzUsingWhile
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            while (i <= 100)
            {
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
            }
        }
    }
}
