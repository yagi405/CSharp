
Console.Write("半角スペース区切りで数値を入力 >");
var s = Console.ReadLine();

var inputs = s.Split(" ");
var values = new int[inputs.Length];

for (int i = 0; i < inputs.Length; i++)
{
    values[i] = int.Parse(inputs[i]);
}

Console.WriteLine("===================");

for (int i = 0; i < values.Length - 1; i++)
{
    var swapped = false;

    for (int j = 1; j < values.Length - i; j++)
    {
        if (values[j] < values[j - 1])
        {
            var temp = values[j];
            values[j] = values[j - 1];
            values[j - 1] = temp;
            swapped = true;
        }
    }

    if (!swapped)
    {
        break;
    }
}

Console.Write(string.Join(" ", values));