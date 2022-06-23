
string input;
while ((input = Console.ReadLine()) != "")
{
    //if (input == "") { break; }

    Console.WriteLine("入力された文字列の長さ => {0}", input.Length);
    Console.WriteLine("すべて大文字 => {0}", input.ToUpper());
    Console.WriteLine("すべて小文字 => {0}", input.ToLower());

    var reversed = "";
    for (var i = input.Length - 1; i >= 0; i--)
    {
        reversed += input.Substring(i, 1);
    }
    Console.WriteLine("逆順 => {0}", reversed);

    var inverted = "";
    for (int i = 0; i < input.Length; i++)
    {
        var s = input.Substring(i, 1);
        var upper = s.ToUpper();

        if (s == upper)
        {
            inverted += s.ToLower();
        }
        else
        {
            inverted += upper;
        }
    }
    Console.WriteLine("大文字小文字反転 => {0}", inverted);
    Console.WriteLine("---------------------");

    //input = Console.ReadLine();
}

////a b c
////0 1 2
//Console.WriteLine(input.Substring(2, 1));
//Console.WriteLine(input.Substring(1, 1));
//Console.WriteLine(input.Substring(0, 1));

////a b c d e
////0 1 2 3 4
//Console.WriteLine(input.Substring(4, 1));
//Console.WriteLine(input.Substring(3, 1));
//Console.WriteLine(input.Substring(2, 1));
//Console.WriteLine(input.Substring(1, 1));
//Console.WriteLine(input.Substring(0, 1));

//var sum = 0;
//for (var i = 1; i <= 100; i++)
//{
//    sum += i;
//}
//Console.WriteLine(sum);

//int i;
//Console.WriteLine(i = 100);

