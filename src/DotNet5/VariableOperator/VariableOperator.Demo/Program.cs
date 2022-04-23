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

            decimal d1 = 0.1m;
            decimal d2 = 0.2m;
            Console.WriteLine(d1 + d2 == 0.3m);

            double f1 = 0.1;
            double f2 = 0.2;
            Console.WriteLine(f1 + f2 == 0.3);


            //ビットシフト
            byte c = 0b_0000_0110;
            Console.WriteLine(c);
            //byte c = 0b_0000_1100;
            Console.WriteLine(c << 1);
            //byte c = 0b_0000_0011;
            Console.WriteLine(c >> 1);

            //int c = 6;
            //Console.WriteLine(c >> 1);
            //Console.WriteLine(c << 1);

            //ビット演算
            bool x = false;
            bool y = true;
            Console.WriteLine(x ^ y);
        }
    }
}
