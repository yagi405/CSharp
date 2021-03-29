using System;

namespace Array.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[10];
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;

            Console.WriteLine($"array[0] => {array[0]}");
            Console.WriteLine($"array[1] => {array[1]}");
            Console.WriteLine($"array[2] => {array[2]}");

            var array2 = new int[3] { 1, 2, 3 };
            Console.WriteLine($"array2[0] => {array2[0]}");
            Console.WriteLine($"array2[1] => {array2[1]}");
            Console.WriteLine($"array2[2] => {array2[2]}");

            //int[] array3 = {1, 2, 3};
            //var array3 = new[] {1, 2, 3};

            var array4 = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine($"array4.Length => {array4.Length}");

            //error
            //for (int i = 1; i <= 10; i++)
            //{
            //    Console.WriteLine(array4[i]);
            //}

            var s = "abc";
            Console.WriteLine($"s[0] => {s[0]}");
        }
    }
}
