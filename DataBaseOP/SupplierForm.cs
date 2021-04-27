using DataBaseOP.Controllers;
using DataBaseOP.Database.Entities;
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
    public partial class SupplierForm : Form
    {
        private readonly SupplierController supplierController;
        private bool newRowAdding = false;

        public SupplierForm()
        {
            InitializeComponent();
            supplierController = new SupplierController();
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
                        Supplier newSupplier = GetSupplierInfo(currentRow);

                        supplierController.Add(newSupplier);

                        dataGridViewSuppliers.Rows[e.RowIndex].Cells["Операция"].Value = "Удалить";
                    }
                    else if (task == "Изм.")
                    {
                        int rowIndex = e.RowIndex;
                        DataGridViewRow currentRow = dataGridViewSuppliers.Rows[rowIndex];
                        Supplier updatedSupplier = GetSupplierInfo(currentRow);

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

        private Supplier GetSupplierInfo(DataGridViewRow currentRow)
        {
            Supplier supplier = new Supplier
            {
                ID = (int)currentRow.Cells["ID"].Value,
                FIO = currentRow.Cells["ФИО"].Value.ToString(),
                Address = currentRow.Cells["Адрес"].Value.ToString(),
                Phone = currentRow.Cells["Телефон"].Value.ToString()
            };

            return supplier;
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
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);

            if (dataGridViewSuppliers.CurrentCell.ColumnIndex == 1)
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
