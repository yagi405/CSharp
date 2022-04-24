
string input;
while ((input = Console.ReadLine()) != "")
{
    Console.WriteLine("入力された文字列の長さ => {0}", input.Length);
    Console.WriteLine("すべて大文字 => {0}", input.ToUpper());
    Console.WriteLine("すべて小文字 => {0}", input.ToLower());

    var reversed = "";
    for (int i = input.Length - 1; i >= 0; i--)
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

    Console.WriteLine("反転 => {0}", inverted);
    Console.WriteLine("====================");
}