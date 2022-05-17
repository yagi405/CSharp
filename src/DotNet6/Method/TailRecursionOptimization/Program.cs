namespace TailRecursionOptimization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Sum(30000));
            Console.WriteLine(Sum(100));
            Console.WriteLine("--------------------");
            Console.WriteLine(SumUsingTailRecursion(100, 0));
            Console.WriteLine("--------------------");
            Console.WriteLine(SumUsingLoop(100, 0));
            //Console.WriteLine(SumUsingTailRecursion(5, 0));
            //Console.WriteLine(SumUsingTailRecursion(30000, 0));
        }

        static int Sum(int n)
        {
            if (n < 1)
            {
                return n;
            }

            return n + Sum(n - 1);
        }

        static int SumUsingTailRecursion(int n, int accumulator)
        {
            if (n == 0)
            {
                return accumulator;
            }

            return SumUsingTailRecursion(n - 1, accumulator + n);
        }

        static int SumUsingLoop(int n, int accumulator)
        {
            while (true)
            {
                if (n == 0)
                {
                    return accumulator;
                }

                accumulator = accumulator + n;
                n = n - 1;
            }
        }
    }
}