using System;
using System.Collections.Generic;
using System.Linq;
using NetOffice.PowerPointApi;

namespace NetOfficePoc.PowerPoint
{
    public class PowerPointOperation : IDisposable
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

        public Presentation OpenTemplatePresentation(string filePath)
        {
            return _context.OpenTemplatePresentation(filePath);
        }

        public Presentation MergePresentations(IEnumerable<string> srcFilePath)
        {
            var mergedPresentation = NewPresentation();

            foreach (var filePath in srcFilePath.Reverse())
            {
                mergedPresentation.Slides.InsertFromFile(filePath, 0);
            }
            return mergedPresentation;
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
