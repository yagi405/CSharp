using CS35.AddressBook.Data;
using System;
using System.Collections.Generic;

namespace CS35.AddressBook.Commands.Imp
{
    /// <summary>
    /// exit コマンドを示すクラスです。
    /// </summary>
    public class Exit : AbstractCommand
    {
        /// <inheritdoc/>
        protected override bool AllowEmptyAddressBook => true;

        /// <inheritdoc/>
        protected override void ExecuteImp(ref IList<AddressInfo> addressBook, params string[] parameters)
        {
            Console.WriteLine("住所録アプリケーションを終了します。");
            Environment.Exit(0);
        }

        /// <inheritdoc/>
        protected override string GetHelpMessage()
        {
            return @" 住所録アプリケーションを終了します。";
        }
    }
}
