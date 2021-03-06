﻿namespace InitSetter
{
    public class Sample
    {
        public string Property { get; set; }
        public string GetOnlyProperty { get; }
        public string InitOnlyProperty { get; init; }

        public Sample() { }

        public Sample(string property, string getOnlyProperty, string initOnlyProperty)
        {
            Property = property;
            GetOnlyProperty = getOnlyProperty;
            InitOnlyProperty = initOnlyProperty;
        }

        public void SampleMethod(string property, string getOnlyProperty, string initOnlyProperty)
        {
            Property = property;                    //OK
            //GetOnlyProperty = getOnlyProperty;      //Error
            //InitOnlyProperty = initOnlyProperty;    //Error
        }
    }

    public class Program
    {
        private static void Main(string[] args)
        {
            //コンストラクタで値を設定
            var s1 = new Sample("foo", "bar", "baz");

            //値を設定
            s1.Property = "qux";            //OK
            //s1.GetOnlyProperty = "qux";     //Error
            //s1.InitOnlyProperty = "qux";    //Error

            //オブジェクト初期化子で値を設定
            //get-only プロパティでは値を設定できないが、 init-only プロパティではOK 
            var s2 = new Sample
            {
                Property = "foo",           //OK
                //GetOnlyProperty = "bar",    //Error
                InitOnlyProperty = "baz",       //OK
            };
        }
    }
}
