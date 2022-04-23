using System;
using System.IO;
using Anotar.Serilog;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace SerilogPoc.DotNetFramework
{
    public class Program
    {
        private static void Main()
        {
            //https://github.com/serilog/serilog/wiki/Getting-Started

            HelloWorld();
            ReadFromAppSettingsSample();
            ReadFromSerilogJsonSample();
            Console.WriteLine("done!");
            Console.ReadKey();
        }

        private static void HelloWorld()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(@"Logs\hello.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            SampleMethod();
        }

        private static void ReadFromAppSettingsSample()
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom
                .AppSettings()
                .CreateLogger();

            SampleMethod();
        }

        private static void ReadFromSerilogJsonSample()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("serilog.json", false, true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            SampleMethod();
        }

        private static void SampleMethod()
        {
            LogTo.Debug("Hello World!");

            var p = new Person() { Name = "Saito", Age = 29 };
            LogTo.Information("p => {@saito}", p);

            // ReSharper disable once ConvertToConstant.Local
            var a = 10;
            // ReSharper disable once ConvertToConstant.Local
            var b = 0;
            try
            {
                LogTo.Debug($"Dividing {a} by {b}");
                // ReSharper disable once IntDivisionByZero
                Console.WriteLine(a / b);
            }
            catch (Exception ex)
            {
                LogTo.Error(ex, "Something went wrong");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
