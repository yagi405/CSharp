using System;

namespace ExtensionMethods.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "123";
            var i = s.ParseInt();
            Console.WriteLine(i * 2);

            var now = DateTime.Now;
            Console.WriteLine(now.BeginOfMonth());
            Console.WriteLine(DateTimeExtensions.BeginOfMonth(now));
        }
    }
}
