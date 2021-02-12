using System;
using NetOffice.AccessApi;
using NetOffice.AccessApi.Enums;
using NetOffice.DAOApi;
using NetOffice.DAOApi.Constants;

namespace NetOfficePoc.Access
{
    public class AccessOperationContext : IDisposable
    {
        public Application Application { get; }

        public AccessOperationContext()
        {
            Application = new Application();
        }

        public Database NewDatabase(string filePath)
        {
            return Application.DBEngine.Workspaces[0].CreateDatabase(filePath, LanguageConstants.dbLangGeneral);
        }

        public void CompactDatabase(string srcFilePath, string destFilePath)
        {
            Application.DBEngine.CompactDatabase(srcFilePath, destFilePath);
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
            Application?.Quit(AcQuitOption.acQuitSaveAll);
            Application?.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~AccessOperationContext()
        {
            Dispose(false);
        }
    }
}
