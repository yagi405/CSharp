using System.Data;

namespace SimpleChatApp.Infrastructure.Repositories
{
    public class AbstractRepository
    {
        private readonly IDbConnection _dbConnection;

        protected IDbConnection Connection => GetConnection();

        public AbstractRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        private IDbConnection GetConnection()
        {
            if (_dbConnection.State == ConnectionState.Closed)
            {
                _dbConnection.Open();
            }

            return _dbConnection;
        }
    }
}
