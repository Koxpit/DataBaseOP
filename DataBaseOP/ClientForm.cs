using DataBaseOP.Controllers;
using DataBaseOP.Database.Entities;
using DataBaseOP.Services;
using System;
using System.Windows.Forms;

namespace DataBaseOP
{
    public partial class ClientForm : Form
    {
        private readonly ClientController clientController;
        private bool newRowAdding = false;

        public ClientForm()
        {
            InitializeComponent();
            clientController = new ClientController();
        }

        private void экспортВExelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelService.ExportToExcel(dataGridViewClients, this.Text);
        }

        private void dataGridViewClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int taskIndex = dataGridViewClients.Rows[e.RowIndex].Cells["Операция"].ColumnIndex;

            if (e.ColumnIndex == taskIndex)
            {
                string task = dataGridViewClients.Rows[e.RowIndex].Cells[taskIndex].Value.ToString();

                if (task == "Удалить")
                {
                    if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = (int)dataGridViewClients.CurrentRow.Cells[0].Value;
                        clientController.Delete(id);
                    }
                }
                else if (task == "Добавить")
                {
                    int rowIndex = dataGridViewClients.Rows.Count - 2;
                    DataGridViewRow currentRow = dataGridViewClients.Rows[rowIndex];
                    Client newClient = GetClientInfo(ref currentRow);

                    clientController.Add(newClient);

                    dataGridViewClients.Rows[e.RowIndex].Cells["Операция"].Value = "Удалить";
                }
                else if (task == "Изм.")
                {
                    int rowIndex = e.RowIndex;
                    DataGridViewRow currentRow = dataGridViewClients.Rows[rowIndex];
                    Client updatedClient = GetClientInfo(ref currentRow);

                    clientController.Edit(updatedClient);

                    dataGridViewClients.Rows[rowIndex].Cells["Операция"].Value = "Удалить";
                }

                clientController.GetAllClients(ref dataGridViewClients);
            }
        }

        private Client GetClientInfo(ref DataGridViewRow currentRow)
        {
            Client client = new Client
            {
                ID = (int)currentRow.Cells["ID"].Value,
                FIO = currentRow.Cells["ФИО"].Value.ToString(),
                Phone = currentRow.Cells["Телефон"].Value.ToString(),
                Address = currentRow.Cells["Адрес"].Value.ToString()
            };

            return client;
        }

        private void dataGridViewClients_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;
                    int lastRow = dataGridViewClients.Rows.Count - 2;
                    DataGridViewRow row = dataGridViewClients.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewClients[row.Cells["Операция"].ColumnIndex, lastRow] = linkCell;

                    row.Cells["Операция"].Value = "Добавить";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewClients_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = dataGridViewClients.SelectedCells[0].RowIndex;
                    DataGridViewRow editingRow = dataGridViewClients.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewClients[editingRow.Cells["Операция"].ColumnIndex, rowIndex] = linkCell;
                    editingRow.Cells["Операция"].Value = "Изм.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewClients_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);

            if (dataGridViewClients.CurrentCell.ColumnIndex == 1)
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

        private void ClientForm_Load(object sender, EventArgs e)
        {
            try
            {
                clientController.GetAllClients(ref dataGridViewClients);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
