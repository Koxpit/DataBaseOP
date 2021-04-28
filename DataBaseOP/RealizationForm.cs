using DataBaseOP.Controllers;
using DataBaseOP.Database.Entities;
using DataBaseOP.Services;
using DataBaseOP.ViewModels;
using System;
using System.Data;
using System.Windows.Forms;

namespace DataBaseOP
{
    public partial class RealizationForm : Form
    {
        private readonly RealizationController realizationController;
        private readonly ProductController productController;
        private readonly WorkerController workerController;
        private readonly SupplierController supplierController;
        private readonly ClientController clientController;

        private bool newRowAdding = false;

        public RealizationForm()
        {
            InitializeComponent();

            realizationController = new RealizationController();
            productController = new ProductController();
            workerController = new WorkerController();
            supplierController = new SupplierController();
            clientController = new ClientController();
        }

        private void RealizationForm_Load(object sender, EventArgs e)
        {
            try
            {
                realizationController.GetAllRealizations(ref dataGridViewRealizations);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewRealizations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CellContentClickTip(ref e);

                int taskIndex = dataGridViewRealizations.Rows[e.RowIndex].Cells["Операция"].ColumnIndex;

                if (e.ColumnIndex == taskIndex)
                {
                    string task = dataGridViewRealizations.Rows[e.RowIndex].Cells["Операция"].Value.ToString();

                    if (task == "Удалить")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int id = (int)dataGridViewRealizations.CurrentRow.Cells["ID"].Value;
                            realizationController.Delete(id);
                        }
                    }
                    else if (task == "Добавить")
                    {
                        int rowIndex = dataGridViewRealizations.Rows.Count - 2;
                        DataGridViewRow currentRow = dataGridViewRealizations.Rows[rowIndex];
                        Realization newRealization = GetRealizationInfo(ref currentRow);

                        if (newRealization != null)
                        {
                            realizationController.Add(newRealization);
                            dataGridViewRealizations.Rows[e.RowIndex].Cells["Операция"].Value = "Удалить";
                        }
                    }
                    else if (task == "Изм.")
                    {
                        int rowIndex = e.RowIndex;
                        DataGridViewRow currentRow = dataGridViewRealizations.Rows[rowIndex];
                        Realization updatedRealiaztion = GetRealizationInfo(ref currentRow);

                        if (updatedRealiaztion != null)
                        {
                            realizationController.Edit(updatedRealiaztion);
                            currentRow.Cells["Операция"].Value = "Удалить";
                        }
                    }

                    realizationController.GetAllRealizations(ref dataGridViewRealizations);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CellContentClickTip(ref DataGridViewCellEventArgs e)
        {
            DataGridViewCell clientPhoneCell = dataGridViewRealizations.Rows[e.RowIndex].Cells["Телефон заказчика"];
            DataGridViewCell supplierPhoneCell = dataGridViewRealizations.Rows[e.RowIndex].Cells["Телефон поставщика"];
            DataGridViewCell workerPhoneCell = dataGridViewRealizations.Rows[e.RowIndex].Cells["Телефон работника"];
            DataGridViewRow currentRow = dataGridViewRealizations.Rows[e.RowIndex];

            if (e.ColumnIndex == clientPhoneCell.ColumnIndex)
            {
                Client client = clientController.GetClientInfoByPhone(currentRow.Cells["Телефон заказчика"].Value.ToString());
                clientPhoneCell.ToolTipText = "ФИО: " + client.FIO + "\n" + "Адрес: " + client.Address + "\n" + "Телефон: " + client.Phone;
            }

            if (e.ColumnIndex == supplierPhoneCell.ColumnIndex)
            {
                Supplier supplier = supplierController.GetSupplierInfoByPhone(currentRow.Cells["Телефон поставщика"].Value.ToString());
                supplierPhoneCell.ToolTipText = "ФИО: " + supplier.FIO + "\n" + "Адрес: " + supplier.Address + "\n" + "Телефон: " + supplier.Phone;
            }

            if (e.ColumnIndex == workerPhoneCell.ColumnIndex)
            {
                Worker worker = workerController.GetWorkerInfoByPhone(currentRow.Cells["Телефон работника"].Value.ToString());
                workerPhoneCell.ToolTipText = "ФИО: " + worker.FIO + "\n" + "Должность: " + worker.Position.Name;
            }
        }

        private Realization GetRealizationInfo(ref DataGridViewRow currentRow)
        {
            RealizationEntitiesIDsVM realizationViewModel = new RealizationEntitiesIDsVM()
            {
                ClientID = clientController.GetClientIdByPhone(currentRow.Cells["Телефон заказчика"].Value.ToString()),
                SupplierID = supplierController.GetSupplierIdByPhone(currentRow.Cells["Телефон поставщика"].Value.ToString()),
                RealizationID = realizationController.GetRealizationIdByNumber(currentRow.Cells["Номер договора"].Value.ToString()),
                SeniorID = workerController.GetWorkerIdByPhone(currentRow.Cells["Телефон работника"].Value.ToString()),
                ProductID = productController.GetProductIdByName(currentRow.Cells["Наименование продукта"].Value.ToString())
            };

            if (GetInfoHandleNotOK(realizationViewModel))
                MessageBox.Show("Операция не удалась", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else 
                return null;

            string currentNumberRealization = currentRow.Cells["Номер договора"].Value.ToString();
            if (currentNumberRealization.Length > 8)
            {
                MessageBox.Show("Номер договора не должен превышать больше 8 символов");
                return null;
            }
            else if (currentNumberRealization.Length < 8)
                CreateNumberRealization(ref currentNumberRealization);

            decimal change = GetChange((decimal)currentRow.Cells["Оплачено"].Value, (decimal)currentRow.Cells["Сумма к оплате"].Value);
            decimal amountDue = GetAmountDue((decimal)currentRow.Cells["Стоимость"].Value, (int)currentRow.Cells["Скидка (%)"].Value);

            Realization realization = new Realization
            {
                ID = (int)currentRow.Cells["ID"].Value,
                Number = currentNumberRealization,
                RealizeDate = Convert.ToDateTime(currentRow.Cells["Срок реализации"].Value),
                Cost = (decimal)currentRow.Cells["Стоимость"].Value,
                Discount = (int)currentRow.Cells["Скидка (%)"].Value,
                AmountDue = amountDue,
                PaidOf = (decimal)currentRow.Cells["Оплачено"].Value,
                Change = change,
                AmountProducts = (int)currentRow.Cells["Кол-во продукции"].Value,
                Realized = (bool)currentRow.Cells["Реализовано"].Value,
                ClientID = realizationViewModel.ClientID,
                SupplierID = realizationViewModel.SupplierID,
                SeniorID = realizationViewModel.SeniorID,
                ProductID = realizationViewModel.ProductID
            };

            return realization;
        }

        private bool GetInfoHandleNotOK(RealizationEntitiesIDsVM realizationViewModel)
        {
            bool handleOK = true;
            int clientId = realizationViewModel.ClientID;
            int supplierId = realizationViewModel.SupplierID;
            int realizationId = realizationViewModel.RealizationID;
            int seniorId = realizationViewModel.SeniorID;
            int productId = realizationViewModel.ProductID;

            if (clientId == 0)
            {
                MessageBox.Show("Поставщик не найден", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                handleOK = false;
            }
            if (supplierId == 0)
            {
                MessageBox.Show("Поставщик не найден", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                handleOK = false;
            }
            if (realizationId != 0)
            {
                MessageBox.Show("Реализация уже существует", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                handleOK = false;
            }
            if (seniorId == 0)
            {
                MessageBox.Show("Рабочий не найден", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                handleOK = false;
            }
            if (productId == 0)
            {
                MessageBox.Show("Продукт не найден", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                handleOK = false;
            }

            return handleOK;
        }

        private void CreateNumberRealization(ref string number)
        {
            for (int i = 8; number.Length < i;)
                number = "0" + number;
        }

        private decimal GetChange(decimal paidOf, decimal amountDue)
        {
            decimal change = paidOf - amountDue;

            if (change < 0)
                change = 0;

            return change;
        }

        private decimal GetAmountDue(decimal cost, decimal discount)
        {
            return cost - cost * (discount / 100);
        }

        private void dataGridViewRealizations_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;
                    int lastRow = dataGridViewRealizations.Rows.Count - 2;
                    DataGridViewRow row = dataGridViewRealizations.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewRealizations[row.Cells["Операция"].ColumnIndex, lastRow] = linkCell;

                    row.Cells["Операция"].Value = "Добавить";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewRealizations_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = dataGridViewRealizations.SelectedCells[0].RowIndex;
                    DataGridViewRow editingRow = dataGridViewRealizations.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewRealizations[editingRow.Cells["Операция"].ColumnIndex, rowIndex] = linkCell;
                    editingRow.Cells["Операция"].Value = "Изм.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewRealizations_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);

            if (dataGridViewRealizations.CurrentCell.ColumnIndex == 1)
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
            ExcelService.ExportToExcel(dataGridViewRealizations, this.Text);
        }

        private void toolTip_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
