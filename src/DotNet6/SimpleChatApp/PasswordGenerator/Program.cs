using System.Security.Cryptography;

namespace PasswordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("平文のパスワードを入力");
            var plainPassword = Console.ReadLine();

            if (string.IsNullOrEmpty(plainPassword))
            {
                return;
            }

            using var derive = new Rfc2898DeriveBytes(plainPassword, 24, 10000);
            
            var bytHashedPassword = derive.GetBytes(32);
            var hashedPassword = Convert.ToBase64String(bytHashedPassword);
            
            var bytSale = derive.Salt;
            var salt = Convert.ToBase64String(bytSale);

            Console.WriteLine();
            Console.WriteLine($"hash : {hashedPassword}");
            Console.WriteLine($"salt : {salt}");
        }
    }
}