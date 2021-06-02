using System;
using System.Runtime.Serialization;

namespace CS35.AddressBook.Commands
{
    /// <summary>
    /// コマンド操作時の例外を示すクラスです。
    /// </summary>
    [Serializable()]
    public class CommandExeption : Exception
    {
        public CommandExeption() { }

        public CommandExeption(string message) : base(message) { }

        public CommandExeption(string message, Exception innerException) : base(message, innerException) { }

        protected CommandExeption(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
