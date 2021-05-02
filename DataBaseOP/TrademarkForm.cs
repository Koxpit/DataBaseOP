using DataBaseOP.Controllers;
using DataBaseOP.Database.Entities;
using DataBaseOP.Services;
using System;
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
                if (e.RowIndex == -1) //редактрование с второй строки
                    return;
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

                        Trademark newTrademark = GetTrademarkInfo(ref currentRow);
                        if (newTrademark == null)
                            return;

                        int currentTrademarkId = trademarkController.GetTrademarkIdByName(newTrademark.Name);
                        if (currentTrademarkId != 0)
                        {
                            MessageBox.Show("Бренд с введенным названием уже существует.");
                            return;
                        }

                        trademarkController.Add(newTrademark);
                        dataGridViewTrademarks.Rows[e.RowIndex].Cells["Операция"].Value = "Удалить";
                    }
                    else if (task == "Изм.")
                    {
                        int rowIndex = e.RowIndex;
                        DataGridViewRow currentRow = dataGridViewTrademarks.Rows[rowIndex];

                        Trademark updatedTrademark = GetTrademarkInfo(ref currentRow);
                        if (updatedTrademark == null)
                            return;

                        int currentTrademarkId = trademarkController.GetTrademarkIdByName(updatedTrademark.Name);
                        if (updatedTrademark.ID != currentTrademarkId && currentTrademarkId != 0)
                        {
                            MessageBox.Show("Бренд с введенным названием уже существует.");
                            return;
                        }

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

        private Trademark GetTrademarkInfo(ref DataGridViewRow currentRow)
        {
            Trademark trademark = new Trademark()
            {
                ID = (int)currentRow.Cells["ID"].Value,
                Name = currentRow.Cells["Наименование"].Value.ToString(),
                Address = currentRow.Cells["Адрес"].Value.ToString(),
                Phone = currentRow.Cells["Телефон"].Value.ToString()
            };

            if (CellsIsNull(trademark))
                return null;

            return trademark;
        }

        private bool CellsIsNull(Trademark trademark)
        {
            bool isNull = false;

            if (trademark.Name == "")
            {
                MessageBox.Show("Ошибка! Заполните поле 'Наименование'!");
                isNull = true;
                return isNull;
            }

            if (trademark.Address == "")
            {
                MessageBox.Show("Ошибка! Заполнените поле 'Адрес'!");
                isNull = true;
                return isNull;
            }

            if (trademark.Phone == "")
            {
                MessageBox.Show("Ошибка! Заполнените поле 'Телефон'!");
                isNull = true;
                return isNull;
            }

            return isNull;
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

                    Trademark trademark = GetTrademarkInfo(ref editingRow);
                    if (trademark == null)
                        return;

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
            try
            {
                e.Control.KeyPress -= new KeyPressEventHandler(InputHandlerService.DigitOnly);
                int columnIndex = dataGridViewTrademarks.CurrentCell.ColumnIndex;

                if (columnIndex == 3)
                {
                    TextBox textBox = e.Control as TextBox;
                    if (textBox != null)
                        textBox.KeyPress += new KeyPressEventHandler(InputHandlerService.DigitOnly);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void экспортВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelService.ExportToExcel(dataGridViewTrademarks, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewTrademarks_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                newRowAdding = false;

                foreach (DataGridViewRow s in dataGridViewTrademarks.Rows)
                {
                    if (s.Index <= dataGridViewTrademarks.Rows.Count - 2)
                    {
                        if (s.Cells["Наименование"].Value.ToString() == ""
                            || s.Cells["Адрес"].Value.ToString() == ""
                            || s.Cells["Телефон"].Value.ToString() == "")
                            return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
