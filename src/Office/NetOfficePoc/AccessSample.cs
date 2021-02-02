using System;
using System.IO;
using NetOffice.AccessApi.Enums;
using NetOffice.DAOApi.Constants;
using Access = NetOffice.AccessApi;
using System.Data.OleDb;

namespace NetOfficePoc
{
    public static class AccessSample
    {
        public static void CreateDatabaseSample()
        {
            using (var app = new Access.Application())
            {
                var filePath = Path.Combine(Environment.CurrentDirectory, $"{nameof(CreateDatabaseSample)}.accdb");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                var newDatabase = app.DBEngine.Workspaces[0].CreateDatabase(filePath, LanguageConstants.dbLangGeneral);
                app.Quit(AcQuitOption.acQuitSaveAll);
            }
        }

        public static void WriteDataSample()
        {
            CreateDatabaseSample();

            using (var conn = new OleDbConnection(
                @"Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=False;Data Source=" +
                Path.Combine(Environment.CurrentDirectory, $"{nameof(CreateDatabaseSample)}.accdb")
                ))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE NetOfficeTable(Column1 Text, Column2 Text)";
                    cmd.ExecuteNonQuery();

                    for (var i = 0; i < 1000; i++)
                    {
                        cmd.CommandText = $"INSERT INTO NetOfficeTable(Column1, Column2) VALUES(\"{i}\", \"{DateTime.Now.ToShortTimeString()}\")";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}
