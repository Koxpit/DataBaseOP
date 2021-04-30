using DataBaseOP.Controllers;
using DataBaseOP.Database.Entities;
using System;
using DataBaseOP.Services;
using System.Windows.Forms;

namespace DataBaseOP
{
    public partial class SupplierForm : Form
    {
        private readonly SupplierController supplierController;
        private bool newRowAdding = false;

        public SupplierForm()
        {
            InitializeComponent();
            supplierController = new SupplierController();
        }

        private void экспортВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelService.ExportToExcel(dataGridViewSuppliers, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            try
            {
                supplierController.GetAllSuppliers(ref dataGridViewSuppliers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewSuppliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int taskIndex = dataGridViewSuppliers.Rows[e.RowIndex].Cells["Операция"].ColumnIndex;

                if (e.ColumnIndex == taskIndex)
                {
                    string task = dataGridViewSuppliers.Rows[e.RowIndex].Cells["Операция"].Value.ToString();

                    if (task == "Удалить")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int id = (int)dataGridViewSuppliers.CurrentRow.Cells["ID"].Value;
                            supplierController.Delete(id);
                        }
                    }
                    else if (task == "Добавить")
                    {
                        int rowIndex = dataGridViewSuppliers.Rows.Count - 2;
                        DataGridViewRow currentRow = dataGridViewSuppliers.Rows[rowIndex];

                        Supplier newSupplier = GetSupplierInfo(ref currentRow);
                        if (newSupplier == null)
                            return;

                        if (newSupplier.Phone.Length > 11)
                        {
                            MessageBox.Show("Номер телефона должен состоять не более чем из 11 цифр.");
                            return;
                        }

                        int currentSupplierId = supplierController.GetSupplierIdByPhone(newSupplier.Phone);
                        if (currentSupplierId != 0)
                        {
                            MessageBox.Show("Поставщик с введенным номером телефона уже существует.");
                            return;
                        }

                        supplierController.Add(newSupplier);

                        dataGridViewSuppliers.Rows[e.RowIndex].Cells["Операция"].Value = "Удалить";
                    }
                    else if (task == "Изм.")
                    {
                        int rowIndex = e.RowIndex;
                        DataGridViewRow currentRow = dataGridViewSuppliers.Rows[rowIndex];

                        Supplier updatedSupplier = GetSupplierInfo(ref currentRow);
                        if (updatedSupplier == null)
                            return;

                        int currentSupplierId = supplierController.GetSupplierIdByPhone(updatedSupplier.Phone);
                        if (updatedSupplier.ID != currentSupplierId && currentSupplierId != 0)
                        {
                            MessageBox.Show("Поставщик с введенным номером телефона уже существует.");
                            return;
                        }

                        supplierController.Edit(updatedSupplier);

                        currentRow.Cells["Операция"].Value = "Удалить";
                    }

                    supplierController.GetAllSuppliers(ref dataGridViewSuppliers);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Supplier GetSupplierInfo(ref DataGridViewRow currentRow)
        {
            Supplier supplier = new Supplier
            {
                ID = (int)currentRow.Cells["ID"].Value,
                FIO = currentRow.Cells["ФИО"].Value.ToString(),
                Address = currentRow.Cells["Адрес"].Value.ToString(),
                Phone = currentRow.Cells["Телефон"].Value.ToString()
            };

            if (CellsIsNull(supplier))
                return null;

            return supplier;
        }

        private bool CellsIsNull(Supplier supplier)
        {
            bool isNull = false;

            if (supplier.FIO == "")
            {
                MessageBox.Show("Ошибка! Заполните поле 'ФИО'!");
                isNull = true;
                return isNull;
            }

            if (supplier.Address == "")
            {
                MessageBox.Show("Ошибка! Заполнените поле 'Адрес'!");
                isNull = true;
                return isNull;
            }

            if (supplier.Phone == "")
            {
                MessageBox.Show("Ошибка! Заполнените поле 'Телефон'!");
                isNull = true;
                return isNull;
            }

            return isNull;
        }

        private void dataGridViewSuppliers_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;
                    int lastRow = dataGridViewSuppliers.Rows.Count - 2;
                    DataGridViewRow row = dataGridViewSuppliers.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewSuppliers[row.Cells["Операция"].ColumnIndex, lastRow] = linkCell;

                    row.Cells["Операция"].Value = "Добавить";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewSuppliers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = dataGridViewSuppliers.SelectedCells[0].RowIndex;
                    DataGridViewRow editingRow = dataGridViewSuppliers.Rows[rowIndex];

                    Supplier supplier = GetSupplierInfo(ref editingRow);
                    if (supplier == null)
                        return;

                    if (supplier.Phone.Length > 11)
                    {
                        MessageBox.Show("Номер телефона должен состоять не более чем из 11 цифр.");
                        return;
                    }

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewSuppliers[editingRow.Cells["Операция"].ColumnIndex, rowIndex] = linkCell;
                    editingRow.Cells["Операция"].Value = "Изм.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewSuppliers_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                TextBox textBox = e.Control as TextBox;
                int columnIndex = dataGridViewSuppliers.CurrentCell.ColumnIndex;

                if (columnIndex == 1)
                    if (textBox != null)
                        textBox.KeyPress += new KeyPressEventHandler(InputHandlerService.SymbolWithSpace);

                if (columnIndex == 3)
                    if (textBox != null)
                        textBox.KeyPress += new KeyPressEventHandler(InputHandlerService.DigitOnly);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewSuppliers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                newRowAdding = false;

                foreach (DataGridViewRow s in dataGridViewSuppliers.Rows)
                {
                    if (s.Index <= dataGridViewSuppliers.Rows.Count - 2)
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
