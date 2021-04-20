using DataBaseOP.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseOP.Controllers
{
    class CategoryController : BaseController
    {
        public void Add(Category category)
        {
            Context.AddCategory(category);
        }

        public void Edit(Category category)
        {
            Context.EditCategory(category);
        }

        public void Delete(int categoryId)
        {
            Context.Delete(categoryId, "sp_DeleteCategory");
        }

        public void GetAllCategories(ref DataGridView dataGridView)
        {
            dataGridView.DataSource = Context.GetAllCategories();

            SetLinkCellsCommands(dataGridView, 2);
        }
    }
}
