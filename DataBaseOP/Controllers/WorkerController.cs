using DataBaseOP.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseOP.Controllers
{
    class WorkerController : BaseController
    {
        public void Add(Worker worker)
        {
            Context.AddWorker(worker);
        }

        public void Edit(Worker worker)
        {
            Context.EditWorker(worker);
        }

        public void Delete(int workerId)
        {
            Context.Delete(workerId, "sp_DeleteWorker");
        }

        public void GetAllTrademarks(ref DataGridView dataGridView)
        {
            dataGridView.DataSource = Context.GetAllTrademarks();

            SetLinkCellsCommands(dataGridView, 4);
        }
    }
}
