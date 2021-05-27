namespace ExtensionMethods.Demo
{
    public static class StringExtensions
    {
        public static int ParseInt(this string self)
        {
            return int.Parse(self);
        }
    }
}
