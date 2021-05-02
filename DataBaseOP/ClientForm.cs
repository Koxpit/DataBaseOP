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
            try
            {
                ExcelService.ExportToExcel(dataGridViewClients, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) //редактрование с второй строки
                    return;

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
                        if (newClient == null)
                            return;

                        if (newClient.Phone.Length > 11)
                        {
                            MessageBox.Show("Номер телефона должен состоять не более чем из 11 цифр.");
                            return;
                        }

                        int currentClientId = clientController.GetClientIdByPhone(newClient.Phone);
                        if (currentClientId != 0)
                        {
                            MessageBox.Show("Введенный номер телефона уже принадлежит другому заказчику.");
                            return;
                        }

                        clientController.Add(newClient);

                        dataGridViewClients.Rows[e.RowIndex].Cells["Операция"].Value = "Удалить";
                    }
                    else if (task == "Изм.")
                    {
                        int rowIndex = e.RowIndex;
                        DataGridViewRow currentRow = dataGridViewClients.Rows[rowIndex];

                        Client updatedClient = GetClientInfo(ref currentRow);
                        if (updatedClient == null)
                            return;

                        int currentClientId = clientController.GetClientIdByPhone(updatedClient.Phone);
                        if (updatedClient.ID != currentClientId && currentClientId != 0)
                        {
                            MessageBox.Show("Введенный номер телефона уже принадлежит другому заказчику.");
                            return;
                        }

                        clientController.Edit(updatedClient);

                        dataGridViewClients.Rows[rowIndex].Cells["Операция"].Value = "Удалить";
                    }

                    clientController.GetAllClients(ref dataGridViewClients);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (CellsIsNull(client))
            {
                MessageBox.Show("Заполните все поля!");
                return null;
            }

            return client;
        }

        private bool CellsIsNull(Client client)
        {
            bool isNull = false;

            if (client.FIO == "" || client.Address == "" || client.Phone == "")
                isNull = true;

            return isNull;
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

                    Client client = GetClientInfo(ref editingRow);
                    if (client == null)
                        return;

                    if (client.Phone.Length > 11)
                    {
                        MessageBox.Show("Номер телефона должен состоять не более чем из 11 цифр.");
                        return;
                    }

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
            try
            {
                e.Control.KeyPress -= new KeyPressEventHandler(InputHandlerService.DigitOnly);
                e.Control.KeyPress -= new KeyPressEventHandler(InputHandlerService.SymbolWithSpace);
                int columnIndex = dataGridViewClients.CurrentCell.ColumnIndex;

                if (columnIndex == 2)
                {
                    TextBox textBox = e.Control as TextBox;
                    if (textBox != null)
                        textBox.KeyPress += new KeyPressEventHandler(InputHandlerService.DigitOnly);
                }

                if (columnIndex == 1)
                {
                    TextBox textBox = e.Control as TextBox;
                    if (textBox != null)
                        textBox.KeyPress += new KeyPressEventHandler(InputHandlerService.SymbolWithSpace);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dataGridViewClients_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                newRowAdding = false;

                foreach (DataGridViewRow s in dataGridViewClients.Rows)
                {
                    if (s.Index <= dataGridViewClients.Rows.Count - 2)
                    {
                        if (s.Cells["ФИО"].Value.ToString() == ""
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
