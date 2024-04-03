using System;
using System.Collections.Generic;
using System.IO;
using FashionShop.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml;
using Aspose.Cells;
using FashionShop.Shared;
using System.Linq;
using OfficeOpenXml.Style;

namespace FashionShop.Helper
{
    public static class ExportToExcelHelper
    {
		public static Stream UpdateDataIntoExcelSellTemplate(List<OrderDetail> orderDetails, Order order, FileInfo path)
		{
			orderDetails = orderDetails.OrderBy(o => o.Product.Code).ToList();
			var stream = new MemoryStream();
			if (path.Exists)
			{
				using (ExcelPackage package = new ExcelPackage(path))
				{
					ExcelWorksheet sheet = package.Workbook.Worksheets["Bill"];

					sheet.Cells["H2"].Value = order.Code;
					sheet.Cells["H3"].Value = order.PayStatus == PayStatusConst.DONE ? "Đã thanh toán" : "Chưa thanh toán";

					sheet.Cells["E4"].Value = order.Name;
					sheet.Cells["E5"].Value = order.Address;
					sheet.Cells["E6"].Value = order.Phone;
					sheet.Cells["E7"].Value = order.CreatedAt?.ToString("dd/MM/yyyy hh:mm tt");
					sheet.Cells["E8"].Value = order.PayWay == PayConst.OFFLINE ? "Thanh toán khi nhận hàng" : "MoMo";
					sheet.Cells["E9"].Value = order.ReceiveDate?.ToString("dd/MM/yyyy hh:mm tt");
					int rowIndex = 12;
					int? sumQuantity = 0;
					decimal? sumDiscount = 0;
					decimal? sumTotal = 0;
					foreach (var item in orderDetails)
					{
						sheet.Cells[rowIndex, 2].Value = item.Product?.Name;
						sheet.Cells[rowIndex, 3].Value = item.Product?.Color?.Name;
						sheet.Cells[rowIndex, 4].Value = item.Product?.Size?.Code;
						sheet.Cells[rowIndex, 5].Value = item.Product?.Price?.ToString("n0");
						sheet.Cells[rowIndex, 6].Value = item.Quantity;
						sheet.Cells[rowIndex, 7].Value = item.Product?.Discount?.ToString("n0");
						sheet.Cells[rowIndex, 8].Value = item.Total?.ToString("n0");
						sumQuantity += item.Quantity;
						sumDiscount += item.Product?.Discount;
						sumTotal += item.Total;
						rowIndex += 1;
					}

					// Gán giá trị tổng cộng vào ô Total
					sheet.Cells["F27"].Value = sumQuantity;
					sheet.Cells["G27"].Value = sumDiscount?.ToString("n0") + " VND";
					sheet.Cells["H27"].Value = sumTotal?.ToString("n0") + " VND";

					sheet.Cells["G29"].Value = order.Discount?.ToString("n0") + " VND";
					sheet.Cells["G30"].Value = order.ShipFee?.ToString("n0") + " VND";
					sheet.Cells["G31"].Value = order.Total?.ToString("n0") + " VND";

					sheet.Cells["E33"].Value = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
					sheet.Cells["E33"].Style.Font.Italic = true;
					package.SaveAs(stream);
					stream.Position = 0;
				}
			}
			return stream;
		}
		public static Stream UpdateDataIntoExcelImportTemplate(List<ImportDetail> importDetails, Import import, FileInfo path)
		{
			importDetails = importDetails.OrderBy(o => o.Product.Code).ToList();
			var stream = new MemoryStream();
			if (path.Exists)
			{
				using (ExcelPackage package = new ExcelPackage(path))
				{
					ExcelWorksheet sheet = package.Workbook.Worksheets["Import"];

					sheet.Cells["H2"].Value = import.Code;

					sheet.Cells["E4"].Value = import.Account?.Name;
					sheet.Cells["E5"].Value = import.Account?.Phone;
					sheet.Cells["E6"].Value = import.Account?.Email;
					sheet.Cells["E7"].Value = import.CreatedAt?.ToString("dd/MM/yyyy hh:mm tt");
					int rowIndex = 10;
					int? sumQuantity = 0;
					decimal? sumPriceIn = 0;
					decimal? sumTotal = 0;
					foreach (var item in importDetails)
					{
						sheet.Cells[rowIndex, 2].Value = item.Product?.Name;
						sheet.Cells[rowIndex, 3].Value = item.Product?.Color?.Name;
						sheet.Cells[rowIndex, 4].Value = item.Product?.Size?.Code;
						sheet.Cells[rowIndex, 5].Value = item.Product?.Price?.ToString("n0");
						sheet.Cells[rowIndex, 6].Value = item.Quantity;
						sheet.Cells[rowIndex, 7].Value = item.PriceIn?.ToString("n0");
						sheet.Cells[rowIndex, 8].Value = item.Total?.ToString("n0") + "VND";
						sumQuantity += item.Quantity;
						sumPriceIn += item.PriceIn;
						sumTotal += item.Total;
						rowIndex += 1;
					}
					// Gán giá trị tổng cộng vào ô Total
					sheet.Cells["F25"].Value = sumQuantity;
					sheet.Cells["G25"].Value = sumPriceIn?.ToString("n0") + " VND";
					sheet.Cells["H25"].Value = sumTotal?.ToString("n0") + " VND";

					sheet.Cells["E31"].Value = "Thứ "+ DateTime.Now.DayOfWeek + "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
					sheet.Cells["E31"].Style.Font.Italic = true;
					package.SaveAs(stream);
					stream.Position = 0;
				}
			}
			return stream;
		}
	}
}
