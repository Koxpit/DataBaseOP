using DataBaseOP.Controllers;
using DataBaseOP.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseOP
{
    public partial class Report : Form
    {
        private readonly ReportController reportController;

        public Report()
        {
            InitializeComponent();

            reportController = new ReportController();
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void экспортВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelService.ExportToExcel(dataGridViewReportResult, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                CalculateRealizationsResult(dateTimePickerBeginDate.Value.Date, dateTimePickerEndDate.Value.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CalculateRealizationsResult(DateTime beginDate, DateTime endDate)
        {
            DataTable reportResult = reportController.GetRealizationsResult(beginDate, endDate);

            dataGridViewReportResult.DataSource = reportResult;
        }
    }
}
