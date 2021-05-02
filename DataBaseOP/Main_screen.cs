using System;
using System.Windows.Forms;

namespace DataBaseOP
{
    public partial class DataBase : Form
    {
        
        public DataBase()
        {
            InitializeComponent();
            this.FormClosing += DataBase_Closing;
        }
        private void DataBase_Closing(object sender, System.ComponentModel.CancelEventArgs e) //обработка нажатия крестика
        {
            if (MessageBox.Show("Вы уверен что хотите выйти ?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void Client_Click(object sender, EventArgs e)
        {
            ClientForm newForm = new ClientForm();
            newForm.ShowDialog();
        }

        private void Worker_Click(object sender, EventArgs e)
        {
            WorkerForm newForm = new WorkerForm();
            newForm.ShowDialog();
        }

        private void Position_Click(object sender, EventArgs e)
        {
            PositionForm newForm = new PositionForm();
            newForm.ShowDialog();
        }

        private void Trademark_Click(object sender, EventArgs e)
        {
            TrademarkForm newForm = new TrademarkForm();
            newForm.ShowDialog();
        }

        private void Product_Click(object sender, EventArgs e)
        {
            ProductForm newForm = new ProductForm();
            newForm.ShowDialog();
        }

        private void Realization_Click(object sender, EventArgs e)
        {
            RealizationForm newForm = new RealizationForm();
            newForm.ShowDialog();
        }

        private void Supplier_Click(object sender, EventArgs e)
        {
            SupplierForm newForm = new SupplierForm();
            newForm.ShowDialog();
        }

        private void Category_Click(object sender, EventArgs e)
        {
            CategoryForm newForm = new CategoryForm();
            newForm.ShowDialog();
        }

        private void OneToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Report newForm = new Report();
            newForm.ShowDialog();
        }

        private void TwoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox newForm = new AboutBox();
            newForm.ShowDialog();
        }

        private void ExitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataBase_Load(object sender, EventArgs e)
        {

        }
    }
}
