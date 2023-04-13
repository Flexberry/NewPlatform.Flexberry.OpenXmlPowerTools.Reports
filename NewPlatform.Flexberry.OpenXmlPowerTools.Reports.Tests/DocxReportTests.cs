using NewPlatform.Flexberry.Reports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace NewPlatform.Flexberry.OpenXmlPowerTools.Reports.Tests
{
    public class DocxReportTests
    {
        /// <summary>
        /// Тест создания DocxReport и проверка блокироует ли он файл.
        /// </summary>
        [Fact]
        public void DocxReport_SaveAs_Then_FileOpen()
        {
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files\\tmp.docx");
            var fileNameToSave = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files\\tmp1.docx");

            var testDoc = new DocxReport(fileName);
            testDoc.SaveAs(fileNameToSave);

            try
            {
                MemoryStream memoryStream = new MemoryStream();

                using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    fileStream.CopyTo(memoryStream);
                }
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }
    }
}
