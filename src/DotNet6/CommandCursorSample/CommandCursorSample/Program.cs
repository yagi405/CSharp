namespace CommandCursorSample
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("何を買いますか？");
            Console.WriteLine();

            var cm = new CommandManager();
            var items = new[] {
                new SampleItem() { Name = "木刀", Price = 10},
                new SampleItem() { Name = "よい木刀", Price = 100},
                new SampleItem() { Name = "すごい木刀", Price = 1000},
            };

            var c = cm.ShowCommands(
                items.Select(e => new Command<SampleItem?>($"{e.Name} ({e.Price}円)", e)).ToList()
            );

            Console.WriteLine($"{c?.Caption ?? "キャンセル"} が選択されました");

            if (c != null)
            {
                var item = c.Extension;
                Console.WriteLine($"{item?.Name} を買った");
            }
        }
    }
}