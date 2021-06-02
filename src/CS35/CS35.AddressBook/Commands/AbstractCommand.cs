using CS35.AddressBook.Commands.Imp;
using CS35.AddressBook.Data;
using CS35.AddressBook.Util;
using System.Collections.Generic;
using System.Linq;

namespace CS35.AddressBook.Commands
{
    /// <summary>
    /// コマンドを示すクラスです。
    /// </summary>
    public abstract class AbstractCommand
    {
        /// <summary>
        /// コマンド文字列の接頭辞です。
        /// </summary>
        public const string CommandPrefix = ":";

        /// <summary>
        /// 本クラスの管理下にあるすべてのコマンドです。
        /// </summary>
        private static readonly AbstractCommand[] _allCommands = new AbstractCommand[]
        {
            new Add(),
            new List(),
            new Exit(),
            new Delete(),
            new Sort(),
            new Help(),
            new Save(),
            new Load(),
            new Find(),
            new Clear(),
        };

        /// <summary>
        /// 本クラスの管理下にあるコマンドのうち、ユーザーに公開するコマンドです。
        /// </summary>
        private static readonly AbstractCommand[] _availableCommands =
            _allCommands.Where(x => x.IsAvailableAsCommand).ToArray();

        /// <summary>
        /// コマンドの索引です。
        /// </summary>
        private static readonly Dictionary<string, AbstractCommand> _commandIndex =
            _availableCommands.ToDictionary(
                x => x.NameWithPrefix
            );

        /// <summary>
        /// 既定のコマンドを取得します。
        /// </summary>
        /// <returns>既定のコマンド</returns>
        public static AbstractCommand GetDefaultCommand()
        {
            //既定のコマンド（IsDefault == true）が複数存在する場合は、先頭のコマンドを採用
            return _allCommands.FirstOrDefault(x => x.IsDefault) ?? new Add();
        }

        /// <summary>
        /// 指定されたコマンド文字列に対応するコマンドの実体を生成します。
        /// </summary>
        /// <param name="command">コマンド文字列</param>
        /// <returns>コマンドの実体</returns>
        public static AbstractCommand CreateCommand(string command)
        {
            if (string.IsNullOrEmpty(command) || !command.StartsWith(CommandPrefix))
            {
                return null;
            }

            return _commandIndex.GetValueOrDefault(command)
                ?? throw new CommandExeption($"{command}は未定義のコマンドです。");
        }

        /// <summary>
        /// 既定の使用方法を示す文字列を取得します。
        /// </summary>
        /// <returns>既定の使用方法を示す文字列</returns>
        public static string GetDefaultHelpMessage()
        {
            return $@"{GetDefaultCommand()?.GetHelpMessage() ?? new Add().GetHelpMessage()}
 各コマンドの使用方法を確認する場合は {new Help().NameWithPrefix} と入力してください。
 なお、先頭の文字が {CommandPrefix} の場合、入力された内容はコマンドとみなされます。";
        }

        /// <summary>
        /// コマンドの名称を取得します。
        /// </summary>
        public virtual string Name => GetType().Name.ToLowerInvariant();

        /// <summary>
        /// コマンドの名称を接頭辞付きで取得します。
        /// </summary>
        public virtual string NameWithPrefix => CommandPrefix + Name;

        /// <summary>
        /// 要素数が0の住所録を許容するかを取得します。
        /// 許容するのであれば true それ以外は false
        /// </summary>
        protected virtual bool AllowEmptyAddressBook => false;

        /// <summary>
        /// 既定のコマンドであるかを取得します。
        /// 既定のコマンドであれば true それ以外は false
        /// </summary>
        protected virtual bool IsDefault => false;

        /// <summary>
        /// コマンドとしてユーザーに公開するかを取得します。
        /// コマンドとして公開するのであれば true それ以外は false
        /// </summary>
        protected virtual bool IsAvailableAsCommand => true;

        /// <summary>
        /// ユーザーに公開する全てのコマンドの使用方法を取得します。
        /// </summary>
        /// <returns>ユーザーに公開する全てのコマンドの使用方法</returns>
        protected static IEnumerable<string> GetHelpMessages()
        {
            return _availableCommands.Select(x => $"{x.NameWithPrefix}\r\n{x.GetHelpMessage()}\r\n");
        }

        /// <summary>
        /// コマンドに応じた処理を実行します。
        /// </summary>
        /// <param name="addressBook">処理対処の住所録</param>
        /// <param name="parameters">コマンドのパラメーター</param>
        public void Execute(ref IList<AddressInfo> addressBook, params string[] parameters)
        {
            Args.NotNull(addressBook, nameof(addressBook));

            if (!AllowEmptyAddressBook && !addressBook.Any())
            {
                throw new CommandExeption("データが1件も登録されておりません。");
            }

            ExecuteImp(ref addressBook, parameters);
        }

        /// <summary>
        /// コマンドに応じた処理を実行します。
        /// </summary>
        /// <param name="addressBook">処理対処の住所録</param>
        /// <param name="parameters">コマンドのパラメーター</param>
        protected abstract void ExecuteImp(ref IList<AddressInfo> addressBook, params string[] parameters);

        /// <summary>
        /// コマンドの使用方法を示す文字列を取得します。
        /// </summary>
        /// <returns>コマンドの使用方法を示す文字列</returns>
        protected abstract string GetHelpMessage();

    }
}
