using System;
using System.Collections.Generic;
using System.IO;
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

        public void CreateMailItemAsDraft(MailItemContext mailItemContext)
        {
            var item = (MailItem)_context.Application.CreateItem(OlItemType.olMailItem);
            foreach (var recipient in mailItemContext.Recipients)
            {
                item.Recipients.Add(recipient);
            }
            item.CC = string.Join(";", mailItemContext.Cc);
            item.Subject = mailItemContext.Subject;
            item.Body = mailItemContext.Body;
            item.Save();
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
            var inbox = GetInboxFolder();
            return inbox.Items.OfType<MailItem>();
        }


        public void SaveItem(MailItem mailItem)
        {
            mailItem.SaveAs(Path.Combine(Environment.CurrentDirectory, $@"{mailItem.Subject}.msg"));
        }

        public void SaveAttachments(MailItem mailItem)
        {
            var attachments = mailItem.Attachments;
            foreach (var attachment in attachments)
            {
                attachment.SaveAsFile(Path.Combine(Environment.CurrentDirectory, $@"{attachment.FileName}"));
            }
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
