using CS35.AddressBook.Data;
using CS35.AddressBook.Util;
using System;
using System.Collections.Generic;
using System.IO;

namespace CS35.AddressBook.Commands.Imp
{
    public class Save : AbstractCommand
    {
        protected override void ExecuteImp(ref IList<AddressInfo> addressBook, params string[] parameters)
        {
            Args.NotNull(addressBook, nameof(addressBook));

            if (parameters == null || parameters.Length == 0)
            {
                throw new CommandException("保存先のファイルパスを入力してください。");
            }

            if (parameters.Length > 1)
            {
                throw new CommandException("保存先のファイルパスは1つだけ指定してください。");
            }

            var filePath = !string.IsNullOrEmpty(parameters[0]) ? parameters[0]
                : throw new CommandException("保存先のファイルパスを入力してください。");

            StringUtil.RemoveStartEndDoubleQuotes(ref filePath);

            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var address in addressBook)
                    {
                        writer.WriteLine(address);
                    }
                }

                //File.WriteAllLines(filePath, addressBook.Select(x => x.ToString()));

                Console.WriteLine($"保存が完了しました。（計:{addressBook.Count}件）");
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new CommandException("指定されたディレクトリが存在しません。", ex);
            }
            catch (PathTooLongException ex)
            {
                throw new CommandException("指定されたファイルパスが長すぎます。", ex);
            }
            catch (IOException ex)
            {
                throw new CommandException("指定されたファイルに書き込むことができません。", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new CommandException("指定されたファイルへのアクセスが許可されておりません。", ex);
            }
        }

        protected override string GetHelpMessage()
        {
            return @$" 指定されたファイルパスに住所録データを保存します。
  例）{NameWithPrefix} addressbook.txt => addressbook.txtに住所録データを保存
 ※コマンドとファイルパスはスペース文字区切りで入力してください。";
        }
    }
}
