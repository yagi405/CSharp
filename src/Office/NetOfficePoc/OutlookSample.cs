using System;
using System.IO;
using System.Linq;
using NetOffice.OutlookApi.Enums;
using Outlook = NetOffice.OutlookApi;

namespace NetOfficePoc
{
    public static class OutlookSample
    {
        public static void CreateDraftSample()
        {
            using (var app = new Outlook.Application())
            using (var item = (Outlook.MailItem)app.CreateItem(OlItemType.olMailItem))
            {
                item.Subject = "SampleSubject";
                item.Body = "SampleBody";
                item.Save();
            }
        }

        public static void GetInboxItemsSample()
        {
            using (var app = new Outlook.Application())
            {
                var inbox = app.Application.Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
                var itemsCount = inbox.Items.Count;

                //inbox.Folders["hoge"].Items
                var items = inbox.Items.OfType<Outlook.MailItem>().ToList();
                if (!items.Any())
                {
                    return;
                }

                var first = items.First();
                first.SaveAs(Path.Combine(Environment.CurrentDirectory, $"{first.Subject}.msg"));

                foreach (var item in items)
                {
                    Console.WriteLine(item.Subject);
                }
            }
        }

        public static void GetAttachedFileSample()
        {
            using (var app = new Outlook.Application())
            {
                var inbox = app.Application.Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
                var items = inbox.Items.OfType<Outlook.MailItem>();
                foreach (var item in items)
                {
                    if (item.Attachments is null || !item.Attachments.Any())
                    {
                        continue;
                    }

                    var attachments = item.Attachments;

                    var first = attachments.First();
                    first.SaveAsFile(Path.Combine(Environment.CurrentDirectory, first.FileName));

                    foreach (var a in attachments)
                    {
                        Console.WriteLine(a.FileName);
                    }

                    Console.WriteLine(item.Subject);
                    return;
                }
            }
        }
    }
}
