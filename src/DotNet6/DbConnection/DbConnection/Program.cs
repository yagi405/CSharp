using System.Data;
using Microsoft.Data.SqlClient;

namespace DbConnection
{
    internal class Program
    {
        static string GetConnectionString()
        {
            var builder = new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-2K5L9SP",
                InitialCatalog = "sample_db",
                UserID = "sa",
                Password = "P@ssw0rd",
            };

            //Console.WriteLine($"接続文字列 => {builder.ConnectionString}");
            return builder.ConnectionString;
            //return "Data Source=DESKTOP-2K5L9SP;Initial Catalog=sample_db;User ID=sa;Password=P@ssw0rd";
        }

        static void Lesson1()
        {
            using var conn = new SqlConnection(GetConnectionString());
            //conn.ConnectionString = GetConnectionString();
            Console.WriteLine($"インスタンス => {conn.DataSource}");
            Console.WriteLine($"データベース => {conn.Database}");
            Console.WriteLine($"状態 => {conn.State}");
            conn.Open();
            Console.WriteLine($"状態(Open呼出後) => {conn.State}");
            conn.Close();
            Console.WriteLine($"状態(Close呼出後) => {conn.State}");
        }

        static void Demo1()
        {
            var cmdText = @"
select
	*
from
	部門CS
order by
	部門番号
";
            using var conn = new SqlConnection(GetConnectionString());
            conn.Open();
            using var cmd = new SqlCommand(cmdText, conn);
            using var dr = cmd.ExecuteReader();
            Console.WriteLine(dr.Read());
            Console.WriteLine(string.Join("-", dr[0], dr[1]));
            Console.WriteLine(dr.Read());
            Console.WriteLine(string.Join("-", dr["部門番号"], dr["部門名"]));
            Console.WriteLine(dr.Read());
            Console.WriteLine(string.Join("-", dr[0], dr[1]));
            Console.WriteLine(dr.Read());

            //error
            //Console.WriteLine(string.Join("-", dr[0], dr[1]));

            //using (var conn = new SqlConnection())
            //{
            //    conn.ConnectionString = GetConnectionString();
            //    conn.Open();

            //    using (var cmd = new SqlCommand())
            //    {
            //        cmd.CommandText = cmdText;
            //        cmd.Connection = conn;
            //        using (var dr = cmd.ExecuteReader())
            //        {
            //            //略
            //        }
            //    }
            //}
        }

        static void Lesson2()
        {
            var cmdText = @"
select
    *
from
    社員CS
order by
    社員番号
";
            using var conn = new SqlConnection(GetConnectionString());
            conn.Open();
            using var cmd = new SqlCommand(cmdText, conn);
            using var dr = cmd.ExecuteReader();
            var cnt = 0;
            while (dr.Read())
            {
                Console.WriteLine(string.Join("-", dr["社員番号"], dr["氏名"]));
                cnt++;
            }
            //foreach (var d in dr)
            //{
            //    Console.WriteLine(string.Join("-", dr["社員番号"], dr["氏名"]));
            //    cnt++;
            //}
            Console.WriteLine($"取得{cnt}件");
        }

        static void Demo2()
        {
            var cmdText = @"delete from 社員CS";

            using var conn = new SqlConnection(GetConnectionString());
            conn.Open();
            using var cmd = new SqlCommand(cmdText, conn);
            var effected = cmd.ExecuteNonQuery();
            Console.WriteLine($"影響を受けた行数 => {effected}");
        }

        static void Lesson3()
        {
            var cmdText = @"
update
    社員CS
set
    給与 = 給与 * 10
";
            using var conn = new SqlConnection(GetConnectionString());
            conn.Open();
            using var cmd = new SqlCommand(cmdText, conn);
            var effected = cmd.ExecuteNonQuery();
            Console.WriteLine($"更新{effected}件");
        }

        static void Demo3()
        {
            var cmdText = @"
select
    *
from
    部門CS
order by
    部門番号
";
            var dt = new DataTable();

            using (var conn = new SqlConnection(GetConnectionString()))
            using (var ada = new SqlDataAdapter(cmdText, conn))
            {
                Console.WriteLine($"状態(Fill前) => {conn.State}");
                var effected = ada.Fill(dt);
                Console.WriteLine($"状態(Fill後) => {conn.State}");
                Console.WriteLine($"影響を受けた行数 => {effected}");
            }

            Console.WriteLine($"列数 => {dt.Columns.Count}");
            Console.WriteLine($"行数 => {dt.Rows.Count}");
            Console.WriteLine($"2行目1列目の値 => {dt.Rows[1][0]}");
            //Console.WriteLine($"2行目1列目の値 => {dt.Rows[1]["部門名"]}");
        }

