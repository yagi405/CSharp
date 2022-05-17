
var array = new int[100];

for (int i = 1; i <= array.Length; i++)
{
    array[i - 1] = i * i;
}

for (int i = 0; i < array.Length; i++)
{
    Console.WriteLine($"array[{i}] => {array[i]}");
}