using System;
using System.Drawing;
using System.IO;
using NetOffice.ExcelApi.Enums;
using NetOffice.ExcelApi.Tools.Contribution;
using Excel = NetOffice.ExcelApi;

namespace NetOfficePoc
{
    public static class ExcelSample
    {
        public static void ShapeSample()
        {
            using (var app = new Excel.Application())
            using (var utils = new CommonUtils(app))
            {
                app.DisplayAlerts = false;
                using (var book = app.Workbooks.Add())
                using (var sheet = book.Worksheets[1] as Excel.Worksheet)
                {
                    if (sheet is null)
                    {
                        return;
                    }
                    sheet.Range("$B2:$B5").Interior.Color = utils.Color.ToDouble(Color.DarkGreen);
                    sheet.Range("$B2:$B5").BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);


                    sheet.Range("$D2:$D5").Interior.Color = utils.Color.ToDouble(Color.DarkGreen);
                    sheet.Range("$D2:$D5").Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlDouble;
                    sheet.Range("$D2:$D5").Borders[XlBordersIndex.xlInsideHorizontal].Weight = 4;
                    sheet.Range("$D2:$D5").Borders[XlBordersIndex.xlInsideHorizontal].Color = utils.Color.ToDouble(Color.Black);

                    sheet.Cells[1, 1].Value = "We have 2 simple shapes created";

                    book.SaveAs(Path.Combine(Environment.CurrentDirectory, $"{nameof(ShapeSample)}.xlsx"));

                    app.Quit();
                }
            }
        }

        public static void ChartSample()
        {
            using (var app = new Excel.Application())
            {
                app.DisplayAlerts = false;

                using (var book = app.Workbooks.Add())
                using (var sheet = (Excel.Worksheet)book.Worksheets[1])
                using (var range = PutSampleData(sheet))
                using (var chart = ((Excel.ChartObjects)sheet.ChartObjects()).Add(70, 100, 375, 225))
                {
                    chart.Chart.SetSourceData(range);
                    book.SaveAs(Path.Combine(Environment.CurrentDirectory, $"{nameof(ChartSample)}.xlsx"));
                    app.Quit();
                }
            }
        }

        public static void ChartCopySample()
        {
            using (var app = new Excel.Application())
            {
                app.DisplayAlerts = false;

                using (var book = app.Workbooks.Add())
                using (var sheet = (Excel.Worksheet)book.Worksheets[1])
                using (var range = PutSampleData(sheet))
                using (var chart = ((Excel.ChartObjects)sheet.ChartObjects()).Add(70, 100, 375, 225))
                {
                    chart.Chart.SetSourceData(range);
                    //chart.Copy();
                    chart.CopyPicture();
                    book.SaveAs(Path.Combine(Environment.CurrentDirectory, $"{nameof(ChartCopySample)}.xlsx"));
                    app.Quit();
                }
            }
        }

        private static Excel.Range PutSampleData(Excel.Worksheet sheet)
        {
            sheet.Cells[2, 2].Value = "Date";
            sheet.Cells[3, 2].Value = DateTime.Now.ToShortDateString();
            sheet.Cells[4, 2].Value = DateTime.Now.ToShortDateString();
            sheet.Cells[5, 2].Value = DateTime.Now.ToShortDateString();
            sheet.Cells[6, 2].Value = DateTime.Now.ToShortDateString();

            sheet.Cells[2, 3].Value = "Columns1";
            sheet.Cells[3, 3].Value = 25;
            sheet.Cells[4, 3].Value = 33;
            sheet.Cells[5, 3].Value = 30;
            sheet.Cells[6, 3].Value = 22;

            sheet.Cells[2, 4].Value = "Column2";
            sheet.Cells[3, 4].Value = 25;
            sheet.Cells[4, 4].Value = 33;
            sheet.Cells[5, 4].Value = 30;
            sheet.Cells[6, 4].Value = 22;

            sheet.Cells[2, 5].Value = "Column3";
            sheet.Cells[3, 5].Value = 25;
            sheet.Cells[4, 5].Value = 33;
            sheet.Cells[5, 5].Value = 30;
            sheet.Cells[6, 5].Value = 22;

            return sheet.Range("$B2:$E6");
        }


    }
}
