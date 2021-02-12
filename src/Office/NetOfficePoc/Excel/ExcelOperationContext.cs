using System;
using System.Collections.Generic;
using System.IO;
using NetOffice.ExcelApi;

namespace NetOfficePoc.Excel
{
    public class ExcelOperationContext : IDisposable
    {
        public Application Application { get; }

        public Workbooks Workbooks { get; }

        private readonly List<string> _tempFilePath;

        public ExcelOperationContext()
        {
            Application = new Application();
            Workbooks = Application.Workbooks;
            _tempFilePath = new List<string>();
        }

        public Workbook NewWorkbook()
        {
            return Workbooks.Add();
        }

        public Workbook OpenWorkBook(string filePath, bool isReadOnly)
        {
            return Workbooks.Open(Path.GetFullPath(filePath), false, isReadOnly);
        }

        public Workbook OpenTemplateWorkbook(string filePath)
        {
            var tempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.{Path.GetExtension(filePath)}");
            File.Copy(filePath, tempPath);
            _tempFilePath.Add(tempPath);
            return OpenWorkBook(tempPath, false);
        }

        private void ReleaseUnmanagedResources()
        {
            foreach (var tempFilePath in _tempFilePath)
            {
                try
                {
                    File.Delete(tempFilePath);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            _tempFilePath.Clear();
        }

        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (!disposing)
            {
                return;
            }

            Workbooks?.Close();
            Workbooks?.Dispose();

            Application?.Quit();
            Application?.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ExcelOperationContext()
        {
            Dispose(false);
        }
    }
}