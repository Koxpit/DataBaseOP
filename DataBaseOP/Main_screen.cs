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

namespace DataBaseOP
{
    public partial class DataBase : Form
    {
        public DataBase()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Вы уверен что хотите выйти ?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Worker_Click(object sender, EventArgs e)
        {
            Worker newForm = new Worker();
            newForm.Show();
        }

        private void Position_Click(object sender, EventArgs e)
        {
            Position newForm = new Position();
            newForm.Show();
        }

        private void Trademark_Click(object sender, EventArgs e)
        {
            Trademark newForm = new Trademark();
            newForm.Show();
        }

        private void Product_Click(object sender, EventArgs e)
        {
            Product newForm = new Product();
            newForm.Show();
        }

        private void Realization_Click(object sender, EventArgs e)
        {
            Realization newForm = new Realization();
            newForm.Show();
        }

        private void Supplier_Click(object sender, EventArgs e)
        {
            Supplier newForm = new Supplier();
            newForm.Show();
        }

        private void Category_Click(object sender, EventArgs e)
        {
            Category newForm = new Category();
            newForm.Show();
        }

        private void OneToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
