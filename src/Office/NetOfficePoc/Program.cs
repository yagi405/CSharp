using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using NetOffice.ExcelApi;
using NetOffice.ExcelApi.Enums;
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

                //CopyRange
                srcSheet.Range("$B2:$E6").Copy(destSheet.Range("B2"));

                //AddChart
                var chart = ((ChartObjects)destSheet.ChartObjects()).Add(70, 100, 375, 225);
                chart.Chart.SetSourceData(destSheet.Range("$B2:$E6"));

                //Protect
                excelOperation.ProtectWorkSheet(destSheet,"password");

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
                presentation.SaveAs(Path.Combine(Environment.CurrentDirectory, "sample.pptx"));
            }
        }

        private static void OutlookSample()
        {
            using (var outlookOperation = new OutlookOperation())
            {
                //CreateMailItemAsDraft
                outlookOperation.CreateMailItemAsDraft(
                    new MailItemContext
                    {
                        Recipients = new List<string> { "SampleRecipient" },
                        Cc = new List<string> { "SampleCC" },
                        Subject = "SampleSubject",
                        Body = "SampleBody",
                    }
                    );

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

                //SaveItem
                if (mailItems.Any())
                {
                    outlookOperation.SaveItem(mailItems.First());
                }

                //SaveAttachments
                var itemWithAttachments = mailItems.FirstOrDefault(x => x.Attachments.Any());
                if (itemWithAttachments != null)
                {
                    outlookOperation.SaveAttachments(itemWithAttachments);
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
