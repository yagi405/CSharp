using System;
using System.Collections.Generic;
using System.Linq;
using NetOffice.OutlookApi;
using NetOffice.OutlookApi.Enums;

namespace NetOfficePoc.Outlook
{
    public class OutlookOperation : IDisposable
    {
        //https://docs.microsoft.com/ja-jp/office/client-developer/outlook/outlook-home

        private readonly OutlookOperationContext _context;

        public OutlookOperation()
        {
            _context = new OutlookOperationContext();
        }

        public MailItem CreateMailItem(MailItemContext mailItemContext)
        {
            var item = (MailItem)_context.Application.CreateItem(OlItemType.olMailItem);
            foreach (var recipient in mailItemContext.Recipients)
            {
                item.Recipients.Add(recipient);
            }
            item.CC = string.Join(";", mailItemContext.Cc);
            item.Subject = mailItemContext.Subject;
            item.Body = mailItemContext.Body;
            return item;
        }

        public MailItem CreateMailItemFromTemplate(string templateFilePath)
        {
            var item = (MailItem)_context.Application.CreateItemFromTemplate(templateFilePath);
            return item;
        }

        public IEnumerable<MAPIFolder> EnumerateFolders(MAPIFolder folder)
        {
            yield return folder;

            var childFolders = folder.Folders;
            if (childFolders.Count <= 0)
            {
                yield break;
            }

            foreach (var childFolder in childFolders)
            {
                var subFolders = EnumerateFolders(childFolder);
                foreach (var subFolder in subFolders)
                {
                    yield return subFolder;
                }
            }
        }

        public IEnumerable<MailItem> EnumerateMailItems(MAPIFolder folder)
        {
            return folder.Items.OfType<MailItem>();
        }

        public IEnumerable<MailItem> EnumerateInboxMailItems()
        {
            return EnumerateMailItems(GetInboxFolder());
        }

        public MAPIFolder GetInboxFolder()
        {
            return _context.Application.Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
        }

        public MAPIFolder GetRootFolder()
        {
            return _context.Application.Session.DefaultStore.GetRootFolder();
        }

        //https://docs.microsoft.com/ja-jp/office/client-developer/outlook/pia/search-and-filter

        public IEnumerable<MailItem> EnumerateMailItems(MAPIFolder folder, string subject, string body)
        {
            //DAV Searching and Locating (DASL) 構文
            //https://docs.microsoft.com/ja-jp/office/client-developer/outlook/pia/how-to-use-instant-search-to-search-all-folders-and-all-stores-for-a-phrase-in-the-subject
            //JET VS DASL
            //https://docs.microsoft.com/ja-jp/office/vba/outlook/how-to/search-and-filter/filtering-items

            var filter = "";
            if (!string.IsNullOrEmpty(subject) || !string.IsNullOrEmpty(body))
            {
                filter = @"@SQL=""urn:schemas:httpmail:";

                if (!string.IsNullOrEmpty(subject))
                {
                    //既定のストアでクイック検索が有効になっているか
                    filter += _context.Application.Session.DefaultStore.IsInstantSearchEnabled
                        ? $@"subject"" ci_startswith '{subject}'"
                        : $@"subject"" LIKE '%{subject}%'";
                }

                if (!string.IsNullOrEmpty(body))
                {
                    if (!string.IsNullOrEmpty(subject))
                    {
                        filter += @" OR ""urn:schemas:httpmail:";
                    }
                    filter += _context.Application.Session.DefaultStore.IsInstantSearchEnabled
                    ? $@"textdescription"" ci_phrasematch '{body}'"
                    : $@"textdescription"" LIKE '%{body}%'";
                }
            }

            /*
            //受信日時によるフィルター例
            //https://docs.microsoft.com/ja-jp/office/vba/outlook/how-to/search-and-filter/filtering-items-using-a-date-time-comparison
            //DASL クエリによる DateTime 比較は常に協定世界時 (UTC) で行われるので、現地時刻を UTC に変換する必要がある
            //さらに、 DateTime 値を文字列表現に変換する必要もある。
            var received = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).ToString("g");
            var filter = $@"@SQL=(""urn:schemas:httpmail:subject"" LIKE '%{subject}%' AND ""urn:schemas:httpmail:datereceived"" <= '{received}')";
            */

            /*
            //添付ファイルによるフィルター例
            var filter = "@SQL= urn:schemas:httpmail:hasattachment = True";
            */

            //アイテム数が少ない場合はFindがパフォーマンス有利
            var items = folder.Items.Restrict(filter)
                .OfType<MailItem>()
                .ToList();

            return items;
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
