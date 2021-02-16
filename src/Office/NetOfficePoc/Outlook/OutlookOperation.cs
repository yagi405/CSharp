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
