using System;
using System.Collections.Generic;

namespace Collection.ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("===============ToDoリスト===============");

            var toDoList = new List<string>();

            while (true)
            {
                ShowReadMe(@"ToDoを一行で入力
登録したToDoを表示する場合は **Show  
登録したToDoを削除する場合は **Delete
ToDoリストを終了する場合は   **Exit");

                var toDo = GetCommand();
                switch (toDo)
                {
                    case "":
                        Console.WriteLine("ToDoを入力してください。");
                        continue;

                    case "**Show":
                        ShowToDo(toDoList);
                        continue;

                    case "**Delete":

                        if (toDoList.Count == 0)
                        {
                            Console.WriteLine("現在登録されているToDoはありません。");
                            continue;
                        }

                        do
                        {
                            ShowReadMe($@"削除するToDoのNoを入力してください。（No.1 - No.{toDoList.Count}）
削除を終了する場合は空文字を入力してください。");

                            var input = GetCommand();

                            if (input == "")
                            {
                                break;
                            }

                            if (!int.TryParse(input, out var no))
                            {
                                Console.WriteLine($"Noは数値で入力してください。");
                                continue;
                            }

                            if (no < 0 || toDoList.Count < no)
                            {
                                Console.WriteLine($"No.{no}のToDoは登録されておりません。");
                                continue;
                            }

                            toDoList.RemoveAt(no - 1);
                            Console.WriteLine($"No.{no}のToDoを削除しました。");

                        } while (0 < toDoList.Count);
                        continue;

                    case "**Exit":
                        return;
                }

                toDoList.Add(toDo);
                Console.WriteLine($"ToDo（No.{toDoList.Count}）を登録しました。");
            }
        }

        private static void ShowToDo(List<string> toDoList)
        {
            if (toDoList == null)
            {
                return;
            }

            if (toDoList.Count == 0)
            {
                Console.WriteLine("現在登録されているToDoはありません。");
                return;
            }

            var max = toDoList.Count;

            var line = "--";
            var width = 2;
            for (; 0 < max; max /= 10)
            {
                width++;
                line += "-";
            }

            //{0,{width}}|{1}
            var format = $"{{0,{width}}}|{{1}}";

            Console.WriteLine();
            Console.WriteLine(format, "No", "ToDo");
            Console.WriteLine($"{line}+----------------------------------------------------");
            var i = 1;
            foreach (var toDo in toDoList)
            {
                Console.WriteLine(format, i++, toDo);
            }
        }

        private static string GetCommand()
        {
            Console.Write("> ");
            return Console.ReadLine().Trim();
        }

        private static void ShowReadMe(string message)
        {
            Console.WriteLine($@"
----------------Read Me----------------
{message}
---------------------------------------
");
        }
    }
}
