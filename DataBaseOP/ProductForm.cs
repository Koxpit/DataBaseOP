using DataBaseOP.Controllers;
using DataBaseOP.Database.Entities;
using DataBaseOP.Services;
using DataBaseOP.ViewModels;
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
                    DataGridViewRow currentRow = dataGridViewProducts.Rows[rowIndex];
                    Product newProduct = GetProductInfo(ref currentRow);

                    productController.Add(newProduct);
                    dataGridViewProducts.Rows[e.RowIndex].Cells["Операция"].Value = "Удалить";
                }
                else if (task == "Изм.")
                {
                    int rowIndex = e.RowIndex;
                    DataGridViewRow currentRow = dataGridViewProducts.Rows[rowIndex];
                    Product updatedProduct = GetProductInfo(ref currentRow);

                    productController.Edit(updatedProduct);
                    currentRow.Cells["Операция"].Value = "Удалить";
                }

                productController.GetAllProducts(ref dataGridViewProducts);
            }
        }

        private Product GetProductInfo(ref DataGridViewRow currentRow)
        {
            ProductEntitiesIDsVM productViewModel = new ProductEntitiesIDsVM()
            {
                ProductID = productController.GetProductIdByName(currentRow.Cells["Наименование"].Value.ToString()),
                CategoryID = categoryController.GetCategoryIdByName(currentRow.Cells["Категория"].Value.ToString()),
                TrademarkID = trademarkController.GetTrademarkIdByName(currentRow.Cells["Бренд"].Value.ToString())
            };

            if (GetInfoHandleNotOK(productViewModel))
                MessageBox.Show("Операция не удалась", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                return null;

            Product product = new Product
            {
                ID = (int)currentRow.Cells["ID"].Value,
                Name = currentRow.Cells["Наименование"].Value.ToString(),
                Amount = (int)currentRow.Cells["Кол-во на складе"].Value,
                Unit = currentRow.Cells["Ед.изм."].Value.ToString(),
                Cost = (decimal)currentRow.Cells["Стоимость"].Value,
                Description = currentRow.Cells["Описание"].Value.ToString(),
                CategoryID = productViewModel.CategoryID,
                TrademarkID = productViewModel.TrademarkID
            };

            return product;
        }

        private bool GetInfoHandleNotOK(ProductEntitiesIDsVM productViewModel)
        {
            bool handleOK = true;
            int productId = productViewModel.ProductID;
            int categoryId = productViewModel.CategoryID;
            int trademarkId = productViewModel.TrademarkID;

            if (categoryId == 0)
            {
                MessageBox.Show("Поставщик не найден", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                handleOK = false;
            }
            if (trademarkId == 0)
            {
                MessageBox.Show("Поставщик не найден", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                handleOK = false;
            }
            if (productId != 0)
            {
                MessageBox.Show("Реализация уже существует", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                handleOK = false;
            }

            return handleOK;
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
                    dataGridViewProducts[editingRow.Cells["Операция"].ColumnIndex, rowIndex] = linkCell;
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
                    dataGridViewProducts[row.Cells["Операция"].ColumnIndex, lastRow] = linkCell;

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

        private void экспортВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelService.ExportToExcel(dataGridViewProducts, this.Text);
        }
    }
}
