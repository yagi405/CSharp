using CS35.AddressBook.Data;
using System;
using System.Collections.Generic;

namespace CS35.AddressBook.Commands.Imp
{
    public class Help : AbstractCommand
    {
        /// <inheritdoc/>
        protected override bool AllowEmptyAddressBook => true;

        /// <inheritdoc/>
        protected override void ExecuteImp(ref IList<AddressInfo> addressBook, params string[] parameters)
        {
            Console.WriteLine(@"
[コマンド一覧]
");
            var messages = GetHelpMessages();
            foreach (var msg in messages)
            {
                Console.WriteLine(msg);
            }
        }

        /// <inheritdoc/>
        protected override string GetHelpMessage()
        {
            return @" 各コマンドの使用方法を表示します。";
        }
    }
}
