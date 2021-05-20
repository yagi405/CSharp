using System;
using System.Collections.Generic;

namespace Collection.ToDoList
{
    class Program
    {
        private static void Main(string[] args)
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
                        break;

                    case "**Show":

                        if (toDoList.Count == 0)
                        {
                            Console.WriteLine("登録されているToDoがありません。");
                            break;
                        }
                        ShowToDoList(toDoList);
                        break;

                    case "**Delete":

                        if (toDoList.Count == 0)
                        {
                            Console.WriteLine("登録されているToDoがありません。");
                            break;
                        }
                        DeleteToDoList(toDoList);
                        break;

                    case "**Exit":
                        return;

                    default:
                        toDoList.Add(toDo);
                        Console.WriteLine($"ToDo（No.{toDoList.Count}）を登録しました。");
                        break;
                }
            }
        }

        private static void DeleteToDoList(List<string> toDoList)
        {
            if (toDoList == null)
            {
                return;
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

                if (!int.TryParse(input, out var number))
                {
                    Console.WriteLine("Noは数値で入力してください。");
                    continue;
                }

                if (number < 1 || toDoList.Count < number)
                {
                    Console.WriteLine($"No.{number}のToDoは登録されておりません。");
                    continue;
                }

                toDoList.RemoveAt(number - 1);
                Console.WriteLine($"No.{number}のToDoを削除しました。");

            } while (0 < toDoList.Count);
        }

        private static void ShowToDoList(List<string> toDoList)
        {
            if (toDoList == null)
            {
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
