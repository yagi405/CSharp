using System;
using System.IO;
using NetOffice.OfficeApi.Enums;
using NetOffice.PowerPointApi.Enums;
using PowerPoint = NetOffice.PowerPointApi;

namespace NetOfficePoc
{
    public static class PowerPointSample
    {
        public static void CreateSlideSample()
        {
            using (var app = new PowerPoint.Application())
            using (var presentation = app.Presentations.Add(MsoTriState.msoFalse))
            using (var _ = presentation.Slides.Add(1, PpSlideLayout.ppLayoutClipArtAndVerticalText))
            {
                presentation.SaveAs(Path.Combine(Environment.CurrentDirectory, $"{nameof(CreateSlideSample)}.pptx"));
                app.Quit();
            }
        }

        public static void PasteChartOnClipBoardIntoSlide()
        {
            ExcelSample.ChartCopySample();

            using (var app = new PowerPoint.Application())
            using (var presentation = app.Presentations.Add(MsoTriState.msoFalse))
            using (var slide = presentation.Slides.Add(1, PpSlideLayout.ppLayoutClipArtAndVerticalText))
            {
                slide.Shapes.Paste();
                presentation.SaveAs(Path.Combine(Environment.CurrentDirectory, $"{nameof(CreateSlideSample)}.pptx"));
                app.Quit();
            }
        }
    }
}
