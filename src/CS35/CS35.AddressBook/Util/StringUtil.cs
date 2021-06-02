namespace CS35.AddressBook.Util
{
    /// <summary>
    /// 文字列操作関連の汎用的な処理を提供するクラスです。
    /// </summary>
    public static class StringUtil
    {
        /// <summary>
        /// 指定された文字列の両端に存在するダブルクォーテーションを除去します。
        /// </summary>
        /// <param name="s">文字列</param>
        /// <remarks>除去するのは両端いずれにもダブルクォーテーションが存在する場合のみ</remarks>
        public static void RemoveStartEndDoubleQuotes(ref string s)
        {
            //プロパティパターン（ is { Length: >= 2 } の部分）
            //https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/operators/patterns#property-pattern
            //範囲演算子（ s[1..^1] の部分）
            //https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/operators/member-access-operators#range-operator-

            s = s is { Length: >= 2 } && s.StartsWith("\"") && s.EndsWith("\"")
                ? s[1..^1]
                : s;
        }
    }
}