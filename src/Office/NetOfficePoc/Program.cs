using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using NetOffice.ExcelApi;
using NetOffice.ExcelApi.Enums;
using NetOffice.OfficeApi.Enums;
using NetOffice.PowerPointApi;
using NetOffice.PowerPointApi.Enums;
using NetOfficePoc.Access;
using NetOfficePoc.Db;
using NetOfficePoc.Excel;
using NetOfficePoc.Outlook;
using NetOfficePoc.PowerPoint;

namespace NetOfficePoc
{
    public class Program
    {
        private static void Main()
        {
            Console.WriteLine("Excel");
            ExcelSample();
            Console.WriteLine("PowerPoint");
            PowerPointSample();
            Console.WriteLine("Outlook");
            OutlookSample();
            Console.WriteLine("Access");
            AccessSample();
            Console.WriteLine("done!");
            Console.ReadKey();
        }

        private static void ExcelSample()
        {
            using (var excelOperation = new ExcelOperation())
            {
                //NewWorkbook
                var srcBook = excelOperation.NewWorkbook();
                var sheet = (Worksheet)srcBook.Worksheets.First();

                //Shape
                sheet.Range("$B2:$B5").Interior.Color = excelOperation.Utils.Color.ToDouble(Color.DarkGreen);
                sheet.Range("$B2:$B5").BorderAround(
                    NetOffice.ExcelApi.Enums.XlLineStyle.xlContinuous,
                    NetOffice.ExcelApi.Enums.XlBorderWeight.xlMedium,
                    NetOffice.ExcelApi.Enums.XlColorIndex.xlColorIndexAutomatic
                    );

                sheet.Range("$D2:$D5").Interior.Color = excelOperation.Utils.Color.ToDouble(Color.DarkGreen);
                sheet.Range("$D2:$D5").Borders[XlBordersIndex.xlInsideHorizontal].LineStyle =
                    NetOffice.ExcelApi.Enums.XlLineStyle.xlDouble;
                sheet.Range("$D2:$D5").Borders[XlBordersIndex.xlInsideHorizontal].Weight = 4;
                sheet.Range("$D2:$D5").Borders[XlBordersIndex.xlInsideHorizontal].Color =
                    excelOperation.Utils.Color.ToDouble(Color.Black);

                //AddWorkSheet
                var srcSheet = (Worksheet)srcBook.Worksheets.Add();
                excelOperation.PutSampleData(srcSheet);
                srcBook.SaveAs(Path.Combine(Environment.CurrentDirectory, "src.xlsx"));

                var destBook = excelOperation.NewWorkbook();
                var destSheet = (Worksheet)destBook.Worksheets.First();

                //RenameSheet
                destSheet.Name = "dest";

                //CopyRange
                srcSheet.Range("$B2:$E6").Copy(destSheet.Range("B2"));

                //AddChart
                var chart = ((ChartObjects)destSheet.ChartObjects()).Add(70, 100, 375, 225);
                chart.Chart.SetSourceData(destSheet.Range("$B2:$E6"));

                //Protect
                excelOperation.ProtectWorkSheet(destSheet, "password");

                destBook.SaveAs(Path.Combine(Environment.CurrentDirectory, "dest.xlsx"));
            }
        }

        private static void PowerPointSample()
        {
            using (var powerPointOperation = new PowerPointOperation())
            using (var excelOperation = new ExcelOperation())
            {
                //OpenWorkBook
                var srcBook = excelOperation.OpenWorkBook("dest.xlsx");
                var srcSheet = (Worksheet)srcBook.Worksheets.First();
                var chart = (ChartObject)((ChartObjects)srcSheet.ChartObjects()).First();

                //Unprotect
                excelOperation.UnprotectWorkSheet(srcSheet, "password");
                srcBook.Save();

                //CopyChart
                chart.CopyPicture();

                //PasteChart
                var presentation = powerPointOperation.NewPresentation();
                var slide = presentation.Slides.Add(1, PpSlideLayout.ppLayoutClipArtAndVerticalText);
                slide.Shapes.Paste();

                foreach (var shape in slide.Shapes)
                {
                    if (shape.HasTextFrame != MsoTriState.msoTrue)
                    {
                        continue;
                    }
                    shape.TextFrame.TextRange.Text = "**TIME";
                    break;
                }
                presentation.SaveAs(Path.Combine(Environment.CurrentDirectory, "src.pptx"));
            }

            using (var powerPointOperation = new PowerPointOperation())
            {
                var presentation = powerPointOperation
                    .OpenTemplatePresentation(Path.Combine(Environment.CurrentDirectory, "src.pptx"));

                var slide = (Slide)presentation.Slides.First();

                foreach (var shape in slide.Shapes)
                {
                    if (shape.HasTextFrame != MsoTriState.msoTrue)
                    {
                        continue;
                    }

                    shape.TextFrame.TextRange.Text =
                        shape.TextFrame.TextRange.Text == "**TIME"
                            ? DateTime.Now.ToLongTimeString()
                            : "Hello World!";
                }

                presentation.Slides.Add(2, PpSlideLayout.ppLayoutBlank);
                presentation.Slides.Add(3, PpSlideLayout.ppLayoutText);

                presentation.SaveAs(Path.Combine(Environment.CurrentDirectory, "dest.pptx"));
            }

            using (var powerPointOperation = new PowerPointOperation())
            {
                var mergedPresentation = powerPointOperation.MergePresentations(
                    new[]
                    {
                        Path.Combine(Environment.CurrentDirectory, "src.pptx"),
                        Path.Combine(Environment.CurrentDirectory, "dest.pptx")
                    });

                mergedPresentation.SaveAs(Path.Combine(Environment.CurrentDirectory, "merged.pptx"));
            }
        }

