using System;

namespace Algorithm.BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValid;
            int[] values;
            do
            {
                Console.WriteLine("半角スペース区切りで整数を入力してください。 => ");
                var s = Console.ReadLine();

                var inputs = s.Split(new[] { ' ' });

                values = new int[inputs.Length];

                isValid = true;

                for (var i = 0; i < inputs.Length; i++)
                {
                    isValid &= int.TryParse(inputs[i], out values[i]);
                }

            } while (!isValid || values.Length == 0);

            BubbleSort(values, true);

            var line = "";
            for (var i = 0; i < values.Length; i++)
            {
                line += $"{values[i]} ";
            }
            Console.WriteLine(line);

        }

        static void BubbleSort(int[] values, bool desc = false)
        {
            if (values == null)
            {
                return;
            }

            for (var i = 0; i < values.Length - 1; i++)
            {
                var swapped = false;

                for (var j = 1; j < values.Length - i; j++)
                {
                    if (values[j] != values[j - 1] && 
                        values[j] < values[j - 1] ^ desc)
                    {
                        Swap(ref values[j], ref values[j - 1]);
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    return;
                }
            }
        }

        static void Swap(ref int x, ref int y)
        {
            var temp = x;
            x = y;
            y = temp;
        }
    }
}
