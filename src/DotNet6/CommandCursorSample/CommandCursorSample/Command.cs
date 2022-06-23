namespace CommandCursorSample
{
    public class Command<T>
    {
        public static IReadOnlyList<Command<T>> CreateCommands(params string[] caption)
        {
            return caption.Select(v => new Command<T>(v)).ToList().AsReadOnly();
        }

        public string Caption { get; }

        public T? Extension { get; }

        public Command(string caption)
            : this(caption, default)
        {
        }

        public Command(string caption, T? extension)
        {
            Caption = caption;
            Extension = extension;
        }
    }
}
