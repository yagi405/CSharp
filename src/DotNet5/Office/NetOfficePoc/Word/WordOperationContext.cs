using System;
using NetOffice.WordApi;

namespace NetOfficePoc.Word
{
    public class WordOperationContext : IDisposable
    {
        public Application Application { get; }

        public Documents Documents { get; }

        public WordOperationContext()
        {
            Application = new Application();
            Documents = Application.Documents;
        }

        public Document OpenDocument(string filePath)
        {
            return Documents.Open(filePath);
        }

        public void Dispose()
        {
            Application.Quit();
            Application?.Dispose();
            Documents?.Dispose();
        }
    }
}
