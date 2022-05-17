namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "0";

            //var i = int.Parse(s);

            //int i;
            //int.TryParse(s, out i);

            var isValid = int.TryParse(s, out var i);

            if (isValid)
            {
                Console.WriteLine("変換に成功しました。");
                Console.WriteLine($"結果：{i}");
            }
            else
            {0
                Console.WriteLine("変換に失敗しました。");
                Console.WriteLine($"結果：{i}");
            }

            Console.WriteLine("----------------------------");

            var num = 1;

            //Sample(num);
            //OutSample(out num);
            RefSample(ref num);

            Console.WriteLine($"num：{num}");
        }

        static void Sample(int i)
        {
            i = 123456;
        }

        static void OutSample(out int i)
        {
            i = 123456;
        }

        static void RefSample(ref int i)
        {
            i = 123456;
        }
    }
}