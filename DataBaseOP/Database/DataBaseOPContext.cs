using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataBaseOP.Database.Entities;

namespace DataBaseOP.Database
{
    class DataBaseOPContext
    {
        private static readonly DataBaseOPContext context = new DataBaseOPContext();
        public static DataBaseOPContext GetContext => context;
        private string ConnectionString { get; }

        private DataBaseOPContext()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }

        // POSITION COMMANDS

        public void AddPosition(Position position)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Position newPosition = position;
                string name = newPosition.Name;

                SqlCommand command = new SqlCommand("sp_InsertPosition", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", name);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void EditPosition(Position position)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Position updatedPosition = position;
                int id = updatedPosition.ID;
                string name = updatedPosition.Name;

                SqlCommand command = new SqlCommand("sp_UpdatePosition", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Name", name);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public DataTable GetAllPositions()
        {
            DataTable dataTable;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetAllPositions", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);

                connection.Close();
            }

            return dataTable;
        }


        // CATEGORY COMMANDS

        public void AddCategory(Category category)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Category newCategory = (Category)category;
                string name = newCategory.Name;

                SqlCommand command = new SqlCommand("sp_InsertCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", name);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void EditCategory(Category category)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Category updatedCategory = (Category)category;
                int id = updatedCategory.ID;
                string name = updatedCategory.Name;

                SqlCommand command = new SqlCommand("sp_UpdateCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Name", name);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void Delete(int positionId, string procedureName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                int id = positionId;

                SqlCommand command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public DataTable GetAllCategories()
        {
            DataTable dataTable;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetAllCategories", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);
                dataTable.Columns[2].ReadOnly = false;

                connection.Close();
            }

            return dataTable;
        }

        public int GetCategoryIdByName(string categoryName)
        {
            int categoryId = 0;
            string name = categoryName;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetCategoryIdByName", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Name", name);

                categoryId = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
            }

