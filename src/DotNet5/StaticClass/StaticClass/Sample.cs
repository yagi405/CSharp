using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass
{
    public class Sample
    {
        public const string ConstField = "const value";

        private string _field;

        private static string _staticField;

        public string Property { get; set; }

        public static string StaticProperty { get; set; }

        public Sample()
        {
            _field = "value";
            Console.WriteLine("Constructor");
        }

        static Sample()
        {
            _staticField = "static value";
            Console.WriteLine("StaticConstructor");
        }

        public void Method()
        {
            Console.WriteLine("Method");
        }

        public static void StaticMethod()
        {
            Console.WriteLine("StaticMethod");
        }
    }

    public static class StaticSample
    {
        public const string ConstField = "const value";

        //private string _field;

        private static string _staticField;

        //public string Property { get; set; }

        public static string StaticProperty { get; set; }

        //public StaticSample()
        //{
        //    _field = "value";
        //    Console.WriteLine("Constructor");
        //}

        static StaticSample()
        {
            _staticField = "static value";
            Console.WriteLine("StaticConstructor");
        }

        //public void Method()
        //{
        //    Console.WriteLine("Method");
        //}

        public static void StaticMethod()
        {
            Console.WriteLine("StaticMethod");
        }
    }
}
