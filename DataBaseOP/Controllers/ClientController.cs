using DataBaseOP.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseOP.Controllers
{
    class ClientController : BaseController
    {
        public void Add(Client client)
        {
            Context.AddClient(client);
        }

        public void Edit(Client client)
        {
            Context.EditClient(client);
        }

        public void Delete(int trademarkId)
        {
            Context.Delete(trademarkId, "sp_DeleteClient");
        }

        public void GetAllClients(ref DataGridView dataGridView)
        {
            dataGridView.DataSource = Context.GetAllClients();

            SetLinkCellsCommands(dataGridView, dataGridView.ColumnCount - 1);
        }

        public int GetClientIdByPhone(string clientPhone)
        {
            return Context.GetClientIdByPhone(clientPhone);
        }
    }
}
