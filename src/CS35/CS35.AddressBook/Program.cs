using CS35.AddressBook.Commands;
using CS35.AddressBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS35.AddressBook
{
    /// <summary>
    /// 住所録アプリケーションのエントリーポイントを定義するクラスです。
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 住所録アプリケーションのエントリーポイントです。
        /// </summary>
        private static void Main()
        {
            try
            {
                IList<AddressInfo> addressBook = new List<AddressInfo>();

                Console.WriteLine("================住所録アプリケーション================");
                Console.WriteLine(AbstractCommand.GetDefaultHelpMessage());

                while (true)
                {
                    try
                    {
                        Console.WriteLine();
                        Console.Write("> ");
                        var line = Console.ReadLine();
                        var inputs = line.Split(' ', '　');

                        var command = AbstractCommand.CreateCommand(inputs[0]);
                        if (command != null)
                        {
                            //先頭要素はコマンド文字列（ex. :sort）なので、2要素目以降をパラメーターとして渡す
                            command.Execute(ref addressBook, inputs.Skip(1).ToArray());
                            continue;
                        }

                        command = AbstractCommand.DefaultCommand;
                        //既定のコマンドはコマンド文字列無しで呼び出し
                        command?.Execute(ref addressBook, inputs);

                    }
                    catch (CommandException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("予期せぬエラーが発生しました。");
                Console.WriteLine("住所録アプリケーションを終了します。");
                Console.WriteLine(ex);
                Environment.Exit(1);
            }
        }
    }
}