        static void Lesson4()
        {
            var cmdText = @"
select
    *
from
    社員CS
order by
    社員番号
";
            var dt = new DataTable();
            using (var ada = new SqlDataAdapter(cmdText, GetConnectionString()))
            {
                ada.Fill(dt);
            }

            Console.WriteLine($"行:{dt.Rows.Count}");
            Console.WriteLine($"列:{dt.Columns.Count}");
            Console.WriteLine($"1行目の第2項目 => {dt.Rows[0][1]}");
        }

        static void Demo4()
        {
            var cmdText = @"
select
    *
from
    部門CS
order by
    部門番号
";

            var dt = new DataTable();
            using (var ada = new SqlDataAdapter(cmdText, GetConnectionString()))
            {
                ada.Fill(dt);
            }

            var colNames = new List<string>();
            foreach (DataColumn dc in dt.Columns)
            {
                colNames.Add(dc.ColumnName);
            }
            Console.WriteLine(string.Join(",", colNames));

            foreach (DataRow dr in dt.Rows)
            {
                //var values = new List<object>();
                //foreach (var v in dr.ItemArray)
                //{
                //    values.Add(v);
                //}

                //Console.WriteLine(string.Join(",", values));

                Console.WriteLine(string.Join(",", dr.ItemArray));
            }
        }

        private static void DataTimeFormatStringsSample(DateTime? src = null)
        {
            var d = src ?? DateTime.Now;

            string[] standardFormats = {"d", "D", "f", "F", "g", "G", "m", "o",
                               "R", "s", "t", "T", "u", "U", "y"};

            string[] customFormats = {
                "yyyy MMMM dddd",
                "yyy MMM ddd",
                "yy MM dd",
                "y M d",
                "dd-MM-yy",
                "M/yy",
                "hh:mm:ss",
                "HH:mm:ss",
                "hh:m:s",
            };

            Console.WriteLine($".ToString( ) => {d.ToString()}");

            Console.WriteLine("============標準日時書式指定文字列============");
            foreach (var f in standardFormats)
            {
                Console.WriteLine($".ToString({f}) => {d.ToString(f)}");
            }

            Console.WriteLine("==========カスタム日時書式指定文字列==========");
            foreach (var f in customFormats)
            {
                Console.WriteLine($".ToString({f}) => {d.ToString(f)}");
            }
        }

