using System;

namespace CopyObject.Demo
{
    public class Program
    {
        private static void Main()
        {
            var src = new[] {1, 2, 3};
            var dest = new int[src.Length];

            for (var i = 0; i < src.Length; i++)
            {
                dest[i] = src[i];
            }

            src[0] = 0;
            for (var i = 0; i < dest.Length; i++)
            {
                Console.WriteLine($"dest[{i}] => {dest[i]}");
            }
        }
    }
}
