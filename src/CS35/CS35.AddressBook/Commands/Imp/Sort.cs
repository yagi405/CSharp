using CS35.AddressBook.Data;
using CS35.AddressBook.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS35.AddressBook.Commands.Imp
{
    /// <summary>
    /// sort コマンドを示すクラスです。
    /// </summary>
    public class Sort : AbstractCommand
    {
        /// <summary>
        /// 昇順のソート方式を示す文字列です。
        /// </summary>
        private const string AscKeyword = "asc";

        /// <summary>
        /// 降順のソート方式を示す文字列です。
        /// </summary>
        private const string DescKeyword = "desc";

        /// <summary>
        /// 公開するSorterです。
        /// </summary>
        private static readonly Sorter[] _availableSorters = {
            new(nameof(AddressInfo.Name).ToLowerInvariant(),
                x => x.OrderBy(info => info.Name),
                x => x.OrderByDescending(info => info.Name)),
            new(nameof(AddressInfo.Age).ToLowerInvariant(),
                x => x.OrderBy(info => info.Age),
                x => x.OrderByDescending(info => info.Age)),
            new(nameof(AddressInfo.TelNo).ToLowerInvariant(),
                x => x.OrderBy(info => info.TelNo),
                x => x.OrderByDescending(info => info.TelNo)),
            new(nameof(AddressInfo.Address).ToLowerInvariant(),
                x => x.OrderBy(info => info.Address),
                x => x.OrderByDescending(info => info.Address)),
        };

        /// <summary>
        /// Sorterの索引です。
        /// </summary>
        private static readonly Dictionary<string, Sorter> _sorterIndex =
            _availableSorters.ToDictionary(x => x.Keyword);

        /// <inheritdoc/>
        protected override void ExecuteImp(ref IList<AddressInfo> addressBook, params string[] parameters)
        {
            Args.NotNull(addressBook, nameof(addressBook));

            if (parameters == null || parameters.Length == 0)
            {
                throw new CommandException("ソート対象の項目名を指定してください。");
            }

            if (parameters.Length > 2)
            {
                throw new CommandException("ソート対象の項目名とソート方式の2つを指定してください。");
            }

            var itemName = !string.IsNullOrEmpty(parameters[0]) ? parameters[0]
                : throw new CommandException("検索対象の項目名を指定してください。");

            var sorter = _sorterIndex.GetValueOrDefault(itemName) ??
                throw new CommandException($"{itemName}はソート対象の項目名として定義されておりません。");

            var sortType = parameters.Length == 1 || string.IsNullOrEmpty(parameters[1]) ? AscKeyword
                : parameters[1];

            addressBook = sortType switch
            {
                AscKeyword => sorter.OrderBy(addressBook).ToList(),
                DescKeyword => sorter.OrderByDesc(addressBook).ToList(),
                _ => throw new CommandException($"{sortType}はソート方式として定義されておりません。")
            };

            sortType = sortType == AscKeyword ? "昇順" : "降順";

            Console.WriteLine($"{itemName}の{sortType}で住所録データをソートしました。");
        }

        /// <summary>
        /// ソート処理を担うSorterを示す内部クラスです。
        /// </summary>
        public class Sorter
        {
            /// <summary>
            /// Sorterを一意に特定可能なキーワードを取得します。
            /// </summary>
            public string Keyword { get; }

            /// <summary>
            /// 昇順ソートをおこなうデリゲートです。
            /// </summary>
            public Func<IEnumerable<AddressInfo>, IOrderedEnumerable<AddressInfo>> OrderBy { get; }

            /// <summary>
            /// 降順ソートをおこなうデリゲートです。
            /// </summary>
            public Func<IEnumerable<AddressInfo>, IOrderedEnumerable<AddressInfo>> OrderByDesc { get; }

            /// <summary>
            /// <see cref="Sorter"/>のインスタンスを生成します。
            /// </summary>
            /// <param name="keyword">Sorterを一意に特定可能なキーワード</param>
            /// <param name="orderBy">昇順ソートをおこなうデリゲート</param>
            /// <param name="orderByDesc">降順ソートをおこなうデリゲート</param>
            public Sorter(string keyword,
                Func<IEnumerable<AddressInfo>, IOrderedEnumerable<AddressInfo>> orderBy,
                Func<IEnumerable<AddressInfo>, IOrderedEnumerable<AddressInfo>> orderByDesc)
            {
                Args.NotEmpty(keyword, nameof(keyword));
                (Keyword, OrderBy, OrderByDesc) =
                    (
                    keyword,
                    orderBy ?? throw new ArgumentNullException(nameof(orderBy)),
                    orderByDesc ?? throw new ArgumentNullException(nameof(orderByDesc))
                    );
            }
        }

        /// <inheritdoc/>
        protected override string GetHelpMessage()
        {
            var builder = new StringBuilder();

            builder.AppendLine(@$" 住所録データを指定された項目名とソート方式に従って並び替えます。
  例）{NameWithPrefix} {nameof(AddressInfo.Age).ToLowerInvariant()} desc => 年齢で住所録データを降順に並び替え
 項目名は以下の通りです。");

            builder.AppendLine(string.Join("\r\n", _availableSorters.Select(x => $"  ・{x.Keyword}")));

            builder.Append($" ソート方式は{AscKeyword}を指定した場合は昇順、{DescKeyword}は降順となり、省略時は昇順になります。");

            builder.Append($@"  ※コマンドと、項目名はスペース文字区切りで入力してください。
 ※値を確認する際は{new List().NameWithPrefix}コマンドを実行してください。");

            return builder.ToString();
        }
    }
}