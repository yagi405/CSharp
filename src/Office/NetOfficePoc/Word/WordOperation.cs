using System;
using System.IO;
using NetOffice.WordApi;

namespace NetOfficePoc.Word
{
    public class WordOperation : IDisposable
    {
        private readonly WordOperationContext _context;

        public WordOperation()
        {
            _context = new WordOperationContext();
        }

        public Document OpenDocument(string filePath)
        {
            return _context.OpenDocument(Path.GetFullPath(filePath));
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
