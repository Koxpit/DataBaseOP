using DataBaseOP.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseOP.Controllers
{
    class RealizationController : BaseController
    {
        public void Add(Realization realization)
        {
            Context.AddRealization(realization);
        }

        public void Edit(Realization realization)
        {
            Context.EditRealization(realization);
        }

        public void Delete(int realizationId)
        {
            Context.Delete(realizationId, "sp_DeleteRealization");
        }

        public void GetAllRealizations(ref DataGridView dataGridView)
        {
            dataGridView.DataSource = Context.GetAllRealizations();

            SetLinkCellsCommands(dataGridView, 15);
        }
    }
}
