using DataBaseOP.Controllers;
using DataBaseOP.Database.Entities;
using DataBaseOP.Services;
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
                    Category newCategory = GetCategoryInfo(rowIndex);
                    if (newCategory == null)
                        return;

                    int currentCategoryId = categoryController.GetCategoryIdByName(newCategory.Name);
                    if (currentCategoryId != 0)
                    {
                        MessageBox.Show("Введенная категория уже существует.");
                        return;
                    }

                    categoryController.Add(newCategory);
                    dataGridViewCategories.Rows[e.RowIndex].Cells["Операция"].Value = "Удалить";
                }
                else if (task == "Изм.")
                {
                    int rowIndex = e.RowIndex;
                    Category updatedCategory = GetCategoryInfo(rowIndex);
                    if (updatedCategory == null)
                        return;

                    int currentCategoryId = categoryController.GetCategoryIdByName(updatedCategory.Name);
                    if (updatedCategory.ID != currentCategoryId && currentCategoryId != 0)
                    {
                        MessageBox.Show("Введенная категория уже существует.");
                        return;
                    }

                    categoryController.Edit(updatedCategory);
                    dataGridViewCategories.Rows[e.RowIndex].Cells["Операция"].Value = "Удалить";
                }

                categoryController.GetAllCategories(ref dataGridViewCategories);
            }
        }

        private Category GetCategoryInfo(int rowIndex)
        {
            Category category = new Category
            {
                ID = (int)dataGridViewCategories.CurrentRow.Cells[0].Value,
                Name = dataGridViewCategories.Rows[rowIndex].Cells["Наименование"].Value.ToString()
            };

            if (CellsIsNull(category))
                return null;

            return category;
        }

        private bool CellsIsNull(Category category)
        {
            bool isNull = false;

            if (category.Name == "")
            {
                MessageBox.Show("Ошибка! Заполните поле 'Наименование'!");
                isNull = true;
            }

            return isNull;
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
                    dataGridViewCategories[row.Cells["Операция"].ColumnIndex, lastRow] = linkCell;

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

                    Category category = GetCategoryInfo(editingRow.Index);
                    if (category == null)
                        return;

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewCategories[editingRow.Cells["Операция"].ColumnIndex, rowIndex] = linkCell;
                    editingRow.Cells["Операция"].Value = "Изм.";
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
                ExcelService.ExportToExcel(dataGridViewCategories, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewCategories_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                newRowAdding = false;

                foreach (DataGridViewRow s in dataGridViewCategories.Rows)
                {
                    if (s.Index <= dataGridViewCategories.Rows.Count - 2)
                    {
                        if (s.Cells["Наиименование"].Value.ToString() == "")
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
