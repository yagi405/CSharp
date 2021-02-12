using System;
using System.Data.Common;
using NetOfficePoc.Db;

namespace NetOfficePoc.Access
{
    public class SampleService : AbstractDbService
    {
        public SampleService() { }

        public SampleService(DbConnection connection) : base(connection) { }

        public void CreateTable()
        {
            using (GetConnection(out var conn))
            using (var cmd = conn.CreateCommand())
            {

                cmd.CommandText = "CREATE TABLE NetOfficeTable(Column1 Text, Column2 Text)";
                cmd.ExecuteNonQuery();
            }
        }

        public void AddSampleData()
        {
            using (GetConnection(out var conn))
            using (var cmd = conn.CreateCommand())
            {
                for (var i = 0; i < 100; i++)
                {
                    cmd.CommandText = $"INSERT INTO NetOfficeTable(Column1, Column2) VALUES(\"{i}\", \"{DateTime.Now.ToShortTimeString()}\")";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
