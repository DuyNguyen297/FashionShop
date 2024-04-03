using System;
using System.Collections.Generic;
using System.IO;
using ClosedXML.Excel;
using FashionShop.Models;

namespace FashionShop.Helper
{
    public static class ConvertExcelToPdfHelper
    {
        public static Stream ConvertExcelToPdf(Stream excelStream)
        {
            using (var workbook = new XLWorkbook(excelStream))
            {
                using (var pdfStream = new MemoryStream())
                {
                    workbook.SaveAs(pdfStream, new SaveOptions { EvaluateFormulasBeforeSaving = false });
                    return pdfStream;
                }
            }
        }
    }
}
