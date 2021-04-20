using DataBaseOP.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseOP.Controllers
{
    class TrademarkController : BaseController
    {
        public void Add(Trademark trademark)
        {
            Context.AddTrademark(trademark);
        }

        public void Edit(Trademark trademark)
        {
            Context.EditTrademark(trademark);
        }

        public void Delete(int trademarkId)
        {
            Context.Delete(trademarkId, "sp_DeleteTrademark");
        }

        public void GetAllTrademarks(ref DataGridView dataGridView)
        {
            dataGridView.DataSource = Context.GetAllTrademarks();

            SetLinkCellsCommands(dataGridView, 4);
        }
    }
}
