using System;
using System.Collections.Generic;
using System.IO;
using NetOffice.PowerPointApi;

namespace NetOfficePoc.PowerPoint
{
    public class PowerPointOperationContext : IDisposable
    {
        public Application Application { get; }

        public Presentations Presentations { get; set; }

        private readonly List<string> _tempFilePath;

        public PowerPointOperationContext()
        {
            Application = new Application();
            Presentations = Application.Presentations;
            _tempFilePath = new List<string>();
        }

        public Presentation NewPresentation()
        {
            return Presentations.Add(false);
        }

        public Presentation OpenPresentation(string filePath, bool isReadOnly)
        {
            return Presentations.Open(Path.GetFullPath(filePath), isReadOnly, false, false);
        }

        public Presentation OpenTemplatePresentation(string filePath)
        {
            var tempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.{Path.GetExtension(filePath)}");
            File.Copy(filePath, tempPath);
            _tempFilePath.Add(tempPath);
            return OpenPresentation(tempPath, false);
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
            Presentations?.Dispose();
            Application?.Quit();
            Application?.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~PowerPointOperationContext()
        {
            Dispose(false);
        }
    }
}
