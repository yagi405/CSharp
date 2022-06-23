namespace Fibo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Fibo(i));
            }
            Console.WriteLine("------------------");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(FiboArray(i));
            }
            Console.WriteLine("------------------");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(FiboRecursive(i));
            }
        }

        static int Fibo(int n)
        {
            if (n < 2)
            {
                return n;
            }

            var prev2 = 0;
            var prev1 = 1;

            for (int i = 2; i <= n; i++)
            {
                var current = prev1 + prev2;
                prev2 = prev1;
                prev1 = current;
            }

            return prev1;
        }

        static int FiboArray(int n)
        {
            if (n < 2)
            {
                return n;
            }

            var seq = new int[n + 1];
            seq[0] = 0;
            seq[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                seq[i] = seq[i - 1] + seq[i - 2];
            }

            return seq[n];
        }

        static int FiboRecursive(int n)
        {
            if (n < 2)
            {
                return n;
            }

            return FiboRecursive(n - 2) + FiboRecursive(n - 1);
        }
    }
}