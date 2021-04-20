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
    public partial class ProductForm : Form
    {
        private readonly ProductController productController;

        public ProductForm()
        {
            InitializeComponent();
            productController = new ProductController();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            productController.GetAllProducts(ref dataGridViewProducts);
        }
    }
}
