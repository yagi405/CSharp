using System;

namespace CS35.AddressBook.Util
{
    /// <summary>
    /// 引数検証関連の汎用的な処理を提供するクラスです。
    /// </summary>
    public static class Args
    {
        /// <summary>
        /// 指定された参照型オブジェクトが null でないことを検証します。
        /// </summary>
        /// <typeparam name="T">参照型</typeparam>
        /// <param name="value">検証対象のオブジェクト</param>
        /// <param name="name">NGの場合に例外の発生原因とする引数の名前</param>
        public static void NotNull<T>(T value, string name) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// 指定された文字列が null 又は 空文字 でないことを検証します。
        /// </summary>
        /// <param name="value">検証対象の文字列</param>
        /// <param name="name">NGの場合に例外の発生原因とする引数の名前</param>
        public static void NotEmpty(string value, string name)
        {
            NotNull(value, name);
            if (value.Length == 0)
            {
                throw new ArgumentException("値を空にすることはできません。", name);
            }
        }
    }
}