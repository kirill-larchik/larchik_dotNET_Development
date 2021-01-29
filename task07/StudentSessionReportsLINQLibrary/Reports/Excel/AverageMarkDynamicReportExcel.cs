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
    public class AverageMarkDynamicReportExcel : ExcelReport<Dictionary<int, List<AverageMarkDynamicReport>>>
    {
        /// <summary>
        /// Init a excel object for save average mark dynamic report to file.
        /// </summary>
        /// <param name="filePath"></param>
        public AverageMarkDynamicReportExcel(string filePath)
            : base(filePath) { }

        public override void SaveToFile(Dictionary<int, List<AverageMarkDynamicReport>> reports)
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

                        worKsheeT.Cells[1, 1] = "SubjectName";
                        worKsheeT.Cells[1, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        worKsheeT.Cells[1, 1].ColumnWidth = 20;

                        int minYear = reports[keys[i]].Min(q => q.MinYear);
                        int maxYear = reports[keys[i]].Max(q => q.MinYear);

                        int k = 2;
                        for (int j = minYear; j <= maxYear; j++)
                        {
                            worKsheeT.Cells[1, k] = j.ToString();
                            worKsheeT.Cells[1, k].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                            worKsheeT.Cells[1, k].ColumnWidth = 20;
                            k++;
                        }

                        int count = maxYear - minYear;
                        var list = reports[keys[i]];
                        for (int j = 1; j < list.Count; j++)
                        {
                            worKsheeT.Cells[j + 1, 1] = list[j - 1].SubjectName;

                            k = 0;
                            for (int q = 2; q < count + 3; q++)
                            {
                                if (list[j - 1].YearMarkPairs.ContainsKey(minYear + k))
                                    worKsheeT.Cells[j + 1, q] = list[j - 1].YearMarkPairs[minYear + k];
                                else
                                    worKsheeT.Cells[j + 1, q] = "NONE";
                                k++;
                            }

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
