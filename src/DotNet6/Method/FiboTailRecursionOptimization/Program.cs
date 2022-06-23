namespace FiboTailRecursionOptimization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 4000; i++)
            {
                Console.WriteLine(FiboTailRecursionOptimization(i));
            }
        }

        static int FiboTailRecursionOptimization(int n)
        {
            return FiboTailRecursionOptimization(n, 0, 1);
        }

        static int FiboTailRecursionOptimization(int n, int prev2, int prev1)
        {
            if (n == 0)
            {
                return prev2;
            }

            if (n == 1)
            {
                return prev1;
            }

            return FiboTailRecursionOptimization(n - 1, prev1, prev1 + prev2);
        }
    }
}