using DataBaseOP.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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

            SetLinkCellsCommands(dataGridView, dataGridView.ColumnCount - 1);
        }

        public int GetSupplierIdByPhone(string supplierPhone)
        {
            return Context.GetSupplierIdByPhone(supplierPhone);
        }

        public Supplier GetSupplierInfoByPhone(string supplierPhone)
        {
            DataTable clientInfo = Context.GetSupplierInfoByPhone(supplierPhone);

            Supplier supplier = new Supplier()
            {
                FIO = clientInfo.Rows[0][0].ToString(),
                Phone = supplierPhone,
                Address = clientInfo.Rows[0][1].ToString()
            };

            return supplier;
        }
    }
}
