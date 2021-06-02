using System;

namespace CS35.AddressBook.Commands
{
    /// <summary>
    /// コマンド操作時の例外を示すクラスです。
    /// </summary>
    public class CommandException : Exception
    {
        /// <summary>
        /// <see cref="CommandException"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        public CommandException() { }

        /// <summary>
        /// 指定したエラーメッセージを使用して、<see cref="CommandException"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="message">エラーを説明するメッセージ</param>
        public CommandException(string message)
            : base(message) { }

        /// <summary>
        /// 指定したエラーメッセージおよびこの例外の原因となった内部例外への参照を使用して、<see cref="CommandException"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="message">例外の原因を説明するエラーメッセージ</param>
        /// <param name="innerException">現在の例外の原因である例外</param>
        public CommandException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}