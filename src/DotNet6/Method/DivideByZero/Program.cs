namespace DivideByZero
{
    internal class Program
    {
        static int Add(int a, int b)
        {
            return a + b;
        }

        static int Subtract(int a, int b)
        {
            return a - b;
        }

        static int Multiply(int a, int b)
        {
            return a * b;
        }

        static int Divide(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("0で割ることはできません。");
                return 0;
            }
            return a / b;
        }

        static int Mod(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("0で割ることはできません。");
                return 0;
            }
            return a % b;
        }

        static void Main(string[] args)
        {
            Console.Write("左辺の整数を入力してください > ");
            var leftSide = Console.ReadLine();
            Console.Write("右辺の整数を入力してください > ");
            var rightSide = Console.ReadLine();

            var a = int.Parse(leftSide);
            var b = int.Parse(rightSide);

            Console.WriteLine($"{a} + {b} = {Add(a, b)}");
            Console.WriteLine($"{a} - {b} = {Subtract(a, b)}");
            Console.WriteLine($"{a} * {b} = {Multiply(a, b)}");
            Console.WriteLine($"{a} / {b} = {Divide(a, b)}");
            Console.WriteLine($"{a} % {b} = {Mod(a, b)}");
        }
    }
}