            return categoryId;
        }


        // SUPPLIER COMMANDS

        
        public void AddSupplier(Supplier supplier)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Supplier newSupplier = supplier;
                string fio = newSupplier.FIO;
                string address = newSupplier.Address;
                string phone = newSupplier.Phone;

                SqlCommand command = new SqlCommand("sp_InsertSupplier", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FIO", fio);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Phone", phone);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        
        public void EditSupplier(Supplier supplier)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Supplier updatedSupplier = supplier;
                int id = updatedSupplier.ID;
                string fio = updatedSupplier.FIO;
                string address = updatedSupplier.Address;
                string phone = updatedSupplier.Phone;

                SqlCommand command = new SqlCommand("sp_UpdateSupplier", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@FIO", fio);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Phone", phone);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public DataTable GetAllSuppliers()
        {
            DataTable dataTable;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetAllSuppliers", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);
                dataTable.Columns[2].ReadOnly = false;
                dataTable.Columns[3].ReadOnly = false;
                dataTable.Columns[4].ReadOnly = false;

                connection.Close();
            }

            return dataTable;
        }

        public int GetSupplierIdByPhone(string supplierPhone)
        {
            int supplierId = 0;
            string phone = supplierPhone;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetSupplierIdByPhone", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Phone", phone);

                supplierId = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
            }

            return supplierId;
        }



        // TRADEMARK COMMANDS

        public void AddTrademark(Trademark trademark)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Trademark newTrademark = trademark;
                string name = newTrademark.Name;
                string address = newTrademark.Address;
                string phone = newTrademark.Phone;

                SqlCommand command = new SqlCommand("sp_InsertTrademark", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Phone", phone);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void EditTrademark(Trademark trademark)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Trademark updatedTrademark = trademark;
                int id = updatedTrademark.ID;
                string name = updatedTrademark.Name;
                string address = updatedTrademark.Address;
                string phone = updatedTrademark.Phone;

                SqlCommand command = new SqlCommand("sp_UpdateTrademark", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Phone", phone);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public DataTable GetAllTrademarks()
        {
            DataTable dataTable;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetAllTrademarks", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);
                dataTable.Columns[2].ReadOnly = false;
                dataTable.Columns[3].ReadOnly = false;
                dataTable.Columns[4].ReadOnly = false;

                connection.Close();
            }

            return dataTable;
        }

        public int GetTrademarkIdByName(string trademarkName)
        {
            int trademarkId = 0;
            string name = trademarkName;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetTrademarkIdByName", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Name", name);

                trademarkId = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
            }

            return trademarkId;
        }



        // REALIZATION COMMANDS

        public void AddRealization(Realization realization)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Realization newRealization = realization;
                string name = newRealization.Number;

                SqlCommand command = new SqlCommand("sp_InsertRealization", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Number", name);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void EditRealization(Realization realization)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Realization updatedRealization = realization;
                int id = updatedRealization.ID;
                string name = updatedRealization.Number;

                SqlCommand command = new SqlCommand("sp_UpdateRealization", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Number", name);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public DataTable GetAllRealizations()
        {
            DataTable dataTable;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetAllRealizations", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);
                dataTable.Columns[2].ReadOnly = false;
                dataTable.Columns[3].ReadOnly = false;
                dataTable.Columns[4].ReadOnly = false;
                dataTable.Columns[5].ReadOnly = false;
                dataTable.Columns[6].ReadOnly = false;
                dataTable.Columns[7].ReadOnly = false;
                dataTable.Columns[8].ReadOnly = false;
                dataTable.Columns[9].ReadOnly = false;
                dataTable.Columns[10].ReadOnly = false;
                dataTable.Columns[11].ReadOnly = false;
                dataTable.Columns[12].ReadOnly = false;
                dataTable.Columns[13].ReadOnly = false;

                connection.Close();
            }

            return dataTable;
        }

        public int GetRealizationIdByNumber(string realizationNumber)
        {
            int realizationId = 0;
            string number = realizationNumber;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetRealizationIdByNumber", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Number", number);

                realizationId = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
            }

            return realizationId;
        }


        // PRODUCT COMMANDS

        public void AddProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Product newProduct = product;
                string name = newProduct.Name;
                int amount = newProduct.Amount;
                string unit = newProduct.Unit;
                decimal cost = newProduct.Cost;
                string description = newProduct.Description;
                int categoryId = newProduct.CategoryID;
                int trademarkId = newProduct.TrademarkID;

                SqlCommand command = new SqlCommand("sp_InsertProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@Unit", unit);
                command.Parameters.AddWithValue("@Cost", cost);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@CategoryID", categoryId);
                command.Parameters.AddWithValue("@TrademarkID", trademarkId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void EditProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Product updatedProduct = product;
                int id = updatedProduct.ID;
                string name = updatedProduct.Name;
                int amount = updatedProduct.Amount;
                string unit = updatedProduct.Unit;
                decimal cost = updatedProduct.Cost;
                string description = updatedProduct.Description;
                int categoryId = updatedProduct.CategoryID;
                int trademarkId = updatedProduct.TrademarkID;

                SqlCommand command = new SqlCommand("sp_UpdateProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@Unit", unit);
                command.Parameters.AddWithValue("@Cost", cost);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@CategoryID", categoryId);
                command.Parameters.AddWithValue("@TrademarkID", trademarkId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public DataTable GetAllProducts()
        {
            DataTable dataTable;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetAllProducts", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);
                dataTable.Columns[2].ReadOnly = false;
                dataTable.Columns[3].ReadOnly = false;
                dataTable.Columns[4].ReadOnly = false;
                dataTable.Columns[5].ReadOnly = false;
                dataTable.Columns[6].ReadOnly = false;
                dataTable.Columns[7].ReadOnly = false;
                dataTable.Columns[8].ReadOnly = false;

                connection.Close();
            }

            return dataTable;
        }

        public int GetProductIdByName(string productName)
        {
            int productId = 0;
            string name = productName;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetProductIdByName", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Name", name);

                productId = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
            }

            return productId;
        }


        // WORKER COMMANDS

        public void AddWorker(Worker worker)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Worker newWorker = worker;
                string fio = newWorker.FIO;
                string phone = newWorker.Phone;
                string positionName = newWorker.Position.Name;
                int positionId = 0;

                SqlCommand command = new SqlCommand("sp_InsertWorker", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FIO", fio);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@PositionID", positionId);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }


        
        public void EditWorker(Worker worker)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Worker updatedWorker = worker;
                int id = updatedWorker.ID;
                string phone = updatedWorker.Phone;

                SqlCommand command = new SqlCommand("sp_UpdateWorker", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Phone", phone);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        
        public DataTable GetAllWorkers()
        {
            DataTable dataTable;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetAllWorkers", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                dataTable = new DataTable();

                dataTable.Load(reader);
                dataTable.Columns[2].ReadOnly = false;

                connection.Close();
            }

            return dataTable;
        }

        public int GetWorkerIdByPhone(string workerPhone)
        {
            int workerId = 0;
            string phone = workerPhone;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("sp_GetWorkerIdByPhone", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Phone", phone);

                workerId = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
            }

            return workerId;
        }
    }
}
