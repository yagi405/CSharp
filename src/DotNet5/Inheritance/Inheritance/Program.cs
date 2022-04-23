using System;
using System.Collections.Generic;

namespace Inheritance
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var a = new Point2D(10, 20);
            var b = new Point2D(10, 20);
            var c = new Point2D(20, 10);

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);

            //if (a == b)
            if (a.Equals(b))
            {
                Console.WriteLine("aとbは同じ座標です。");
            }
            else
            {
                Console.WriteLine("aとbは同じ座標ではありません。");
            }

            Console.WriteLine($"a.GetHashCode() => {a.GetHashCode()}");
            Console.WriteLine($"b.GetHashCode() => {b.GetHashCode()}");

            var hashSet = new HashSet<Point2D>()
            {
                new(10, 10),
                new(10, 20),
                new(20, 20),
                new(30, 30),
                new(40, 40),
                new(50, 50),
                new(60, 60),
            };

            Console.WriteLine($"hashSet.Contains(a) => {hashSet.Contains(a)}");

            var d = new Point3D(10, 20, 30);

            Console.WriteLine($"a.Equals(d) => {a.Equals(d)}");
        }
    }
}
