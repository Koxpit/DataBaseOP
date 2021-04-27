using DataBaseOP.Database;
using System;
using System.Windows.Forms;

namespace DataBaseOP.Controllers
{
    public abstract class BaseController
    {
        protected DataBaseOPContext Context { get; } = DataBaseOPContext.GetContext;

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
