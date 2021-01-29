using StudentSessionReportsLINQLibrary.Reports.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLINQLibrary.Reports.Excel
{
    /// <summary>
    /// For save average mark for each session.
    /// </summary>
    public class AverageGroupMarkReportExcel : ExcelReport<Dictionary<int, List<AverageGroupMarkReport>>>
    {
        /// <summary>
        /// Init a excel object for save average mark reports by each group to file.
        /// </summary>
        /// <param name="filePath"></param>
        public AverageGroupMarkReportExcel(string filePath)
            : base(filePath) { }

        public override void SaveToFile(Dictionary<int, List<AverageGroupMarkReport>> reports)
        {
            if (!string.IsNullOrEmpty(FilePath))
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

                        worKsheeT.Cells[1, 1] = "FullName";
                        worKsheeT.Cells[1, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        worKsheeT.Cells[1, 1].ColumnWidth = 60;

                        worKsheeT.Cells[1, 2] = "Group";
                        worKsheeT.Cells[1, 2].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        worKsheeT.Cells[1, 2].ColumnWidth = 20;

                        worKsheeT.Cells[1, 3] = "AverageMark";
                        worKsheeT.Cells[1, 3].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        worKsheeT.Cells[1, 3].ColumnWidth = 20;

                        var list = reports[keys[i]];
                        for (int j = 1; j < list.Count; j++)
                        {
                            worKsheeT.Cells[j + 1, 1] = list[j - 1].FullName;
                            worKsheeT.Cells[j + 1, 2] = list[j - 1].Group;
                            worKsheeT.Cells[j + 1, 3] = list[j - 1].AverageMark;
                        }
                    }

                    worKbooK.SaveAs(FilePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault);
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
}
