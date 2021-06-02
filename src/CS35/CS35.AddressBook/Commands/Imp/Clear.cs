using CS35.AddressBook.Data;
using CS35.AddressBook.Util;
using System;
using System.Collections.Generic;

namespace CS35.AddressBook.Commands.Imp
{
    /// <summary>
    /// clear コマンドを示すクラスです。
    /// </summary>
    public class Clear : AbstractCommand
    {
        /// <inheritdoc/>
        protected override void ExecuteImp(ref IList<AddressInfo> addressBook, params string[] parameters)
        {
            Args.NotNull(addressBook, nameof(addressBook));

            addressBook.Clear();

            Console.WriteLine("住所録データを全て削除しました。");
        }

        /// <inheritdoc/>
        protected override string GetHelpMessage()
        {
            return @" 登録されている住所録データを全て削除します。";
        }
    }
}
