using DataBaseOP.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseOP.Controllers
{
    class SupplierController : BaseController
    {
        public void Add(Supplier supplier)
        {
            Context.AddSupplier(supplier);
        }

        public void Edit(Supplier supplier)
        {
            Context.EditSupplier(supplier);
        }

        public void Delete(int supplierId)
        {
            Context.Delete(supplierId, "sp_DeleteSupplier");
        }

        public void GetAllSuppliers(ref DataGridView dataGridView)
        {
            dataGridView.DataSource = Context.GetAllSuppliers();

            SetLinkCellsCommands(dataGridView, 4);
        }
    }
}
