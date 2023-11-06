using ManualStatisticsCollector.Models;
using ManualStatisticsCollectorLib.Entities;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualStatisticsCollector.Utils
{
    public class ExcelWorkActivitiesExport
    {

        public static void SaveWorkActivitiesToExcel(string filename, List<WorkActivity> workActivities)
        {
            IWorkbook workbook = new XSSFWorkbook();

            var sheet = (XSSFSheet)workbook.CreateSheet("Export");
            var titleRow = sheet.CreateRow(0);

            

            var rowBoldUnderlineStyle = workbook.CreateCellStyle();
            rowBoldUnderlineStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;

            var rowFont = rowBoldUnderlineStyle.GetFont(workbook).Copy();
            rowFont.IsBold = true;
            rowBoldUnderlineStyle.SetFont(rowFont);

            GetCellWithStyle(titleRow, 0, rowBoldUnderlineStyle, "WorkTask");
            GetCellWithStyle(titleRow, 1, rowBoldUnderlineStyle, "Start");
            GetCellWithStyle(titleRow, 2, rowBoldUnderlineStyle, "End");
            GetCellWithStyle(titleRow, 3, rowBoldUnderlineStyle, "Duration");
            GetCellWithStyle(titleRow, 4, rowBoldUnderlineStyle, "Source");
            GetCellWithStyle(titleRow, 5, rowBoldUnderlineStyle, "TrackingProject");

            titleRow.RowStyle = rowBoldUnderlineStyle;

            IDataFormat dataFormatCustom = workbook.CreateDataFormat();

            var minuteDataFormatCreator = workbook.CreateDataFormat();

            var dateTimeRowStyle = workbook.CreateCellStyle();
            dateTimeRowStyle.DataFormat = dataFormatCustom.GetFormat("yyyy-MM-dd HH:mm:ss");

            var minuteCellStyle = workbook.CreateCellStyle();
            minuteCellStyle.DataFormat = minuteDataFormatCreator.GetFormat("0.00\" min\"");

            for (int a = 0; a < workActivities.Count; a++)
            {
                if (!workActivities[a].End.HasValue)
                {
                    continue;
                }
                var row = sheet.CreateRow(a + 1);
                row.CreateCell(0).SetCellValue(workActivities[a].WorkTask);
                var startCell = row.CreateCell(1);
                startCell.SetCellValue(workActivities[a].Start);
                startCell.CellStyle = dateTimeRowStyle;
                var endCell = row.CreateCell(2);
                endCell.SetCellValue(workActivities[a].End.Value);
                endCell.CellStyle = dateTimeRowStyle;
                var durationCell = row.CreateCell(3);
                durationCell.SetCellValue(workActivities[a].Duration.TotalMinutes);
                durationCell.CellStyle = minuteCellStyle;
                row.CreateCell(4).SetCellValue(workActivities[a].Source);
                row.CreateCell(5).SetCellValue(workActivities[a].TrackingProject);
            }

            sheet.SetColumnWidth(0, 18 * 256);
            sheet.SetColumnWidth(1, 20 * 256);
            sheet.SetColumnWidth(2, 20 * 256);
            sheet.SetColumnWidth(3, 12 * 256);
            sheet.SetColumnWidth(4, 30 * 256);
            sheet.SetColumnWidth(5, 20 * 256);


            using (var fs = File.Create(filename))
            {
                workbook.Write(fs, false);
            }
        }

        private static ICell GetCellWithStyle(IRow row, int column, ICellStyle style, string content)
        {
            var cell = row.CreateCell(column);
            cell.SetCellValue(content);
            cell.CellStyle = style;
            return cell;
        }
    }
}
