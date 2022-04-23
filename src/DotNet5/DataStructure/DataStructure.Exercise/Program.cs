using System;
using System.Collections.Generic;

namespace DataStructure.Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new VariableLengthArray();

            PrintVariableLengthArray(array);

            //Console.WriteLine(array[0]); //error

            array.Add(1);
            array.Add(2);
            array.Add(3);

            //1 2 3
            PrintVariableLengthArray(array);
            
            array.AddRange(new[] { 4, 5, 6 });
            
            //1 2 3 4 5 6
            PrintVariableLengthArray(array);

            array.RemoveLast();

            //1 2 3 4 5
            PrintVariableLengthArray(array);

            array.RemoveAt(2);

            //1 2 4 5
            PrintVariableLengthArray(array);

            array.Insert(2, 30);
            array.Insert(0, 0);

            //0 1 2 30 4 5
            PrintVariableLengthArray(array);

            var array2 = new VariableLengthArray(0);
            array2.Add(0);
            array2.Add(1);
            array2.Add(2);
            //0 1 2
            PrintVariableLengthArray(array2);

            array2.Clear();
            PrintVariableLengthArray(array2);

        }

        private static void PrintVariableLengthArray(VariableLengthArray array)
        {
            Console.WriteLine($"Count => {array.Count}");
            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine($"array[{i}] => {array[i]}");
            }
            Console.WriteLine();
        }
    }
}
