using DataBaseOP.Database;
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
    class PositionController : BaseController
    {
        public void Add(Position position)
        {
            Context.AddPosition(position);
        }

        public void Edit(Position position)
        {
            Context.EditPosition(position);
        }

        public void Delete(int positionId)
        {
            Context.Delete(positionId, "sp_DeletePosition");
        }

        public void GetAllPositions(ref DataGridView dataGridView)
        {
            dataGridView.DataSource = Context.GetAllPositions();

            SetLinkCellsCommands(dataGridView, 2);
        }
    }
}
