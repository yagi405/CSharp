namespace KuKu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintKuKu(9);
            Console.WriteLine("---------------------");
            PrintKuKu(20);
            Console.WriteLine("---------------------");
            PrintKuKu(3);
        }

        static bool PrintKuKu(int end)
        {
            const int start = 1;

            if (end < start)
            {
                return false;
            }

            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    Console.WriteLine($"{i} * {j} = {i * j}");
                }
            }

            return true;
        }
    }
}