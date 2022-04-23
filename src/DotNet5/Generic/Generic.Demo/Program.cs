using System;

namespace Generic.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericSample();
            GenericMethodSample();
            NullableSample();
        }

        static void NullableSample()
        {
            int? i = 10;
            //Nullable<int> i = 10;
            //var j = i;

            if (i.HasValue)
            {
                var value = i.Value;
                Console.WriteLine($"value => {value}");
            }
            else
            {
                //error
                //var value = i.Value;
            }

            Console.WriteLine($"GetValueOrDefault => {i.GetValueOrDefault()}");
        }

        static void GenericMethodSample()
        {
            Console.WriteLine(GetMax(100, 200));
            Console.WriteLine(GetMax(10.125, 10.345));
            Console.WriteLine(GetMax("abc", "def"));

            //error
            //var array1 = new VariableLengthArray<int>();
            //var array2 = new VariableLengthArray<int>();
            //GetMax<VariableLengthArray<int>>(array1, array2);
        }

        private static T GetMax<T>(T x, T y) where T : IComparable<T>
        {
            if (x.CompareTo(y) > 0)
            {
                return x;
            }
            return y;
        }

        private static void GenericSample()
        {
            var array1 = new VariableLengthArray<int>();
            array1.Add(1);
            array1.Add(2);
            array1.Add(3);

            PrintVariableLengthArray(array1);

            var array2 = new VariableLengthArray<string>();
            array2.Add("foo");
            array2.Add("bar");
            array2.Add("baz");

            PrintVariableLengthArray(array2);
        }

        private static void PrintVariableLengthArray<T>(VariableLengthArray<T> array)
        {
            Console.WriteLine($"Count => {array.Count}");
            for (var i = 0; i < array.Count; i++)
            {
                Console.WriteLine($"array[{i}] => {array[i]}");
            }
            Console.WriteLine();
        }
    }
}
