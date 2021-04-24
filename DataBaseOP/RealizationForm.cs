using DataBaseOP.Controllers;
using DataBaseOP.Database.Entities;
using System;
using System.Windows.Forms;

namespace DataBaseOP
{
    public partial class RealizationForm : Form
    {
        private readonly RealizationController realizationController;
        private readonly ProductController productController;
        private readonly WorkerController workerController;
        private readonly SupplierController supplierController;
        private bool newRowAdding = false;

        public RealizationForm()
        {
            InitializeComponent();
            realizationController = new RealizationController();
            productController = new ProductController();
            workerController = new WorkerController();
            supplierController = new SupplierController();
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
                        Realization newRealization = GetNewRealization();

                        if (newRealization != null)
                        {
                            realizationController.Add(newRealization);
                            dataGridViewRealizations.Rows[e.RowIndex].Cells["Операция"].Value = "Удалить";
                        }
                    }
                    else if (task == "Изм.")
                    {
                        int rowIndex = e.RowIndex;
                        DataGridViewRow row = dataGridViewRealizations.Rows[rowIndex];
                        Realization updatedRealiaztion = GetUpdatedRealization(row);

                        if (updatedRealiaztion != null)
                        {
                            realizationController.Edit(updatedRealiaztion);
                            row.Cells["Операция"].Value = "Удалить";
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

        private Realization GetNewRealization()
        {
            int rowIndex = dataGridViewRealizations.Rows.Count - 2;
            DataGridViewRow row = dataGridViewRealizations.Rows[rowIndex];

            int supplierId = supplierController.GetSupplierIdByPhone(row.Cells["Телефон поставщика"].Value.ToString());
            int realizationId = realizationController.GetRealizationIdByNumber(row.Cells["Номер договора"].Value.ToString());
            int seniorId = workerController.GetWorkerIdByPhone(row.Cells["Телефон работника"].Value.ToString());
            int productId = productController.GetProductIdByName(row.Cells["Наименование продукта"].Value.ToString());

            if (AddHandleNotOK(supplierId, realizationId, seniorId, productId))
                MessageBox.Show("Операция не удалась", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else 
                return null;

            string number = row.Cells["Номер договора"].Value.ToString();
            if (number.Length > 8)
            {
                MessageBox.Show("Номер договора не должен превышать больше 8 символов");
                return null;
            }
            else if (number.Length < 8)
                CreateNumberRealization(ref number);

            decimal change = GetChange((decimal)row.Cells["Оплачено"].Value, (decimal)row.Cells["Сумма к оплате"].Value);
            decimal amountDue = GetAmountDue((decimal)row.Cells["Стоимость"].Value, (int)row.Cells["Скидка (%)"].Value);

            Realization newRealization = new Realization
            {
                Number = number,
                RealizeDate = Convert.ToDateTime(row.Cells["Срок реализации"].Value),
                Cost = (decimal)row.Cells["Стоимость"].Value,
                Discount = (int)row.Cells["Скидка (%)"].Value,
                AmountDue = amountDue,
                PaidOf = (decimal)row.Cells["Оплачено"].Value,
                Change = change,
                AmountProducts = (int)row.Cells["Кол-во продукции"].Value,
                Realized = (bool)row.Cells["Реализовано"].Value,
                SupplierID = supplierId,
                SeniorID = seniorId,
                ProductID = productId
            };

            return newRealization;
        }

        private bool AddHandleNotOK(int supplierId, int realizationId, int seniorId, int productId)
        {
            bool handleOK = true;

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

        private Realization GetUpdatedRealization(DataGridViewRow currentRow)
        {
            DataGridViewRow row = currentRow;
            int supplierId = supplierController.GetSupplierIdByPhone(row.Cells["Телефон поставщика"].Value.ToString());
            int realizationId = realizationController.GetRealizationIdByNumber(row.Cells["Номер договора"].Value.ToString());
            int seniorId = workerController.GetWorkerIdByPhone(row.Cells["Телефон работника"].Value.ToString());
            int productId = productController.GetProductIdByName(row.Cells["Наименование продукта"].Value.ToString());

            if (AddHandleNotOK(supplierId, realizationId, seniorId, productId))
                MessageBox.Show("Операция не удалась", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                return null;

            string number = row.Cells["Номер договора"].Value.ToString();
            if (number.Length > 8)
            {
                MessageBox.Show("Номер договора не должен превышать больше 8 символов");
                return null;
            }
            else if (number.Length < 8)
                CreateNumberRealization(ref number);

            decimal change = GetChange((decimal)row.Cells["Оплачено"].Value, (decimal)row.Cells["Сумма к оплате"].Value);
            decimal amountDue = GetAmountDue((decimal)row.Cells["Стоимость"].Value, (int)row.Cells["Скидка (%)"].Value);

            Realization updatedRealiation = new Realization
            {
                ID = (int)row.Cells["ID"].Value,
                Number = number,
                RealizeDate = Convert.ToDateTime(row.Cells["Срок реализации"].Value),
                Cost = (decimal)row.Cells["Стоимость"].Value,
                Discount = (int)row.Cells["Скидка (%)"].Value,
                AmountDue = amountDue,
                PaidOf = (decimal)row.Cells["Оплачено"].Value,
                Change = change,
                AmountProducts = (int)row.Cells["Кол-во продукции"].Value,
                Realized = (bool)row.Cells["Реализовано"].Value,
                SupplierID = supplierId,
                SeniorID = seniorId,
                ProductID = productId
            };

            return updatedRealiation;
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
                    dataGridViewRealizations[13, lastRow] = linkCell;

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
                    dataGridViewRealizations[13, rowIndex] = linkCell;
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
    }
}
