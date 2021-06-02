using System;

namespace CS35.AddressBook.Data
{
    /// <summary>
    /// 一件分の住所録データを示すレコードです。
    /// </summary>
    public record AddressInfo(string Name, int Age, string TelNo, string Address)
    {
        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Join(" ", Name, Age, TelNo, Address);
        }
    }

    /*
    /// <summary>
    /// 一件分の住所録データを示すクラスです。
    /// </summary>
    public class AddressInfo
    {
        /// <summary>
        /// 名前を取得します。
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// 年齢を取得します。
        /// </summary>
        public int Age { get; init; }

        /// <summary>
        /// 電話番号を取得します。
        /// </summary>
        public string TelNo { get; init; }

        /// <summary>
        /// 住所を取得します。
        /// </summary>
        public string Address { get; init; }

        /// <summary>
        /// <see cref="AddressInfo"/> クラスの新しいインタンスを初期化します。。
        /// </summary>
        /// <param name="name">名前</param>
        /// <param name="age">年齢</param>
        /// <param name="telNo">電話番号</param>
        /// <param name="address">住所</param>
        public AddressInfo(string name, int age, string telNo, string address) =>
            (Name, Age, TelNo, Address) = (name, age, telNo, address);

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Join(" ", Name, Age, TelNo, Address);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var address = (AddressInfo)obj;
            return Name == address.Name &&
                Age == address.Age &&
                TelNo == address.TelNo &&
                Address == address.Address;
        }

        /// <inheritdoc/>
        public override int GetHashCode() =>
            HashCode.Combine(Name.GetHashCode(), Age.GetHashCode(), TelNo.GetHashCode(), Address.GetHashCode());
    }
    */
}
