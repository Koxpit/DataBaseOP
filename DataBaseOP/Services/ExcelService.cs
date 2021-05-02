using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace DataBaseOP.Services
{
    public static class ExcelService
    {
        private static List<string> columnNames = new List<string>();
        
        public static void ExportToExcel(DataGridView dataGridView, string formName)
        {
            var excelApp = new Excel.Application();
            excelApp.Visible = true;
            excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)excelApp.ActiveSheet;
            worksheet.Rows[1].Font.Bold = true;
            worksheet.Rows[2].Font.Bold = true;
            worksheet.Cells[1, 2] = formName;

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.HeaderText != "Операция")
                {
                    worksheet.Cells[2, column.Index + 1] = column.HeaderText;
                    worksheet.Cells[2, column.Index + 1].Borders.LineStyle = 1;
                }
            }

            for (int i = 0; i < dataGridView.RowCount; i++)
                for (int j = 0; j < dataGridView.ColumnCount-1; j++)
                {
                    worksheet.Cells[i + 3, j + 1] = dataGridView[j, i].Value;
                    worksheet.Cells[i + 3, j + 1].Borders.LineStyle = 1;
                    worksheet.Columns[j + 1].AutoFit();
                }

            worksheet.Cells[dataGridView.RowCount + 4, 1] = DateTime.Now.ToShortDateString();
        }
    }
}
