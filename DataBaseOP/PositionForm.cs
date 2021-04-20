using DataBaseOP.Controllers;
using DataBaseOP.Database.Entities;
using System;
using System.Windows.Forms;

namespace DataBaseOP
{
    public partial class PositionForm : Form
    {
        private readonly PositionController positionController;
        private bool newRowAdding = false;

        public PositionForm()
        {
            InitializeComponent();
            positionController = new PositionController();
        }

        private void PositionForm_Load(object sender, EventArgs e)
        {
            positionController.GetAllPositions(ref dataGridViewPositions);
        }

        private void dataGridViewPositions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                string task = dataGridViewPositions.Rows[e.RowIndex].Cells[2].Value.ToString();

                if (task == "Удалить")
                {
                    if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = (int)dataGridViewPositions.CurrentRow.Cells[0].Value;
                        positionController.Delete(id);
                    }
                }
                else if (task == "Добавить")
                {
                    int rowIndex = dataGridViewPositions.Rows.Count - 2;

                    Position newPosition = new Position
                    {
                        Name = dataGridViewPositions.Rows[rowIndex].Cells["Наименование"].Value.ToString()
                    };

                    positionController.Add(newPosition);
                    dataGridViewPositions.Rows[e.RowIndex].Cells[2].Value = "Удалить";
                }
                else if (task == "Изм.")
                {
                    int rowIndex = e.RowIndex;
                    Position updatedPosition = new Position
                    {
                        ID = (int)dataGridViewPositions.CurrentRow.Cells[0].Value,
                        Name = dataGridViewPositions.Rows[rowIndex].Cells["Наименование"].Value.ToString()
                    };

                    positionController.Edit(updatedPosition);
                    dataGridViewPositions.Rows[e.RowIndex].Cells[2].Value = "Удалить";
                }

                positionController.GetAllPositions(ref dataGridViewPositions);
            }
        }

        private void dataGridViewPositions_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;
                    int lastRow = dataGridViewPositions.Rows.Count - 2;
                    DataGridViewRow row = dataGridViewPositions.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewPositions[2, lastRow] = linkCell;

                    row.Cells["Операция"].Value = "Добавить";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewPositions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = dataGridViewPositions.SelectedCells[0].RowIndex;
                    DataGridViewRow editingRow = dataGridViewPositions.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewPositions[2, rowIndex] = linkCell;
                    editingRow.Cells["Операция"].Value = "Изм.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewPositions_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);

            if (dataGridViewPositions.CurrentCell.ColumnIndex == 1)
            {
                TextBox textBox = e.Control as TextBox;

                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
