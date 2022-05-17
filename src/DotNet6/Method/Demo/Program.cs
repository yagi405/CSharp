class Program
{
    static void Main()
    {
        //var a = 10;
        //var b = 1;
        //Console.WriteLine(Calculate(a));
        //Console.WriteLine($"a = {a}, b = {b}");
        //Console.WriteLine(c); //コンパイルエラー

        Greet("saito", "Hello");
        Greet("saito");
        Greet("saito", "こんにちは");

        //Console.WriteLine("{0}{1}{2}{3}",1,2,3,4,5,6,7,8);
        ParamsSample("{0}", "abc", true, 2);
    }

    static void ParamsSample(string format, params object[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine(args[i]);
        }
    }

    static void Greet(string name, string message = "Hello")
    {
        Console.WriteLine($"{name}さん {message}!");
    }

    static int Calculate(int a)
    {
        var b = 100;
        var c = a - 1;
        a = a - 5;
        return a * b + c;
    }

}

