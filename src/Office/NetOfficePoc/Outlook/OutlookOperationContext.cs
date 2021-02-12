using System;
using NetOffice.OutlookApi;

namespace NetOfficePoc.Outlook
{
    public class OutlookOperationContext : IDisposable
    {
        public Application Application { get; }

        public OutlookOperationContext()
        {
            Application = new Application();
        }

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
                Application?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~OutlookOperationContext()
        {
            Dispose(false);
        }
    }
}
