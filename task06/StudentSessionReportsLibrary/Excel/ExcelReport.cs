using StudentSessionReportsLibrary.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentSessionReportsLibrary.Excel
{
    public enum SessionResultSortState
    {
        GroupAsc,
        GroupDesc,
        MinAsc,
        MinDesc,
        MaxAsc,
        MaxDesc,
        AverageAsc,
        AverageDesc
    }

    public static class ExcelReport
    {
        public static void SaveStudentSessionReportToFile(List<SessionResult> sessionResults, SessionResultSortState sortState = SessionResultSortState.GroupAsc)
        {
            var groupedCollection = sessionResults.GroupBy(s => s.NumberOfSession).Select(s => new { NumberOfSession = s.Key, Groups = s.GroupBy(g => g.GroupName).Select(g => new { Group = g.Key, Min = g.Min(q => q.Mark), Max = g.Max(m => m.Mark), Avg = g.Average(e => e.Mark) }) }).OrderBy(s => s.NumberOfSession).ToList();

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook worKbooK;
            Microsoft.Office.Interop.Excel.Worksheet worKsheeT;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                worKbooK = excel.Workbooks.Add(Type.Missing);

                worKbooK.Sheets.Add(Type.Missing, Type.Missing, groupedCollection.Count, Type.Missing);
                for (int i = 0; i < groupedCollection.Count; i++)
                {
                    worKsheeT = worKbooK.Sheets[i + 1];
                    worKsheeT.Name = "Session" + groupedCollection[i].NumberOfSession.ToString();

                    worKsheeT.Cells[1, 1] = "Group";
                    worKsheeT.Cells[1, 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                    worKsheeT.Cells[1, 2] = "Minimal";
                    worKsheeT.Cells[1, 2].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                    worKsheeT.Cells[1, 3] = "Max";
                    worKsheeT.Cells[1, 3].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                    worKsheeT.Cells[1, 4].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                    worKsheeT.Cells[1, 4] = "Average";

                    var groups = groupedCollection[i].Groups.ToList();

                    if (sortState == SessionResultSortState.GroupAsc)
                        groups = groups.OrderBy(g => g.Group).ToList();
                    if (sortState == SessionResultSortState.GroupDesc)
                        groups = groups.OrderByDescending(g => g.Group).ToList();
                    if (sortState == SessionResultSortState.MinAsc)
                        groups = groups.OrderBy(g => g.Min).ToList();
                    if (sortState == SessionResultSortState.MinDesc)
                        groups = groups.OrderByDescending(g => g.Min).ToList();
                    if (sortState == SessionResultSortState.MaxAsc)
                        groups = groups.OrderBy(g => g.Max).ToList();
                    if (sortState == SessionResultSortState.MaxDesc)
                        groups = groups.OrderByDescending(g => g.Max).ToList();
                    if (sortState == SessionResultSortState.AverageAsc)
                        groups = groups.OrderBy(g => g.Avg).ToList();
                    if (sortState == SessionResultSortState.AverageDesc)
                        groups = groups.OrderByDescending(g => g.Avg).ToList();

                    for (int j = 1; j < groups.Count; j++)
                    {
                        worKsheeT.Cells[j + 1, 1] = groups[j - 1].Group;
                        worKsheeT.Cells[j + 1, 2] = groups[j - 1].Min;
                        worKsheeT.Cells[j + 1, 3] = groups[j - 1].Max;
                        worKsheeT.Cells[j + 1, 4] = groups[j - 1].Avg;
                    }
                }

                worKbooK.SaveAs(Directory.GetCurrentDirectory() + @"\StudentSessionReport.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault); ;
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
