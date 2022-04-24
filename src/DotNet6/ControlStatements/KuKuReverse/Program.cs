
int i = 20; //左辺

while (i >= 1)
{
    int j = 20; //右辺
    while (j >= 1)
    {
        Console.WriteLine("{0} * {1} = {2}", i, j, i * j);
        j--;
    }
    i--;
}