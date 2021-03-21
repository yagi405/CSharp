using System;

namespace VariableOperator.Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.Write("左辺の整数を入力してください。=> ");
            string leftSide = Console.ReadLine();
            Console.Write("左辺の整数を入力してください。=> ");
            string rightSide = Console.ReadLine();

            int a = int.Parse(leftSide);
            int b = int.Parse(rightSide);
            */

            Console.Write("左辺の数値を入力してください。=> ");
            string leftSide = Console.ReadLine();
            Console.Write("左辺の数値を入力してください。=> ");
            string rightSide = Console.ReadLine();

            double a = double.Parse(leftSide);
            double b = double.Parse(rightSide);

            Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
            Console.WriteLine("{0} - {1} = {2}", a, b, a - b);
            Console.WriteLine("{0} * {1} = {2}", a, b, a * b);
            Console.WriteLine("{0} / {1} = {2}", a, b, a / b);
            Console.WriteLine("{0} % {1} = {2}", a, b, a % b);
        }
    }
}