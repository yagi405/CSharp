using System;

namespace Method.Exercise
{
    public class Program
    {
        private static void Main()
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
            var leftSide = Console.ReadLine();
            Console.Write("左辺の数値を入力してください。=> ");
            var rightSide = Console.ReadLine();

            var a = double.Parse(leftSide);
            var b = double.Parse(rightSide);

            Console.WriteLine("{0} + {1} = {2}", a, b, Add(a, b));
            Console.WriteLine("{0} - {1} = {2}", a, b, Subtract(a, b));
            Console.WriteLine("{0} * {1} = {2}", a, b, Multiply(a, b));
            Console.WriteLine("{0} / {1} = {2}", a, b, Divide(a, b));
            Console.WriteLine("{0} % {1} = {2}", a, b, Mod(a, b));
        }

        private static int Add(int a, int b)
        {
            return a + b;
        }

        private static int Subtract(int a, int b)
        {
            return a - b;
        }

        private static int Multiply(int a, int b)
        {
            return a * b;
        }

        private static int Divide(int a, int b)
        {
            return a / b;
        }

        private static int Mod(int a, int b)
        {
            return a % b;
        }

        private static double Add(double a, double b)
        {
            return a + b;
        }

        private static double Subtract(double a, double b)
        {
            return a - b;
        }

        private static double Multiply(double a, double b)
        {
            return a * b;
        }

        private static double Divide(double a, double b)
        {
            return a / b;
        }

        private static double Mod(double a, double b)
        {
            return a % b;
        }
    }
}
