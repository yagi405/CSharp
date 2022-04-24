
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine(i);
}

Console.WriteLine("=================");

int j = 1;
while (j <= 10)
{
    Console.WriteLine(j);
    j++;
}

Console.WriteLine("=================");

//for(; ; )
//{
//    Console.WriteLine("infinite loop");
//}

Console.WriteLine("=================");

int start = 3;
int sum = 0;

for (int i = start; i < start + 10; i++)
{
    //i：13
    //sum：161
    sum += i;
    if (sum >= 100)
    {
        continue;
    }
    sum += i * i;
}

Console.WriteLine("sum = {0}", sum);
//161