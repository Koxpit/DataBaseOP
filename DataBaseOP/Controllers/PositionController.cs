using DataBaseOP.Database.Entities;
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
        }
    }
}
