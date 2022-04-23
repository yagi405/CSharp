using System;

namespace KuKu
{
    class Program
    {
        static void Main(string[] args)
        {
            //Simple();
            //KuKuAdvance();
            //KuKuReverse();
            //KuKuFormat();
            KuKuUsingFor();
        }

        static void KuKuSimple()
        {
            int i = 1;
            while (i <= 9)
            {
                int j = 1;
                while (j <= 9)
                {
                    Console.WriteLine("{0} * {1} = {2}", i, j, i * j);
                    j++;
                }
                i++;
            }
        }

        static void KuKuAdvance()
        {
            int i = 1;
            int max = 20;

            while (i <= max)
            {
                int j = 1;
                while (j <= max)
                {
                    Console.WriteLine("{0} * {1} = {2}", i, j, i * j);
                    j++;
                }
                i++;
            }
        }

        static void KuKuReverse()
        {
            int max = 20;
            int i = max;

            while (1 <= i)
            {
                int j = max;
                while (1 <= j)
                {
                    Console.WriteLine("{0} * {1} = {2}", i, j, i * j);
                    j--;
                }
                i--;
            }
        }

        static void KuKuFormat()
        {
            int max = 20;
            int i = max;

            while (1 <= i)
            {
                int j = max;
                while (1 <= j)
                {
                    Console.WriteLine("{0,2} * {1,2} = {2}", i, j, i * j);
                    j--;
                }
                i--;
            }
        }

        static void KuKuUsingFor()
        {
            for (int i = 20; 1 <= i; i--)
            {
                for (int j = 20; 1 <= j; j--)
                {
                    Console.WriteLine("{0,2} * {1,2} = {2}", i, j, i * j);
                }
            }
        }
    }
}
