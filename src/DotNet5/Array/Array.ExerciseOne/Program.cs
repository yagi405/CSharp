using System;

namespace Array.ExerciseOne
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

            for (var i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"array[{i}] => {array[i]}");
            }
        }
    }
}
