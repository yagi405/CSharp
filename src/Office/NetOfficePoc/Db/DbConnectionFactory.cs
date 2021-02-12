using System;
using System.Configuration;
using System.Data.Common;

namespace NetOfficePoc.Db
{
    public class DbConnectionFactory
    {
        public static string DefaultConnectionStringName => "default";

        public static DbConnectionFactory Default { get; } = new DbConnectionFactory(DefaultConnectionStringName);

        public ConnectionStringSettings Settings { get; }

        public DbProviderFactory DbProviderFactory { get; }

        public DbConnectionFactory(string connectionStringName)
        {
            if (connectionStringName == null)
            {
                throw new ArgumentNullException(nameof(connectionStringName));
            }

            Settings = ConfigurationManager.ConnectionStrings[connectionStringName] ??
                       throw new ConfigurationErrorsException(
                           $"アプリケーション構成ファイルに name = {connectionStringName} の接続文字列が定義されておりません。"
                           );

            DbProviderFactory = DbProviderFactories.GetFactory(Settings.ProviderName);
            if (DbProviderFactory == null)
            {
                throw new ConfigurationErrorsException(
                    $"アプリケーション構成ファイルの接続文字列（name = {connectionStringName}） の ProviderName が不正です。"
                    );
            }
        }

        public DbConnection CreateConnection()
        {
            DbConnection connection = null;
            try
            {
                connection = DbProviderFactory.CreateConnection();
                if (connection == null)
                {
                    return null;
                }

                connection.ConnectionString = Settings.ConnectionString;
                connection.Open();
                return connection;

            }
            catch (Exception)
            {
                connection?.Dispose();
                throw;
            }
        }
    }
}
