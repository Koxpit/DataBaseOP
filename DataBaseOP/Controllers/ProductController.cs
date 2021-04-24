using DataBaseOP.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseOP.Controllers
{
    class ProductController : BaseController
    {
        public void Add(Product product)
        {
            Context.AddProduct(product);
        }

        public void Edit(Product product)
        {
            Context.EditProduct(product);
        }

        public void Delete(int productId)
        {
            Context.Delete(productId, "sp_DeleteProduct");
        }

        public void GetAllProducts(ref DataGridView dataGridView)
        {
            dataGridView.DataSource = Context.GetAllProducts();

            SetLinkCellsCommands(dataGridView, dataGridView.ColumnCount - 1);
        }

        public int GetProductIdByName(string productName)
        {
            return Context.GetProductIdByName(productName);
        }
    }
}