        private static void OutlookSample()
        {
            using (var outlookOperation = new OutlookOperation())
            {
                //CreateMailItemAsDraft
                var draftMailItem = outlookOperation.CreateMailItem(
                    new MailItemContext
                    {
                        Recipients = new List<string> { "SampleRecipient" },
                        Cc = new List<string> { "SampleCC" },
                        Subject = "SampleSubject",
                        Body = "SampleBody",
                    }
                    );

                draftMailItem.Save();

                //PrintFolders
                var root = outlookOperation.GetRootFolder();
                foreach (var folder in outlookOperation.EnumerateFolders(root))
                {
                    Console.WriteLine(folder.FullFolderPath);
                }

                //PrintInboxMailItems
                var mailItems = outlookOperation.EnumerateInboxMailItems().Take(20).ToList();
                foreach (var mailItem in mailItems)
                {
                    Console.WriteLine(mailItem.Subject);
                }

                var itemWithAttachments = mailItems.FirstOrDefault(x => x.Attachments.Any());
                if (itemWithAttachments == null)
                {
                    return;
                }

                //SaveItem
                var filePath = Path.Combine(Environment.CurrentDirectory, "sample.msg");
                itemWithAttachments.SaveAs(filePath);

                //SaveAttachments
                var attachments = itemWithAttachments.Attachments;
                foreach (var attachment in attachments)
                {
                    attachment.SaveAsFile(Path.Combine(Environment.CurrentDirectory, $@"{attachment.FileName}"));
                }

                //CreateMailItemAsDraft FromTemplate
                var draftMailItemFromTemplate = outlookOperation.CreateMailItemFromTemplate(filePath);

                var recipientsCount = draftMailItemFromTemplate.Recipients.Count;
                for (var i = 0; i < recipientsCount; i++)
                {
                    draftMailItemFromTemplate.Recipients.Remove(1);
                }
                draftMailItemFromTemplate.CC = "";

                var attachmentsCount = draftMailItemFromTemplate.Attachments.Count;
                for (var i = 0; i < attachmentsCount; i++)
                {
                    draftMailItemFromTemplate.Attachments.Remove(1);
                }

                //AddAttachment
                draftMailItemFromTemplate.Attachments.Add(Path.Combine(Environment.CurrentDirectory, "merged.pptx"));

                draftMailItemFromTemplate.Save();

                //FindBySubjectAndBody
                mailItems.Clear();
                mailItems = outlookOperation.EnumerateMailItems(outlookOperation.GetInboxFolder(), "ベネ・ステ", "ベネ・ステ").ToList();
                foreach (var mailItem in mailItems)
                {
                    Console.WriteLine(mailItem.Subject);
                }
            }
        }

        private static void AccessSample()
        {
            using (var accessOperation = new AccessOperation())
            {
                //NewDatabase
                var filePath = Path.Combine(Environment.CurrentDirectory, "sample.accdb");
                accessOperation.NewDatabase(filePath);
            }

            using (var conn = DbConnectionFactory.Default.CreateConnection())
            {
                var service = new SampleService(conn);
                //CreateDatabase
                service.CreateTable();
                //AddSampleData
                service.AddSampleData();
            }

            using (var conn = DbConnectionFactory.Default.CreateConnection())
            {
                var service = new SampleService(conn);

                //GetAll
                var records = service.GetAll();
                foreach (var r in records)
                {
                    Console.WriteLine(string.Join(" - ", r.Column1, r.Column2));
                }

                Console.WriteLine("===============================");

                //GetById
                var record = service.GetById("2");
                Console.WriteLine(string.Join(" - ", record.Column1, record.Column2));
            }

            //using (var conn = DbConnectionFactory.Default.CreateConnection())
            //using (var tran = conn.BeginTransaction())
            //{
            //    try
            //    {
            //        var service = new SampleService(conn);

            //        service.CreateTable();
            //        service.AddSampleData();
            //        tran.Commit();
            //    }
            //    catch (Exception)
            //    {
            //        tran.Rollback();
            //        throw;
            //    }
            //}

        }

    }
}
