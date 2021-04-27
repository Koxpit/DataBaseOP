using DataBaseOP.Controllers;
using DataBaseOP.Database.Entities;
using DataBaseOP.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseOP
{
    public partial class TrademarkForm : Form
    {
        private readonly TrademarkController trademarkController;
        private bool newRowAdding = false;

        public TrademarkForm()
        {
            InitializeComponent();
            trademarkController = new TrademarkController();
        }

        private void TrademarkForm_Load(object sender, EventArgs e)
        {
            try
            {
                trademarkController.GetAllTrademarks(ref dataGridViewTrademarks);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewTrademarks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int taskIndex = dataGridViewTrademarks.Rows[e.RowIndex].Cells["Операция"].ColumnIndex;

                if (e.ColumnIndex == taskIndex)
                {
                    string task = dataGridViewTrademarks.Rows[e.RowIndex].Cells["Операция"].Value.ToString();

                    if (task == "Удалить")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int id = (int)dataGridViewTrademarks.CurrentRow.Cells["ID"].Value;
                            trademarkController.Delete(id);
                        }
                    }
                    else if (task == "Добавить")
                    {
                        int rowIndex = dataGridViewTrademarks.Rows.Count - 2;
                        DataGridViewRow currentRow = dataGridViewTrademarks.Rows[rowIndex];
                        Trademark newTrademark = GetTrademarkInfo(currentRow);

                        trademarkController.Add(newTrademark);
                        dataGridViewTrademarks.Rows[e.RowIndex].Cells["Операция"].Value = "Удалить";
                    }
                    else if (task == "Изм.")
                    {
                        int rowIndex = e.RowIndex;
                        DataGridViewRow currentRow = dataGridViewTrademarks.Rows[rowIndex];
                        Trademark updatedTrademark = GetTrademarkInfo(currentRow);

                        trademarkController.Edit(updatedTrademark);
                        currentRow.Cells["Операция"].Value = "Удалить";
                    }

                    trademarkController.GetAllTrademarks(ref dataGridViewTrademarks);
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Trademark GetTrademarkInfo(DataGridViewRow currentRow)
        {
            Trademark trademark = new Trademark
            {
                ID = (int)currentRow.Cells["ID"].Value,
                Name = currentRow.Cells["Наименование"].Value.ToString(),
                Address = currentRow.Cells["Адрес"].Value.ToString(),
                Phone = currentRow.Cells["Телефон"].Value.ToString()
            };

            return trademark;
        }

        private void dataGridViewTrademarks_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;
                    int lastRow = dataGridViewTrademarks.Rows.Count - 2;
                    DataGridViewRow row = dataGridViewTrademarks.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewTrademarks[4, lastRow] = linkCell;

                    row.Cells["Операция"].Value = "Добавить";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewTrademarks_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = dataGridViewTrademarks.SelectedCells[0].RowIndex;
                    DataGridViewRow editingRow = dataGridViewTrademarks.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewTrademarks[4, rowIndex] = linkCell;
                    editingRow.Cells["Операция"].Value = "Изм.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewTrademarks_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);

            if (dataGridViewTrademarks.CurrentCell.ColumnIndex == 1)
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

        private void экспортВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelService.ExportToExcel(dataGridViewTrademarks, this.Text);
        }
    }
}
