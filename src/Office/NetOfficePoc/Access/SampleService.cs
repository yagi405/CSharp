using System;
using System.Collections.Generic;
using System.Data.Common;
using NetOfficePoc.Db;

namespace NetOfficePoc.Access
{
    public class SampleService : AbstractDbService
    {
        public SampleService() { }

        public SampleService(DbConnection connection) : base(connection) { }

        public void CreateTable(DbTransaction tran = null)
        {
            using (GetConnection(out var conn))
            using (var cmd = conn.CreateCommand())
            {
                if (tran != null)
                {
                    cmd.Transaction = tran;
                }

                cmd.CommandText = "CREATE TABLE NetOfficeTable(Column1 Text, Column2 Text)";
                cmd.ExecuteNonQuery();
            }
        }

        public List<Sample> GetAll(DbTransaction tran = null)
        {
            var results = new List<Sample>();
            using (GetConnection(out var conn))
            using (var cmd = conn.CreateCommand())
            {
                if (tran != null)
                {
                    cmd.Transaction = tran;
                }

                cmd.CommandText = @"
SELECT
    *
FROM
    NetOfficeTable
";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new Sample(reader["Column1"].ToString(), reader["Column2"].ToString()));
                    }
                }
            }
            return results;
        }

        public Sample GetById(string id)
        {
            using (GetConnection(out var conn))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT
    *
FROM
    NetOfficeTable
WHERE
    Column1 = @id
";
                cmd.AddParameter("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Sample(reader["Column1"].ToString(), reader["Column2"].ToString());
                    }
                }
            }
            return null;
        }

        public void AddSampleData(DbTransaction tran = null)
        {
            using (GetConnection(out var conn))
            using (var cmd = conn.CreateCommand())
            {
                if (tran != null)
                {
                    cmd.Transaction = tran;
                }

                for (var i = 0; i < 100; i++)
                {
                    cmd.CommandText = $"INSERT INTO NetOfficeTable(Column1, Column2) VALUES(\"{i}\", \"{DateTime.Now.ToShortTimeString()}\")";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
