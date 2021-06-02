using CS35.AddressBook.Data;
using CS35.AddressBook.Util;
using System;
using System.Collections.Generic;
using System.IO;

namespace CS35.AddressBook.Commands.Imp
{
    public class Load : AbstractCommand
    {
        protected override bool AllowEmptyAddressBook => true;

        protected override void ExecuteImp(ref IList<AddressInfo> addressBook, params string[] parameters)
        {
            Args.NotNull(addressBook, nameof(addressBook));

            if (parameters == null || parameters.Length == 0)
            {
                throw new CommandException("読み込み先のファイルパスを入力してください。");
            }

            if (parameters.Length > 1)
            {
                throw new CommandException("読み込み先のファイルパスは1つだけ指定してください。");
            }

            var filePath = !string.IsNullOrEmpty(parameters[0]) ? parameters[0]
                : throw new CommandException("読み込み先のファイルパスを入力してください。");

           StringUtil.RemoveStartEndDoubleQuotes(ref filePath);

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    //ファイルの内容が不正である場合、既登録内容を残す
                    var tempAddressBook = new List<AddressInfo>();

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(line))
                        {
                            continue;
                        }
                        try
                        {
                            var info = Add.CreateAddressInfo(line.Split(new[] { ' ' }));
                            tempAddressBook.Add(info);
                        }
                        catch (CommandException ex)
                        {
                            throw new CommandException("ファイルの内容が不正です。", ex);
                        }
                    }

                    //tempAddressBook = File
                    //    .ReadLines(filePath)
                    //    .Where(x => !string.IsNullOrEmpty(x))
                    //    .Select(x => Add.CreateAddressInfo(line.Split(new char[] { ' ' })))
                    //    .ToList();

                    addressBook = tempAddressBook;
                }
                Console.WriteLine($"読み込みが完了しました。（計:{addressBook.Count}件）");
            }
            catch (FileNotFoundException ex)
            {
                throw new CommandException("指定されたファイルが存在しません。", ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new CommandException("指定されたディレクトリが存在しません。", ex);
            }
            catch (IOException ex)
            {
                throw new CommandException("指定されたファイルを読み込むことができません。", ex);
            }
        }

        protected override string GetHelpMessage()
        {
            return @$" 指定されたファイルパスから住所録データを読み込みます。
  例）{NameWithPrefix} addressbook.txt => addressbook.txtから住所録データを読み込み
 ※コマンドとファイルパスはスペース文字区切りで入力してください。";
        }
    }
}
