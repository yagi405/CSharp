using CS35.AddressBook.Data;
using CS35.AddressBook.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS35.AddressBook.Commands.Imp
{
    public class Find : AbstractCommand
    {
        protected override void ExecuteImp(ref IList<AddressInfo> addressBook, params string[] parameters)
        {
            Args.NotNull(addressBook, nameof(addressBook));

            if (parameters == null || parameters.Length < 2)
            {
                throw new CommandException("検索対象の項目名と値を指定してください。");
            }

            if (parameters.Length > 2)
            {
                throw new CommandException("検索対象の項目名と値の2つを指定してください。");
            }

            var itemName = !string.IsNullOrEmpty(parameters[0]) ? parameters[0]
                : throw new CommandException("検索対象の項目名を指定してください。");

            var value = !string.IsNullOrEmpty(parameters[1]) ? parameters[1]
                : throw new CommandException("検索対象の値を指定してください。");

            IList<AddressInfo> result = new List<AddressInfo>();
            switch (itemName)
            {
                case "name":
                    result = addressBook
                        .Where(x => x.Name.Contains(value, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    break;
                case "age":
                    //数値に変換できない場合は検索結果が0件とみなす
                    if (int.TryParse(value, out var age))
                    {
                        result = addressBook
                            .Where(x => x.Age == age)
                            .ToList();
                    }
                    break;
                case "telno":
                    result = addressBook
                        .Where(x => x.TelNo.Contains(value, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    break;
                case "address":
                    result = addressBook
                        .Where(x => x.Address.Contains(value, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    break;
                default:
                    throw new CommandException($"{itemName}は検索対象の項目名として定義されておりません。");
            }

            if (!result.Any())
            {
                throw new CommandException("検索条件に該当する住所録データが存在しません。");
            }
            new List().Execute(ref result, new string[] { });
        }

        protected override string GetHelpMessage()
        {
            var builder = new StringBuilder();

            builder.AppendLine(@$" 指定された検索対象の項目名と値に合致する住所録データを表示します。
  例）{NameWithPrefix} age 22 => 年齢が22才の住所録データを表示
 項目名は以下の通りです。");

            builder.AppendLine(@"  name    … 名前 (部分一致)
  age     … 年齢
  telno   … 電話番号 (部分一致)
  address … 住所 (部分一致)"
);

            builder.Append($@" ※コマンドと、項目名、値はスペース文字区切りで入力してください。
 ※全件を確認する際は{new List().NameWithPrefix}コマンドを実行してください。");

            return builder.ToString();

        }
    }
}
