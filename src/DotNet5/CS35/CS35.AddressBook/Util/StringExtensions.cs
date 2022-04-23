using System;
using System.Linq;

namespace CS35.AddressBook.Util
{
    /// <summary>
    /// <see cref="string"/> クラスの拡張メソッドを提供します。
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 指定文字列を、指定された回数繰り返した文字列を取得します。
        /// </summary>
        /// <param name="self">指定文字列</param>
        /// <param name="count">繰り返す回数</param>
        /// <returns>指定文字列を指定された回数繰り返した文字列</returns>
        public static string Repeat(this string self, int count)
        {
            return count < 0 ? throw new ArgumentOutOfRangeException(nameof(count), "0以上の整数を指定してください。")
                : string.IsNullOrEmpty(self) ? self
                : string.Concat(Enumerable.Repeat(self, count));
        }
    }
}
