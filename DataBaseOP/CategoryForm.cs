using DataBaseOP.Controllers;
using DataBaseOP.Database.Entities;
using System;
using System.Windows.Forms;

namespace DataBaseOP
{
    public partial class CategoryForm : Form
    {
        private readonly CategoryController categoryController;
        private bool newRowAdding = false;

        public CategoryForm()
        {
            InitializeComponent();
            categoryController = new CategoryController();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            try
            {
                categoryController.GetAllCategories(ref dataGridViewCategories);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                string task = dataGridViewCategories.Rows[e.RowIndex].Cells[2].Value.ToString();

                if (task == "Удалить")
                {
                    if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = (int)dataGridViewCategories.CurrentRow.Cells[0].Value;
                        categoryController.Delete(id);
                    }
                }
                else if (task == "Добавить")
                {
                    int rowIndex = dataGridViewCategories.Rows.Count - 2;

                    Category newCategory = new Category
                    {
                        Name = dataGridViewCategories.Rows[rowIndex].Cells["Наименование"].Value.ToString()
                    };

                    categoryController.Add(newCategory);
                    dataGridViewCategories.Rows[e.RowIndex].Cells[2].Value = "Удалить";
                }
                else if (task == "Изм.")
                {
                    int rowIndex = e.RowIndex;

                    Category updatedCategory = new Category
                    {
                        ID = (int)dataGridViewCategories.CurrentRow.Cells[0].Value,
                        Name = dataGridViewCategories.Rows[rowIndex].Cells["Наименование"].Value.ToString()
                    };

                    categoryController.Edit(updatedCategory);
                    dataGridViewCategories.Rows[e.RowIndex].Cells[2].Value = "Удалить";
                }

                categoryController.GetAllCategories(ref dataGridViewCategories);
            }
        }

        private void dataGridViewCategories_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;
                    int lastRow = dataGridViewCategories.Rows.Count - 2;
                    DataGridViewRow row = dataGridViewCategories.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewCategories[2, lastRow] = linkCell;

                    row.Cells["Операция"].Value = "Добавить";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewCategories_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = dataGridViewCategories.SelectedCells[0].RowIndex;
                    DataGridViewRow editingRow = dataGridViewCategories.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewCategories[2, rowIndex] = linkCell;
                    editingRow.Cells["Операция"].Value = "Изм.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewCategories_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);

            if (dataGridViewCategories.CurrentCell.ColumnIndex == 1)
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
