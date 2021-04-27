using DataBaseOP.Controllers;
using DataBaseOP.Database.Entities;
using DataBaseOP.Services;
using System;
using System.Windows.Forms;

namespace DataBaseOP
{
    public partial class PositionForm : Form
    {
        private readonly PositionController positionController;

        public PositionForm()
        {
            InitializeComponent();
            positionController = new PositionController();
        }

        private void PositionForm_Load(object sender, EventArgs e)
        {
            try
            {
                positionController.GetAllPositions(ref dataGridViewPositions);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void экспортВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelService.ExportToExcel(dataGridViewPositions, this.Text);
        }
    }
}
