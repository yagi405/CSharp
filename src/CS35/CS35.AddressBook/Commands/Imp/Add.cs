using CS35.AddressBook.Data;
using CS35.AddressBook.Util;
using System;
using System.Collections.Generic;

namespace CS35.AddressBook.Commands.Imp
{
    public class Add : AbstractCommand
    {
        /// <summary>
        /// 登録する項目の数です。
        /// </summary>
        private const int FieldCount = 4;

        /// <inheritdoc/>
        protected override bool AllowEmptyAddressBook => true;

        /// <inheritdoc/>
        protected override bool IsAvailableAsCommand => false;

        /// <inheritdoc/>
        protected override bool IsDefault => true;

        /// <inheritdoc/>
        protected override void ExecuteImp(ref IList<AddressInfo> addressBook, params string[] parameters)
        {
            Args.NotNull(addressBook, nameof(addressBook));

            var address = CreateAddressInfo(parameters);
            if (addressBook.Contains(address))
            {
                throw new CommandException("既に登録されている住所録データです。");
            }

            addressBook.Add(address);
            Console.WriteLine($"住所録データを登録しました。(No.{addressBook.Count})");
        }

        /// <summary>
        /// 住所録データを生成します。
        /// </summary>
        /// <param name="parameters">住所録データの情報</param>
        /// <returns>住所録データ</returns>
        public static AddressInfo CreateAddressInfo(string[] parameters)
        {
            if (parameters == null || parameters.Length != FieldCount)
            {
                throw new CommandException("住所録データの書式が不正です。");
            }

            if (string.IsNullOrEmpty(parameters[0]))
            {
                throw new CommandException("名前及び年齢は必ず入力してください。");
            }

            if (!int.TryParse(parameters[1], out var age))
            {
                throw new CommandException("年齢は数値で入力してください。");
            }

            //電話番号と住所のチェックは実装していない

            return new AddressInfo(parameters[0], age, parameters[2], parameters[3]);
        }

        /// <inheritdoc/>
        protected override string GetHelpMessage()
        {
            return @" 以下の書式で住所録データを入力してください。
 名前 年齢 電話番号 住所
 ※各項目はスペース文字区切りで入力してください。
 ※各項目の内容に、スペース文字を含めることはできません。"
;
        }
    }
}
