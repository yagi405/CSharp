using System.Collections.Generic;

namespace NetOfficePoc.Outlook
{
    public class MailItemContext
    {
        public List<string> Recipients { get; set; }

        public List<string> Cc { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public MailItemContext()
        {
            Recipients = new List<string>();
            Cc = new List<string>();
        }
    }
}
