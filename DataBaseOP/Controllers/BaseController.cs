using DataBaseOP.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseOP.Controllers
{
    class BaseController
    {
        public DataBaseOPContext Context { get; } = DataBaseOPContext.GetContext;

        public void SetLinkCellsCommands(DataGridView dataGridView, int columnId)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView[columnId, i] = linkCell;
            }
        }
    }
}
