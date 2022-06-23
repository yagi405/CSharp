
var array = new int[100];

for (int i = 1; i <= array.Length; i++)
{
    array[i - 1] = i * i;
}

for (int i = 0; i < array.Length; i++)
{
    Console.WriteLine($"array[{i}] => {array[i]}");
}

Console.Write("開始する添え字を指定 > ");
var start = int.Parse(Console.ReadLine());

Console.Write("合計を行う要素の数を指定 > ");
var count = int.Parse(Console.ReadLine());

if (start < 0 || 100 <= start)
{
    Console.WriteLine("startが不正です。");
}
else if (count < 0)
{
    Console.WriteLine("countが不正です。");
}
else
{
    var total = 0;
    var index = start;
    for (var i = start; i < start + count; i++)
    {
        if (index == 100)
        {
            index -= 100;
        }

        total += array[index];
        index++;
    }
    Console.WriteLine($"total => {total}");
}