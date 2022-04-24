
string? input = Console.ReadLine();
int i = int.Parse(input);

switch (i)
{
    case 1:
        Console.WriteLine("1が入力されました。");
        break;
    case 2:
        Console.WriteLine("2が入力されました。");
        break;
    case 3:
        Console.WriteLine("3が入力されました。");
        break;
    case 4:
        Console.WriteLine("4が入力されました。");
        break;
    default:
        Console.WriteLine("{0}が入力されました。", i);
        break;
}