using System;
using System.Collections.Generic;

namespace Delegate.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //DelegateSample();
            //SortSample();
            //FilterListSample();
            //SortSampleUsingLambda();
            //FilterListSampleUsingLambda();
            ClosureSample();
        }

        private static void ClosureSample()
        {
            var i = 0;
            //Func<int> counter = () => { return ++i; };
            Func<int> counter = () => ++i;

            Console.WriteLine(counter());
            Console.WriteLine(counter());
            Console.WriteLine(i);
        }

        private static void FilterListSampleUsingLambda()
        {
            var src = new[] { 10, 5, 9, 6, 7, 3, 4, 2, 7, 4, 6 };

            //var result = FilterList(src, i => i % 2 == 0);
            var result = FilterList(src, i => 5 < i);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void SortSampleUsingLambda()
        {
            var list = new List<int>() { 9, 5, 7, 1, 3, 6, 4, 2, 8 };

            list.Sort((x, y) => y - x);
            //list.Sort((int x, int y) => { return y - x; });

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static void FilterListSample()
        {
            var src = new[] { 10, 5, 9, 6, 7, 3, 4, 2, 7, 4, 6 };

            var result = FilterList(src, IsEven);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static bool IsEven(int i)
        {
            return i % 2 == 0;
        }

        private static bool IsGreaterThanFive(int i)
        {
            return 5 < i;
        }

        private static IList<int> FilterList(IList<int> src, Func<int, bool> fn)
        {
            var result = new List<int>();
            foreach (var item in src)
            {
                //if (item > 5)
                if (fn(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private static void SortSample()
        {
            var list = new List<int>() { 9, 5, 7, 1, 3, 6, 4, 2, 8 };

            //var descSorter = new DescSorter();
            list.Sort(Compare);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static int Compare(int x, int y)
        {
            return y - x;
        }

        private class DescSorter : IComparer<int>
        {
            //負の値： xは、並び替え順序において、yの前
            //0     ： xは、並び替え順序において、yと同じ位置
            //正の値： xは、並び替え順序において、yの後

            public int Compare(int x, int y)
            {
                return y - x;
            }
        }


        private static void DelegateSample()
        {
            Action<string> a = Console.WriteLine;

            a("Hello");
            //a.Invoke("Hello");

            var list = new List<int>();
            Action<int> adder = list.Add;

            adder(1);
            adder(2);
            adder(3);

            a(list.Count.ToString());

            var list2 = list;

            adder(4);
            adder(5);
            adder(6);

            a(list.Count.ToString());

            list = new List<int>();

            a(list.Count.ToString());
            a(list2.Count.ToString());

            adder(7);
            adder(8);
            adder(9);

            a(list2.Count.ToString());

            adder = null;

            Func<int, int> fn = Math.Abs;

            Console.WriteLine(fn(-100));
        }
    }
}
