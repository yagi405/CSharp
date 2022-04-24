int sum = 0;
for (int i = 0; i < 100; i++)
{
    for (int j = 0; j < 100; j++)
    {
        sum += i + j;
        if (sum >= 10000)
        {
            goto loop_end;
        }
    }
}
loop_end:;