        static void DbNullSample()
        {
            var cmdText = @"
select
    *
from
    社員CS
order by
    社員番号
";
            using var conn = new SqlConnection(GetConnectionString());
            conn.Open();

            //CreateCommand
            //using (var cmd = new SqlCommand(cmdText,conn))
            using var cmd = conn.CreateCommand();
            cmd.CommandText = cmdText;
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //FieldCount
                var values = new object?[reader.FieldCount];
                //GetValues
                reader.GetValues(values);

                var salary = values[2];

                //DBNull
                Console.WriteLine("======================");
                Console.WriteLine($"{values[1]?.ToString()?.Trim()}さんの給与");
                Console.WriteLine("----------------------");
                Console.WriteLine($@"GetType().FullName => {salary?.GetType().FullName}");
                Console.WriteLine($@"is int             => {salary is int}");
                Console.WriteLine($@"is Nullable<int>   => {salary is int?}");
                Console.WriteLine($@"== null            => {salary == null}");
                Console.WriteLine($@"?? 0               => {salary ?? 0}");
                Console.WriteLine($@"IsDBNull           => {Convert.IsDBNull(salary)}");
                Console.WriteLine($@"== DBNull.Value    => {salary == DBNull.Value}");
                Console.WriteLine($@"ToString           => {salary}");
                Console.WriteLine("======================");
            }
        }

        static string GetLessonFilePath()
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var fileName = "Lesson5.txt";
            return Path.Combine(folder, fileName);
        }

        static void Lesson5()
        {
            var cmdText = @"
select
    *
from
    社員CS
order by
    社員番号
";
            var dt = new DataTable();
            using (var ada = new SqlDataAdapter(cmdText, GetConnectionString()))
            {
                ada.Fill(dt);
            }

            using (var writer = new StreamWriter(GetLessonFilePath()))
            {

                //var colNames = new List<string>();
                //foreach (DataColumn dc in dt.Columns)
                //{
                //    colNames.Add(dc.ColumnName);
                //}
                //Console.WriteLine(string.Join(",",colNames));
                //writer.WriteLine(string.Join(",", colNames));

                var colNames = dt.Columns
                    .OfType<DataColumn>()
                    .Select(x => x.ColumnName)
                    .ToList();

                Console.WriteLine(string.Join(",", colNames));
                writer.WriteLine(string.Join(",", colNames));

                foreach (DataRow dr in dt.Rows)
                {
                    var values = new List<object?>();

                    foreach (var val in dr.ItemArray)
                    {
                        //if (val is DateTime d)
                        //{
                        //    values.Add(d.ToString("d"));
                        //}
                        //else
                        //{
                        //    values.Add(val);
                        //}
                        values.Add(val is DateTime d ? d.ToString("d") : val);
                    }
                    Console.WriteLine(string.Join(",", values));
                    writer.WriteLine(string.Join(",", values));
                }
            }
        }

        static void Demo5()
        {
            var cmdText = @"
select
    count(*)
from
    部門CS
";
            using var conn = new SqlConnection(GetConnectionString());
            conn.Open();
            using var cmd = new SqlCommand(cmdText, conn);
            Console.WriteLine(cmd.ExecuteScalar());
        }

        static void Lesson6()
        {
            Console.WriteLine("検索する社員の氏名を入力してください");
            Console.Write("> ");
            var name = Console.ReadLine();
            var cmdText = $@"
select
    count(*)
from
    社員CS
where
    氏名 = '{name}'
";
            using var conn = new SqlConnection(GetConnectionString());
            conn.Open();
            using var cmd = new SqlCommand(cmdText, conn);
            Console.WriteLine($"該当する社員は{cmd.ExecuteScalar()}名です。");
        }

        static void Lesson7()
        {
            Console.WriteLine("検索する社員の氏名を入力してください");
            Console.Write("> ");
            var name = Console.ReadLine();
            var cmdText = @"
select
    count(*)
from
    社員CS
where
    氏名 = @name
";
            using var conn = new SqlConnection(GetConnectionString());
            conn.Open();
            using var cmd = new SqlCommand(cmdText, conn);
            //パターンA
            cmd.Parameters.AddWithValue("@name", name);

            //パターンB
            //var param = new SqlParameter("@name", name);
            //cmd.Parameters.Add(param);

            //パターンC
            //cmd.Parameters.AddRange(
            //    new SqlParameter[]
            //    {
            //        new SqlParameter("@name",name),
            //        new SqlParameter("@p2",value2),
            //        new SqlParameter("@p3",value3),
            //        new SqlParameter("@p4",value4),
            //    }
            //    );
            Console.WriteLine($"該当する社員は{cmd.ExecuteScalar()}名です。");
        }

        static void Demo6()
        {
            var cmdText = @"
select
    *
from
    部門CS
order by
    部門番号
";
            var dt = new DataTable();
            using (var ada = new SqlDataAdapter(cmdText, GetConnectionString()))
            {
                ada.Fill(dt);

                //insert
                var newRow = dt.NewRow();
                newRow[0] = 40;
                newRow["部門名"] = "ITC04部";

                dt.Rows.Add(newRow);

                //update
                dt.Rows[1][1] = "ITC14部";

                //delete
                dt.Rows[2].Delete();

                var builder = new SqlCommandBuilder(ada);
                ada.InsertCommand = builder.GetInsertCommand();
                ada.UpdateCommand = builder.GetUpdateCommand();
                ada.DeleteCommand = builder.GetDeleteCommand();

                ada.Update(dt);
            }

            Console.WriteLine("処理が完了しました。");
        }

        static void Lesson8()
        {
            var cmdText = @"

select
    *
from
    社員CS
order by
    社員番号
";
            var dt = new DataTable();
            using (var ada = new SqlDataAdapter(cmdText, GetConnectionString()))
            {
                ada.Fill(dt);

                var newRow = dt.NewRow();
                newRow[0] = 12;
                newRow[1] = "齋藤宏樹";
                newRow[2] = 1000000;
                newRow[3] = DateTime.Today;
                newRow[4] = 20;
                newRow[5] = 1;

                dt.Rows.Add(newRow);

                var newRow2 = dt.NewRow();
                newRow2[0] = 13;
                newRow2[1] = "伊東遼";
                newRow2[2] = 1000000;
                newRow2[3] = DateTime.Today;
                newRow2[4] = 20;
                newRow2[5] = DBNull.Value;

                dt.Rows.Add(newRow2);

                var builder = new SqlCommandBuilder(ada);
                ada.InsertCommand = builder.GetInsertCommand();

                ada.Update(dt);
            }
            Console.WriteLine("処理が完了しました。");
        }

        static void Demo7()
        {
            var cmdText = @"

select
    *
from
    社員CS
order by
    社員番号
";
            var dt = new DataTable();
            using var ada = new SqlDataAdapter(cmdText, GetConnectionString());
            ada.Fill(dt);

            foreach (var dr in dt.AsEnumerable())
            {

                //var name = dr[1];
                var name = dr[1] as string;

                //var salary = (int?)dr[2
                //var salary = dr[2] as int?;
                var salary = dr.Field<int?>(2);

                var bonus = salary * 3;
                Console.WriteLine($"氏名:{name} ボーナス:{bonus}");
            }
        }

        static void Demo8()
        {
            var delText = @"
truncate table 
    部門CS
";

            var insText = @"
insert into
    部門CS
select
    *
from
    部門
";
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var tran = conn.BeginTransaction())
                using (var cmd = new SqlCommand(delText, conn, tran))
                {
                    //try
                    //{

                    cmd.ExecuteNonQuery();

                    //throw new DivideByZeroException();

                    cmd.CommandText = insText;
                    cmd.ExecuteNonQuery();

                    tran.Commit();

                    //}
                    //catch (Exception)
                    //{
                    //    tran.Rollback();
                    //    throw;
                    //}
                }
            }

            Console.WriteLine("処理が完了しました。");
        }

        static void Demo9()
        {
            //Console.WriteLine(Settings.Default["設定値1"]);
            //Console.WriteLine(Settings.Default["設定値2"]);
            ////error
            ////Console.WriteLine(Settings.Default["設定値99"]);
            //Console.WriteLine(Settings.Default["DefaultConnectionString"]);
        }

        static void Demo10()
        {
            //var itemName = "DefaultConnectionString";
            //var connStrSetting = ConfigurationManager<>.ConnectionStrings[itemName];
            //Console.WriteLine(connStrSetting.ConnectionString);
            //Console.WriteLine(connStrSetting.ProviderName);

            //Console.WriteLine(ConfigurationManager.AppSettings["Sample1"]);
            //Console.WriteLine(ConfigurationManager.AppSettings["Sample2"]);
            ////null
            ////Console.WriteLine(ConfigurationManager.AppSettings["Sample99"]);
        }

        static void Demo11()
        {
            //                var itemName = "DefaultConnectionString";
            //                var connStrSetting = ConfigurationManager.ConnectionStrings[itemName];

            //                var cmdText = @"
            //select
            //    count(*)
            //from
            //    社員CS
            //";
            //                var factory = DbProviderFactories.GetFactory(connStrSetting.ProviderName);

            //                using (var conn = factory.CreateConnection())
            //                {
            //                    conn.ConnectionString = connStrSetting.ConnectionString;
            //                    conn.Open();
            //                    using (var cmd = conn.CreateCommand())
            //                    {
            //                        cmd.CommandText = cmdText;
            //                        Console.WriteLine($"社員は{cmd.ExecuteScalar()}人います。");
            //                    }
            //                }
        }

        static void Main()
        {
            Lesson1();
            Demo1();
            Lesson2();
            Demo2();
            Lesson3();
            Demo3();
            Lesson4();
            Demo4();
            DataTimeFormatStringsSample();
            Lesson5();
            DbNullSample();
            Demo5();
            Lesson6();
            Lesson7();
            Demo6();
            Lesson8();
            Demo7();
            Demo8();
            Demo9();
            Demo10();
            Demo11();
        }
    }
}