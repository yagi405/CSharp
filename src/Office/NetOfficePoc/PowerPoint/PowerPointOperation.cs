using System;
using NetOffice.PowerPointApi;

namespace NetOfficePoc.PowerPoint
{
    public class PowerPointOperation:IDisposable
    {
        private readonly PowerPointOperationContext _context;

        public PowerPointOperation()
        {
            _context = new PowerPointOperationContext();
        }

        public Presentation NewPresentation()
        {
            return _context.NewPresentation();
        }

        public Presentation OpenPresentation(string filePath, bool isReadOnly = false)
        {
            return _context.OpenPresentation(filePath, isReadOnly);
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
