using StudentSessionReportsLINQLibrary.Reports.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLINQLibrary.Reports.Excel
{
    /// <summary>
    /// For save summary marks for each group.
    /// </summary>
    public class SummaryMarkReportExcel : ExcelReport<Dictionary<int, List<SummaryMark>>>
    {
        /// <summary>
        /// Init a excel object for save summary mark reports to file. 
        /// </summary>
        /// <param name="filePath"></param>
        public SummaryMarkReportExcel(string filePath)
            : base(filePath) { }

        public override void SaveToFile(Dictionary<int, List<SummaryMark>> reports)
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

                worKbooK.Sheets.Add(Type.Missing, Type.Missing, reports.Count, Type.Missing);

                var keys = reports.Keys.ToArray();
                for (int i = 0; i < reports.Count; i++)
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

                    var list = reports[keys[i]];
                    for (int j = 1; j < list.Count; j++)
                    {
                        worKsheeT.Cells[j + 1, 1] = list[j - 1].Group;
                        worKsheeT.Cells[j + 1, 2] = list[j - 1].MinimalMark;
                        worKsheeT.Cells[j + 1, 3] = list[j - 1].MaximumMark;
                        worKsheeT.Cells[j + 1, 4] = list[j - 1].AverageMark;
                    }
                }

                worKbooK.SaveAs(FilePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault);
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
    }
}
