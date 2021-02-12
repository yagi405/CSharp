using System;
using System.IO;
using NetOffice.PowerPointApi;

namespace NetOfficePoc.PowerPoint
{
    public class PowerPointOperationContext : IDisposable
    {
        public Application Application { get; }

        public Presentations Presentations { get; set; }

        public PowerPointOperationContext()
        {
            Application = new Application();
            Presentations = Application.Presentations;
        }

        public Presentation NewPresentation()
        {
            return Presentations.Add(false);
        }

        public Presentation OpenPresentation(string filePath, bool isReadOnly)
        {
            return Presentations.Open(Path.GetFullPath(filePath), isReadOnly, false, false);
        }

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
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
