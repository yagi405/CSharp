using CS35.AddressBook.Data;
using CS35.AddressBook.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS35.AddressBook.Commands.Imp
{
    /// <summary>
    /// list コマンドを示すクラスです。
    /// </summary>
    public class List : AbstractCommand
    {
        /// <inheritdoc/>
        protected override void ExecuteImp(ref IList<AddressInfo> addressBook, params string[] parameters)
        {
            Args.NotNull(addressBook, nameof(addressBook));

            const string headerNo = "No.";
            var noWidth = Math.Max(addressBook.Count.ToString().Length, headerNo.Length) + 1;
            var nameWidth = Math.Max(addressBook.Max(x => x.Name.Length), nameof(AddressInfo.Name).Length) + 1;
            var ageWidth = Math.Max(addressBook.Max(x => x.Age.ToString().Length), nameof(AddressInfo.TelNo).Length) + 1;
            var telNoWidth = Math.Max(addressBook.Max(x => x.TelNo.Length), nameof(AddressInfo.TelNo).Length) + 1;

            var format = $"{{0,{noWidth}}}|{{1,{-nameWidth}}}|{{2,{ageWidth}}}|{{3,{-telNoWidth}}}|{{4}}";
            
            Console.WriteLine();
            Console.WriteLine(format, headerNo, nameof(AddressInfo.Name), nameof(AddressInfo.Age), nameof(AddressInfo.TelNo), nameof(AddressInfo.Address));

            const string line = "-";
            Console.WriteLine($"{line.Repeat(noWidth)}+{line.Repeat(nameWidth)}+{line.Repeat(ageWidth)}+{line.Repeat(telNoWidth)}+--------------");

            var i = 1;
            foreach (var address in addressBook)
            {
                Console.WriteLine(format, i++, address.Name, address.Age, address.TelNo, address.Address);
            }
            Console.WriteLine();
        }

        /// <inheritdoc/>
        protected override string GetHelpMessage()
        {
            return @" 登録されている住所録データを一覧表示します。";
        }
    }
}