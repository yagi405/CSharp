using System;

namespace Array.ExerciseThree
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[100];
            for (var i = 1; i <= 100; i++)
            {
                array[i - 1] = i * i;
            }

            while (true)
            {
                Console.Write("開始する添え字を指定 => ");
                var start = int.Parse(Console.ReadLine());

                Console.Write("startから合計を行う要素の数を指定 => ");
                var count = int.Parse(Console.ReadLine());

                if (start < 0 || 100 <= start)
                {
                    Console.WriteLine("startが不正です。");
                }
                else if (count < 0)
                {
                    Console.WriteLine("countが不正です。");
                }
                else
                {
                    var total = 0;
                    for (var i = start; i < start + count; i++)
                    {
                        total += array[i % 100];
                    }
                    Console.WriteLine($"total => {total}");
                }
            }
        }
    }
}
