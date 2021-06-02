namespace CS35.AddressBook.Data
{
    /// <summary>
    /// 一件分の住所録データです。
    /// </summary>
    public record AddressInfo(string Name, int Age, string TelNo, string Address)
    {
        public override string ToString()
        {
            return string.Join(" ", Name, Age, TelNo, Address);
        }
    }
}
