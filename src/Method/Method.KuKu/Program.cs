using System;

namespace Method.KuKu
{
    public class Program
    {
        private static void Main()
        {
            PrintKuKu(9);
        }

        private static bool PrintKuKu(int end)
        {
            const int start = 1;

            if (end < start)
            {
                return false;
            }

            for (var i = start; i <= end; i++)
            {
                for (var j = start; j <= end; j++)
                {
                    Console.WriteLine($"{i,-2} * {j,-2} = {i * j}");
                }
            }
            return true;
        }
    }
}
