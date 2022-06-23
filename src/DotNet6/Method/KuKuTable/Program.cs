namespace KuKuTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintKuKuTable(3);
            Console.WriteLine("-------------------");
            PrintKuKuTable(9);
            Console.WriteLine("-------------------");
            PrintKuKuTable(10);
        }

        static bool PrintKuKuTable(int end)
        {
            const int start = 1;

            if (end < start)
            {
                return false;
            }

            var digit = 1;
            for (var max = end * end; max > 0; max /= 10)
            {
                digit++;
            }

            //var format = "{0," + digit + "}";
            var format = $"{{0,{digit}}}";

            //var header = string.Format($"{0,digit}", "");
            var header = string.Format(format, "");

            for (int i = start; i <= end; i++)
            {
                header += string.Format(format, i);
            }
            Console.WriteLine(header);

            for (int i = start; i <= end; i++)
            {
                var line = string.Format(format, i);
                for (int j = start; j <= end; j++)
                {
                    line += string.Format(format, i * j);
                }
                Console.WriteLine(line);
            }

            return true;
        }
    }
}