//var s1 = "      abc        ";

//Console.WriteLine(s1);
//Console.WriteLine(s1.Trim());

//var s2 = "abcdef";

//Console.WriteLine(s2.Substring(4, 2));
//Console.WriteLine(s2.Replace("def", "xyz"));
//Console.WriteLine(s2.Length);

//Console.WriteLine(s2.Reverse().ToArray());

//var s3 = "900";
//var s4 = "1000";

//Console.WriteLine(s3.CompareTo(s4));

//var name = Console.ReadLine();
//var result = string.Format("Hello {0}!", name);

//Console.WriteLine(result);

Console.WriteLine("1行目\r\n2行目\r\n3行目");
Console.WriteLine("\\");
Console.WriteLine("改行文字 => \\r\\n");

Console.WriteLine("1行目" +
    "2行目" +
    "3行目");

Console.WriteLine(@"1行目
2行目
3行目");

Console.WriteLine(@"改行文字 => \\r\\n");

var input = "abcdef";
Console.WriteLine("入力された文字列の長さ => {0}", input.Length);
Console.WriteLine($"入力された文字列の長さ => {input.Length}");