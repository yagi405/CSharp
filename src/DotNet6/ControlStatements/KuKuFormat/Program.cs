
int i = 1; //左辺

while (i <= 20)
{
    int j = 1; //右辺
    while (j <= 20)
    {
        Console.WriteLine("{0,2} * {1,2} = {2,3}", i, j, i * j);
        j++;
    }
    i++;
}