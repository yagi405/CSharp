using CS35.AddressBook.Data;
using CS35.AddressBook.Util;
using System;
using System.Collections.Generic;

namespace CS35.AddressBook.Commands.Imp
{
    public class List : AbstractCommand
    {
        protected override void ExecuteImp(ref IList<AddressInfo> addressBook, params string[] parameters)
        {
            Args.NotNull(addressBook, nameof(addressBook));

            Console.WriteLine();
            //必要な幅を厳密に計算していない
            var format = "{0,3} {1,-16} {2,3} {3,-14} {4}";
            Console.WriteLine(format, "No.", nameof(AddressInfo.Name), nameof(AddressInfo.Age), nameof(AddressInfo.TelNo), nameof(AddressInfo.Address));
            var i = 1;
            foreach (var address in addressBook)
            {
                Console.WriteLine(format, i++, address.Name, address.Age, address.TelNo, address.Address);
            }
            Console.WriteLine();
        }

        protected override string GetHelpMessage()
        {
            return @" 登録されている住所録データを一覧表示します。";
        }
    }
}