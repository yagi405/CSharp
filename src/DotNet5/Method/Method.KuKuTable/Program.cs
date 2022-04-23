using System;

namespace Method.KuKuTable
{
    public class Program
    {
        private static void Main()
        {
            PrintKuKuTable(3);
            Console.WriteLine();
            PrintKuKuTable(9);
            Console.WriteLine();
            PrintKuKuTable(20);
            Console.WriteLine();
            PrintKuKuTableWith2DArray(3);
            Console.WriteLine();
            PrintKuKuTableWith2DArray(9);
            Console.WriteLine();
            PrintKuKuTableWith2DArray(20);
        }

        private static bool PrintKuKuTable(int end)
        {
            const int start = 1;

            if (end < start)
            {
                return false;
            }

            var digit = 1;
            //for (var max = end * end; 0 < max; digit++)
            //{
            //    max /= 10;
            //}

            for (var max = end * end; 0 < max; max /= 10)
            {
                digit++;
            }

            var format = $"{{0,{digit}}}";

            Console.Write(format, "");
            for (var i = start; i <= end; i++)
            {
                Console.Write(format, i);
            }

            Console.WriteLine();

            for (var i = start; i <= end; i++)
            {
                Console.Write(format, i);
                for (var j = start; j <= end; j++)
                {
                    Console.Write(format, i * j);
                }
                Console.WriteLine();
            }

            return true;
        }

        private static bool PrintKuKuTableWith2DArray(int end)
        {
            const int start = 1;

            if (end < start)
            {
                return false;
            }

            var table = new int[end + 1, end + 1];

            table[0, 0] = 0;

            for (var i = start; i <= end; i++)
            {
                table[0, i] = i;
            }

            for (var i = start; i <= end; i++)
            {
                table[i, 0] = i;
                for (var j = start; j <= end; j++)
                {
                    table[i, j] = i * j;
                }
            }

            var digit = 1;
            for (var max = end * end; 0 < max; max /= 10)
            {
                digit++;
            }

            var format = $"{{0,{digit}}}";

            for (var i = 0; i < table.GetLength(0); i++)
            {
                for (var j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j] == 0)
                    {
                        Console.Write(format, "");
                        continue;
                    }
                    Console.Write(format, table[i, j]);
                }
                Console.WriteLine();
            }
            return true;
        }
    }
}