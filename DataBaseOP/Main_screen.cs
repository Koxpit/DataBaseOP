using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DataBaseOP.Database;

namespace DataBaseOP
{
    public partial class DataBase : Form
    {
        
        public DataBase()
        {
            InitializeComponent();
            this.FormClosing += DataBase_Closing;
        }
        private void DataBase_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (MessageBox.Show("Вы уверен что хотите выйти ?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void exit_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void Worker_Click(object sender, EventArgs e)
        {
            WorkerForm newForm = new WorkerForm();
            newForm.Show();
        }

        private void Position_Click(object sender, EventArgs e)
        {
            PositionForm newForm = new PositionForm();
            newForm.Show();
        }

        private void Trademark_Click(object sender, EventArgs e)
        {
            TrademarkForm newForm = new TrademarkForm();
            newForm.Show();
        }

        private void Product_Click(object sender, EventArgs e)
        {
            ProductForm newForm = new ProductForm();
            newForm.Show();
        }

        private void Realization_Click(object sender, EventArgs e)
        {
            RealizationForm newForm = new RealizationForm();
            newForm.Show();
        }

        private void Supplier_Click(object sender, EventArgs e)
        {
            SupplierForm newForm = new SupplierForm();
            newForm.Show();
        }

        private void Category_Click(object sender, EventArgs e)
        {
            CategoryForm newForm = new CategoryForm();
            newForm.Show();
        }

        private void OneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox newForm = new AboutBox();
            newForm.Show();
        }
    }
}
