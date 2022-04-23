using System;
using System.IO;
using NetOffice.DAOApi;

namespace NetOfficePoc.Access
{
    public class AccessOperation : IDisposable
    {
        private readonly AccessOperationContext _context;

        public AccessOperation()
        {
            _context = new AccessOperationContext();
        }

        public Database NewDatabase(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return _context.NewDatabase(filePath);
        }

        public void CompactDatabase(string srcFilePath, string destFilePath)
        {
            if (File.Exists(destFilePath))
            {
                File.Delete(destFilePath);
            }
            _context.CompactDatabase(srcFilePath, destFilePath);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
