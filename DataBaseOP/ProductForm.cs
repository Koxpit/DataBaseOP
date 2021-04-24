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
    public partial class ProductForm : Form
    {
        private readonly ProductController productController;
        private readonly CategoryController categoryController;
        private readonly TrademarkController trademarkController;
        private bool newRowAdding = false;

        public ProductForm()
        {
            InitializeComponent();
            productController = new ProductController();
            categoryController = new CategoryController();
            trademarkController = new TrademarkController();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            try
            {
                productController.GetAllProducts(ref dataGridViewProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int taskIndex = dataGridViewProducts.Rows[e.RowIndex].Cells["Операция"].ColumnIndex;

            if (e.ColumnIndex == taskIndex)
            {
                string task = dataGridViewProducts.Rows[e.RowIndex].Cells["Операция"].Value.ToString();

                if (task == "Удалить")
                {
                    if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = (int)dataGridViewProducts.CurrentRow.Cells["ID"].Value;
                        productController.Delete(id);
                    }
                }
                else if (task == "Добавить")
                {
                    int rowIndex = dataGridViewProducts.Rows.Count - 2;
                    DataGridViewRow row = dataGridViewProducts.Rows[rowIndex];
                    int productId = productController.GetProductIdByName(row.Cells["Наименование"].Value.ToString());
                    int categoryId = categoryController.GetCategoryIdByName(row.Cells["Категория"].Value.ToString());
                    int trademarkId = trademarkController.GetTrademarkIdByName(row.Cells["Бренд"].Value.ToString());

                    if (productId != 0)
                    {
                        MessageBox.Show("Продукт уже существует", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (categoryId == 0)
                    {
                        MessageBox.Show("Категория не найдена", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (trademarkId == 0)
                    {
                        MessageBox.Show("Бренд не найден", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Product newProduct = new Product
                    {
                        Name = row.Cells["Наименование"].Value.ToString(),
                        Amount = (int)row.Cells["Кол-во на складе"].Value,
                        Unit = row.Cells["Ед.изм."].Value.ToString(),
                        Cost = (decimal)row.Cells["Стоимость"].Value,
                        Description = row.Cells["Описание"].Value.ToString(),
                        CategoryID = categoryId,
                        TrademarkID = trademarkId
                    };

                    productController.Add(newProduct);
                    dataGridViewProducts.Rows[e.RowIndex].Cells["Операция"].Value = "Удалить";
                }
                else if (task == "Изм.")
                {
                    int rowIndex = e.RowIndex;
                    DataGridViewRow row = dataGridViewProducts.Rows[rowIndex];
                    int categoryId = categoryController.GetCategoryIdByName(row.Cells["Категория"].Value.ToString());
                    int trademarkId = trademarkController.GetTrademarkIdByName(row.Cells["Бренд"].Value.ToString());

                    Product updatedProduct = new Product
                    {
                        ID = (int)row.Cells["ID"].Value,
                        Name = row.Cells["Наименование"].Value.ToString(),
                        Amount = (int)row.Cells["Кол-во на складе"].Value,
                        Unit = row.Cells["Ед.изм."].Value.ToString(),
                        Cost = (decimal)row.Cells["Стоимость"].Value,
                        Description = row.Cells["Описание"].Value.ToString(),
                        CategoryID = categoryId,
                        TrademarkID = trademarkId
                    };

                    productController.Edit(updatedProduct);
                    row.Cells["Операция"].Value = "Удалить";
                }

                productController.GetAllProducts(ref dataGridViewProducts);
            }
        }

        private void dataGridViewProducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = dataGridViewProducts.SelectedCells[0].RowIndex;
                    DataGridViewRow editingRow = dataGridViewProducts.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewProducts[8, rowIndex] = linkCell;
                    editingRow.Cells["Операция"].Value = "Изм.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewProducts_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;
                    int lastRow = dataGridViewProducts.Rows.Count - 2;
                    DataGridViewRow row = dataGridViewProducts.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewProducts[8, lastRow] = linkCell;

                    row.Cells["Операция"].Value = "Добавить";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewProducts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);

            if (dataGridViewProducts.CurrentCell.ColumnIndex == 1)
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
