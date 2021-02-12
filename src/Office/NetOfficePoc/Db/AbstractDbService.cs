using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace NetOfficePoc.Db
{
    public abstract class AbstractDbService
    {
        private readonly DbConnection _connection;

        protected virtual DbConnectionFactory Factory => DbConnectionFactory.Default;

        protected AbstractDbService() { }

        protected AbstractDbService(DbConnection connection)
        {
            _connection = connection;
        }

        protected IDisposable GetConnection(out DbConnection connection)
        {
            if (_connection != null)
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                connection = _connection;
                return NullDisposable.Instance;
            }

            connection = Factory.CreateConnection();
            return connection;
        }

        private class NullDisposable : IDisposable
        {
            public static IDisposable Instance { get; } = new NullDisposable();

            private NullDisposable() { }

            public void Dispose()
            {
                //何もしない
            }
        }
    }
}
