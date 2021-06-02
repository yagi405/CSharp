using CS35.AddressBook.Data;
using CS35.AddressBook.Util;
using System;
using System.Collections.Generic;

namespace CS35.AddressBook.Commands.Imp
{
    public class Delete : AbstractCommand
    {
        protected override void ExecuteImp(ref IList<AddressInfo> addressBook, params string[] parameters)
        {
            Args.NotNull(addressBook, nameof(addressBook));

            if (parameters == null || parameters.Length == 0)
            {
                throw new CommandExeption("削除対象のNoを指定してください。");
            }

            if (parameters.Length > 1)
            {
                throw new CommandExeption("削除対象のNoは1つだけ指定してください。");
            }

            if (!int.TryParse(parameters[0], out var num))
            {
                throw new CommandExeption($"削除対象のNoは数値で入力してください。");
            }

            var index = num - 1;
            if (index < 0 || addressBook.Count <= index)
            {
                throw new CommandExeption($"指定された削除対象のNo「{num}」に対応するデータは存在しません。");
            }

            addressBook.RemoveAt(index);
            Console.WriteLine($"No.{num}の住所録データを削除しました。");
        }

        protected override string GetHelpMessage()
        {
            return @$" 指定されたNoの住所録データを削除します。
  例）{NameWithPrefix} 1 => No.1の住所録データを削除
 ※コマンドとNoはスペース文字区切りで入力してください。
 ※Noを確認する際は{new List().NameWithPrefix}コマンドを実行してください。"
;
        }
    }
}
