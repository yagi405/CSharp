using System;
using NetOffice.ExcelApi;
using NetOffice.ExcelApi.Tools.Contribution;

namespace NetOfficePoc.Excel
{
    public class ExcelOperation : IDisposable
    {
        private readonly ExcelOperationContext _context;
        public CommonUtils Utils { get; }

        public ExcelOperation()
        {
            _context = new ExcelOperationContext();
            Utils = new CommonUtils(_context.Application);
            InitializeApplication(_context);
        }

        public Workbook NewWorkbook()
        {
            return _context.NewWorkbook();
        }

        public Workbook OpenWorkBook(string filePath, bool isReadOnly = false)
        {
            return _context.OpenWorkBook(filePath, isReadOnly);
        }

        public Workbook OpenTemplateWorkbook(string filePath)
        {
            return _context.OpenTemplateWorkbook(filePath);
        }

        public void InitializeApplication(ExcelOperationContext context)
        {
            context.Application.Visible = false;
            context.Application.DisplayAlerts = false;
        }

        public void PutSampleData(_Worksheet sheet)
        {
            sheet.Cells[2, 2].Value = "Date";
            sheet.Cells[3, 2].Value = DateTime.Today;
            sheet.Cells[4, 2].Value = DateTime.Today.AddDays(1);
            sheet.Cells[5, 2].Value = DateTime.Today.AddDays(2);
            sheet.Cells[6, 2].Value = DateTime.Today.AddDays(3);

            sheet.Cells[2, 3].Value = "Columns1";
            sheet.Cells[3, 3].Value = 10;
            sheet.Cells[4, 3].Value = 20;
            sheet.Cells[5, 3].Value = 30;
            sheet.Cells[6, 3].Value = 40;

            sheet.Cells[2, 4].Value = "Column2";
            sheet.Cells[3, 4].Value = 100;
            sheet.Cells[4, 4].Value = 200;
            sheet.Cells[5, 4].Value = 300;
            sheet.Cells[6, 4].Value = 400;

            sheet.Cells[2, 5].Value = "Column3";
            sheet.Cells[3, 5].Value = 1;
            sheet.Cells[4, 5].Value = 2;
            sheet.Cells[5, 5].Value = 3;
            sheet.Cells[6, 5].Value = 4;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            Utils?.Dispose();
            _context?.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
