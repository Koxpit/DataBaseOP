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
    public partial class SupplierForm : Form
    {
        private readonly SupplierController supplierController;

        public SupplierForm()
        {
            InitializeComponent();
            supplierController = new SupplierController();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            supplierController.GetAllSuppliers(ref dataGridViewSuppliers);
        }
    }
}
