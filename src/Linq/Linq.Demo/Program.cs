using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq.Demo
{
    class Program
    {
        private static void Main(string[] args)
        {
            //LinqSample();
            //DelayedEvaluationSample();
            //SelectManySample();
            //OrderBySample();
            ToListToArraySample();
        }

        private static void ToDictionarySample()
        {

        }

        private static void ToListToArraySample()
        {
            var values = new[]
            {
                new{ No = 2,Name = "tashiba",Age = 38 },
                new{ No = 1,Name = "kinoshita",Age = 23 },
                new{ No = 4,Name = "hamaguchi",Age = 16 },
                new{ No = 5,Name = "ota",Age = 38 },
                new{ No = 3,Name = "nakano",Age = 28 },
            };

            var seq = values
                .Where(x => 25 <= x.Age)
                //.ToList();
                .ToArray();

            foreach (var x in seq)
            {
                Console.WriteLine(x);
            }
        }

        private static void OrderBySample()
        {
            var values = new[]
            {
                new{ No = 2,Name = "tashiba",Age = 38 },
                new{ No = 1,Name = "kinoshita",Age = 23 },
                new{ No = 4,Name = "hamaguchi",Age = 16 },
                new{ No = 5,Name = "ota",Age = 38 },
                new{ No = 3,Name = "nakano",Age = 28 },
            };

            var seq = values
                .OrderBy(x => x.Age)
                .ThenBy(x => x.No);

            foreach (var x in seq)
            {
                Console.WriteLine(x);
            }
        }

        private static void SelectManySample()
        {
            var values = new[]
            {
                new[]{"ab","cd","ef" },
                new[]{"gh","if" },
                new[]{"zz","xx","yy","kk" },
            };

            var seq = values.SelectMany(x => x);
            foreach (var x in seq)
            {
                Console.WriteLine(x);
            }
        }

        private static void DelayedEvaluationSample()
        {
            var values = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var seq = values
                .Where(x => x % 2 == 0)
                .Select(x =>
                {
                    Console.WriteLine("select");
                    return x * 2;
                });
            //.ToList();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("===============");
                foreach (var x in seq)
                {
                    Console.WriteLine(x);
                }
                Console.WriteLine("===============");
            }

            values.Add(10);

            foreach (var x in seq)
            {
                Console.WriteLine(x);
            }
        }

        private static void LinqSample()
        {
            var values = new[] { 10, 3, 4, -4, 5, 15, 6, 0 };

            var seq = values
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .Select(x => x * 2);

            foreach (var x in seq)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("=============");

            var list = new List<int>();
            foreach (var v in values)
            {
                if (v % 2 == 0)
                {
                    list.Add(v);
                }
            }

            list.Sort();

            var result = new List<int>();
            foreach (var v in list)
            {
                result.Add(v * 2);
            }

            foreach (var v in result)
            {
                Console.WriteLine(v);
            }
        }
    }
}
