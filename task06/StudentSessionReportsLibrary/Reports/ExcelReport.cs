using StudentSessionReportsLibrary.Objects;
using StudentSessionReportsLibrary.Reports;
using StudentSessionReportsLibrary.Reports.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentSessionReportsLibrary.Excel
{
    /// <summary>
    /// Descriving methods for saving reports to exel format.
    /// </summary>
    public static class ExcelReport
    {
        /// <summary>
        /// Save summary marks report to excel format. 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="summaryMarks"></param>
        public static void SaveSummaryMarkToFile(string filePath, Dictionary<int, List<SummaryMark>> summaryMarks)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook worKbooK;
            Microsoft.Office.Interop.Excel.Worksheet worKsheeT;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                worKbooK = excel.Workbooks.Add(Type.Missing);

                worKbooK.Sheets.Add(Type.Missing, Type.Missing, summaryMarks.Count, Type.Missing);

                var keys = summaryMarks.Keys.ToArray();
                for (int i = 0; i < summaryMarks.Count; i++)
                {
                    worKsheeT = worKbooK.Sheets[i + 1];
                    worKsheeT.Name = "Session" + keys[i].ToString();

                    worKsheeT.Cells[1, 1] = "Group";
                    worKsheeT.Cells[1, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                    worKsheeT.Cells[1, 2] = "Minimal";
                    worKsheeT.Cells[1, 2].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                    worKsheeT.Cells[1, 3] = "Max";
                    worKsheeT.Cells[1, 3].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                    worKsheeT.Cells[1, 4].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                    worKsheeT.Cells[1, 4] = "Average";

                    var list = summaryMarks[keys[i]];
                    for (int j = 1; j < list.Count; j++)
                    {
                        worKsheeT.Cells[j + 1, 1] = list[j - 1].Group;
                        worKsheeT.Cells[j + 1, 2] = list[j - 1].MinimalMark;
                        worKsheeT.Cells[j + 1, 3] = list[j - 1].MaximumMark;
                        worKsheeT.Cells[j + 1, 4] = list[j - 1].AverageMark;
                    }
                }

                worKbooK.SaveAs(filePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault);
                worKbooK.Close();
                excel.Quit();

            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
            finally
            {
                worKsheeT = null;
                worKbooK = null;
            }
        }

        /// <summary>
        /// Save session results report to excel format. 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sessionReports"></param>
        public static void SaveSessionResultsToFile(string filePath, Dictionary<int, List<SessionReport>> sessionReports)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook worKbooK;
            Microsoft.Office.Interop.Excel.Worksheet worKsheeT;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                worKbooK = excel.Workbooks.Add(Type.Missing);

                worKbooK.Sheets.Add(Type.Missing, Type.Missing, sessionReports.Count, Type.Missing);

                var keys = sessionReports.Keys.ToArray();
                for (int i = 0; i < sessionReports.Count; i++)
                {
                    worKsheeT = worKbooK.Sheets[i + 1];
                    worKsheeT.Name = "Session" + keys[i].ToString();

                    worKsheeT.Cells[1, 1] = "FullName";
                    worKsheeT.Cells[1, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                    worKsheeT.Cells[1, 1].ColumnWidth = 60;

                    worKsheeT.Cells[1, 2] = "Group";
                    worKsheeT.Cells[1, 2].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                    worKsheeT.Cells[1, 2].ColumnWidth = 20;

                    worKsheeT.Cells[1, 3] = "AverageMark";
                    worKsheeT.Cells[1, 3].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                    worKsheeT.Cells[1, 3].ColumnWidth = 20;

                    var list = sessionReports[keys[i]];
                    for (int j = 1; j < list.Count; j++)
                    {
                        worKsheeT.Cells[j + 1, 1] = list[j - 1].FullName;
                        worKsheeT.Cells[j + 1, 2] = list[j - 1].Group;
                        worKsheeT.Cells[j + 1, 3] = list[j - 1].AverageMark;
                    }
                }

                worKbooK.SaveAs(filePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault);
                worKbooK.Close();
                excel.Quit();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                worKsheeT = null;
                worKbooK = null;
            }
        }
    }
}
