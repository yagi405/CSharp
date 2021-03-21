using System;

namespace VariableOperator.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 10;
            short s = 200;
            double d = 0.001;

            //暗黙の型変換
            double result = d + i / s;
            Console.WriteLine(result);

            //明示的型変換
            //s = i;
            s = (short)i;

            int a = 100;
            int b = 5;
            Console.WriteLine("result: {0}", a + b);

            //ビットシフト
            int c = 6;
            Console.WriteLine(c >> 1);
            Console.WriteLine(c << 1);

            //ビット演算
            bool x = false;
            bool y = true;
            Console.WriteLine(x ^ y);
        }
    }
}
