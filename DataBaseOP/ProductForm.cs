using DataBaseOP.Controllers;
using DataBaseOP.Database.Entities;
using DataBaseOP.Services;
using DataBaseOP.ViewModels;
using System;
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
                    if (newProduct == null)
                        return;

                    int currentProductId = productController.GetProductIdByName(newProduct.Name);
                    if (currentProductId != 0)
                    {
                        MessageBox.Show("Продукт с введенным названием уже существует.");
                        return;
                    }

                    productController.Add(newProduct);
                    dataGridViewProducts.Rows[e.RowIndex].Cells["Операция"].Value = "Удалить";
                }
                else if (task == "Изм.")
                {
                    int rowIndex = e.RowIndex;
                    DataGridViewRow currentRow = dataGridViewProducts.Rows[rowIndex];

                    Product updatedProduct = GetProductInfo(ref currentRow);
                    if (updatedProduct == null)
                        return;

                    int currentProductId = productController.GetProductIdByName(updatedProduct.Name);
                    if (updatedProduct.ID != currentProductId && currentProductId != 0)
                    {
                        MessageBox.Show("Продукт с введенным названием уже существует.");
                        return;
                    }

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

            if (CellsIsNull(product))
            {
                MessageBox.Show("Заполните все поля!");
                return null;
            }

            return product;
        }

        private bool CellsIsNull(Product product)
        {
            bool isNull = false;

            if (product.Name == "" || product.Amount == 0 || product.Unit == ""
                || product.Cost == 0 || product.Description == "")
                isNull = true;

            return isNull;
        }

        private bool GetInfoHandleNotOK(ProductEntitiesIDsVM productViewModel)
        {
            bool handleNotOK = false;
            int categoryId = productViewModel.CategoryID;
            int trademarkId = productViewModel.TrademarkID;

            if (categoryId == 0)
            {
                MessageBox.Show("Категория не найдена", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                handleNotOK = true;
                return handleNotOK;
            }
            if (trademarkId == 0)
            {
                MessageBox.Show("Бренд не найден", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                handleNotOK = true;
                return handleNotOK;
            }

            return handleNotOK;
        }

        private void dataGridViewProducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = dataGridViewProducts.SelectedCells[0].RowIndex;
                    DataGridViewRow editingRow = dataGridViewProducts.Rows[rowIndex];

                    Product product = GetProductInfo(ref editingRow);
                    if (product == null)
                        return;

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
            try
            {
                e.Control.KeyPress -= new KeyPressEventHandler(InputHandlerService.DigitOnly);
                int columnIndex = dataGridViewProducts.CurrentCell.ColumnIndex;

                if (columnIndex == 2 || columnIndex == 4)
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(InputHandlerService.DigitOnly);
                    }
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
                ExcelService.ExportToExcel(dataGridViewProducts, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewProducts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                newRowAdding = false;

                foreach (DataGridViewRow s in dataGridViewProducts.Rows)
                {
                    if (s.Index <= dataGridViewProducts.Rows.Count - 2)
                    {
                        if (s.Cells["Наименование"].Value.ToString() == ""
                            || s.Cells["Кол-во на складе"].Value.ToString() == ""
                            || s.Cells["Ед.изм."].Value.ToString() == ""
                            || s.Cells["Стоимость"].Value.ToString() == ""
                            || s.Cells["Описание"].Value.ToString() == "")
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
