using DataBaseOP.Controllers;
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
    public partial class WorkerForm : Form
    {
        private readonly WorkerController workerController;

        public WorkerForm()
        {
            InitializeComponent();
            workerController = new WorkerController();
        }

        private void WorkerForm_Load(object sender, EventArgs e)
        {
            try
            {
                workerController.GetAllWorkers(ref dataGridViewWorkers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
